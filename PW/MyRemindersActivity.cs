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
using PW.Adapters;
using PW.Helpers;
using System.IO;

namespace PW
{
    [Activity(Label = "MyRemindersActivity")]
    public class MyRemindersActivity : ListActivity
    {
        SettingsManager<ReminderModel> settingsManager;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here
            var stream = Assets.Open("Settings.xml", Android.Content.Res.Access.Buffer);
            if (stream != null)
                settingsManager = new SettingsManager<ReminderModel>(stream);

            //var reminders = settingsManager.Deserialize();
            var reminders = new List<ReminderModel> {
                new ReminderModel()
                {
                    DateOfIssue = DateTime.Now,
                    AdditionalInfo = "pilne",
                    Id = Guid.NewGuid(),
                    PhoneNumber = "666666666"
                }
            };

            ListAdapter = new ReminderListAdapter(this, reminders);
        }
    }
}