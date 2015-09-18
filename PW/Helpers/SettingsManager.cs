using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace PW.Helpers
{
    public class SettingsManager<T> where T : class
    {
        private XmlSerializer _serializer;
        private Stream _inputStream;

        public SettingsManager(Stream fileStream)
        {
            _inputStream = fileStream;
            if (_inputStream != null)
            {
                _serializer = new XmlSerializer(typeof(T));
            }
        }

        public SettingsManager(string filePath)
        {
            _inputStream = new FileStream(filePath, FileMode.OpenOrCreate);
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
        public bool Serialize(List<T> value, ref string serializeXml)
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
        /// <returns>lista przypomnień</returns>
        public List<T> Deserialize()
        {
            try
            {
                StreamReader sr = new StreamReader(_inputStream);
                XmlTextReader xtr = new XmlTextReader(sr);

                var data = _serializer.Deserialize(xtr);
                sr.Close();

                if (data is List<T>)
                    return (List<T>)data;

                return new List<T>();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return new List<T>();
            }
        }
    }
}