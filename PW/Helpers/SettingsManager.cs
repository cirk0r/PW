using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace PW.Helpers
{
    public class SettingsManager<T> where T : class
    {
        private XmlSerializer _serializer;
        private Stream _inputStream;
        private string _filePath;

        public SettingsManager(Stream fileStream)
        {
            _inputStream = fileStream;
            if (_inputStream != null)
            {
                _serializer = new XmlSerializer(typeof(T));
            }
        }

        /// <summary>
        /// Serializacja strumienia ustawień
        /// </summary>
        /// <param name="value">obiekt do zserializowania</param>
        /// <param name="serializeXml">zserializowany xml</param>
        /// <returns></returns>
        public bool Serialize(T value, ref string serializeXml)
        {
            if (value == null)
            {
                return false;
            }
            try
            {
                XmlWriter writer = XmlWriter.Create(_inputStream);

                _serializer.Serialize(writer, value);

                serializeXml = writer.ToString();

                writer.Close();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Deserializacja strumienia ustawień
        /// </summary>
        /// <returns></returns>
        public List<T> Deserialize()
        {
            try
            {
                //StringReader stringReader = new StringReader(serializeXml.ToString());
                XmlReader reader = XmlReader.Create(_inputStream);

                var data = _serializer.Deserialize(reader);
                reader.Close();

                if (data is List<T>)
                    return (List<T>)data;

                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }
    }
}