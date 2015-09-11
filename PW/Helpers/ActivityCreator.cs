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
using Java.IO;
using PW.Models;

namespace PW.Helpers
{
    public class ActivityCreator : Activity
    {
        public void CreateActivity<T>(Activity parent)
        {
            var intent = new Intent(parent, typeof(T));
            StartActivityForResult(intent, 0);
        }

        public void CreateActivity<T>(Activity parent, string name, IList<string> extras)
        {
            var intent = new Intent(parent, typeof(T));
            intent.PutStringArrayListExtra(name, extras);
            StartActivity(intent);
        }

        public void CreateActivity<T>(Activity parent, string name, IList<ReminderModel> extras)
        {
            var intent = new Intent(parent, typeof(T));
            intent.PutParcelableArrayListExtra(name, (IList<IParcelable>)extras);
            StartActivity(intent);
        }
    }
}