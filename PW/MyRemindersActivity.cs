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
using PW.Models;

namespace PW
{
    [Activity(Label = "MyRemindersActivity")]
    public class MyRemindersActivity : ListActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here
            var reminders = Intent.Extras.Get("reminders").ToArray<ReminderModel>() ?? new ReminderModel[0];
            this.ListAdapter = new ArrayAdapter<ReminderModel>(this, Android.Resource.Layout.SimpleListItem1, reminders);
        }
    }
}