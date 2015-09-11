using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using PW.Helpers;
using PW.Models;

namespace PW
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button addReminderButton;
        Button myRemindersButton;
        Button callHistoryButton;
        static readonly List<string> phoneNumbers = new List<string>();
        ActivityCreator activityCreator;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            activityCreator = new ActivityCreator();

            callHistoryButton = FindViewById<Button>(Resource.Id.historyButton);
            myRemindersButton = FindViewById<Button>(Resource.Id.myRemindersButton);
            addReminderButton = FindViewById<Button>(Resource.Id.addReminderButton);

            callHistoryButton.Click += CallHistoryButton_Click;
            myRemindersButton.Click += MyRemindersButton_Click;
            addReminderButton.Click += AddReminderButton_Click;
        }

        #region Events
        private void AddReminderButton_Click(object sender, EventArgs e)
        {
            //activityCreator.CreateActivity<AddReminderActivity>(this);
            var intent = new Intent(this, typeof(AddReminderActivity));
            StartActivityForResult(intent, 0);
        }

        private void MyRemindersButton_Click(object sender, EventArgs e)
        {
            //activityCreator.CreateActivity<MyRemindersActivity>(this, "reminders", new List<ReminderModel>());
            var intent = new Intent(this, typeof(MyRemindersActivity));
            intent.PutParcelableArrayListExtra("reminders", ((IList<IParcelable>)(new List<ReminderModel>())));
            StartActivity(intent);
        }

        private void CallHistoryButton_Click(object sender, EventArgs e)
        {
            //activityCreator.CreateActivity<CallHistoryActivity>(this, "phoneNumbers", phoneNumbers);
            var intent = new Intent(this, typeof(CallHistoryActivity));
            intent.PutStringArrayListExtra("phoneNumbers", phoneNumbers);
            StartActivity(intent);
        }

        //private void CallButton_Click(object sender, EventArgs e)
        //{
        //    var callDialog = new AlertDialog.Builder(this);
        //    callDialog.SetMessage("Zadzwonić na " + translatedNumber + "?");
        //    callDialog.SetNegativeButton("Anuluj", delegate { });
        //    callDialog.SetNeutralButton("Zadzwoń", delegate
        //    {
        //        phoneNumbers.Add(translatedNumber);
        //        callHistoryButton.Enabled = phoneNumbers.Count > 0;
        //        var intent = new Intent(Intent.ActionCall);
        //        intent.SetData(Android.Net.Uri.Parse("tel:" + translatedNumber));
        //        StartActivity(intent);
        //    });

        //    callDialog.Show();
        //}

        //private void TranslateButton_Click(object sender, EventArgs e)
        //{
        //    translatedNumber = PW.Helpers.PhonewordTranslator.ToNumber(textNumber.Text);

        //    callButton.Text = string.IsNullOrWhiteSpace(translatedNumber) ? "Zadzwoń" : "Zadzwoń na: " + translatedNumber;
        //    callButton.Enabled = !string.IsNullOrWhiteSpace(translatedNumber);
        //}

        #endregion

        
    }
}

