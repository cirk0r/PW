using Android.OS;
using System;
using Android.Runtime;
using System.Xml.Serialization;

namespace PW.Models
{
    /// <summary>
    /// Model przypomnienia
    /// </summary>
    [XmlRoot(ElementName="reminder")]
    public class ReminderModel : Java.Lang.Object, IParcelable
    {
        /// <summary>
        /// Identyfikator przypomnienia
        /// </summary>
        [XmlElement(ElementName = "id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Data telefonu
        /// </summary>
        [XmlElement(ElementName = "issueDate")]
        public DateTime DateOfIssue { get; set; }

        /// <summary>
        /// Dodatkowe informacje
        /// </summary>
        [XmlElement(ElementName = "additionalInfo")]
        public string AdditionalInfo { get; set; }

        /// <summary>
        /// Numer telefonu
        /// </summary>
        [XmlElement(ElementName = "phoneNumber")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Czy wykonano połączenie
        /// </summary>
        [XmlElement(ElementName = "callDone")]
        public bool CallDone { get; set; }

        /// <summary>
        /// IParcelable member
        /// </summary>
        /// <returns></returns>
        public int DescribeContents()
        {
            return 0;
        }

        /// <summary>
        /// IParcelable member
        /// </summary>
        /// <param name="dest"></param>
        /// <param name="flags"></param>
        public void WriteToParcel(Parcel dest, [GeneratedEnum] ParcelableWriteFlags flags)
        {
            dest.WriteString(this.DateOfIssue.ToString());
            dest.WriteString(this.Id.ToString());
            dest.WriteString(this.AdditionalInfo);
            dest.WriteString(this.PhoneNumber);
        }
    }
}