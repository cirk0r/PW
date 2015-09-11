using Android.OS;
using System;
using Android.Runtime;

namespace PW.Models
{
    /// <summary>
    /// Model przypomnienia
    /// </summary>
    public class ReminderModel : Java.Lang.Object, IParcelable
    {
        /// <summary>
        /// Identyfikator przypomnienia
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Data telefonu
        /// </summary>
        public DateTime DateOfIssue { get; set; }

        /// <summary>
        /// Dodatkowe informacje
        /// </summary>
        public string AdditionalInfo { get; set; }

        /// <summary>
        /// Numer telefonu
        /// </summary>
        public string PhoneNumber { get; set; }

        public int DescribeContents()
        {
            return 0;
        }

        public void WriteToParcel(Parcel dest, [GeneratedEnum] ParcelableWriteFlags flags)
        {
            dest.WriteString(this.DateOfIssue.ToString());
            dest.WriteString(this.Id.ToString());
            dest.WriteString(this.AdditionalInfo);
            dest.WriteString(this.PhoneNumber);
        }
    }
}