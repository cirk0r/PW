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
using PW.Adapters;
using PW.Fragments;

namespace PW
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, ActionBar.ITabListener
    {
        Button addReminderButton;
        Button myRemindersButton;
        Button callHistoryButton;
        static readonly List<string> phoneNumbers = new List<string>();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            AddTab("Lista", Resource.Drawable.list, new MyListFragment());
            AddTab("Nowe", Resource.Drawable.add, new AddReminderFragment());
            AddTab("Historia", Resource.Drawable.list, new HistoryFragment());
            
            //callHistoryButton = FindViewById<Button>(Resource.Id.historyButton);
            //myRemindersButton = FindViewById<Button>(Resource.Id.myRemindersButton);
            //addReminderButton = FindViewById<Button>(Resource.Id.addReminderButton);

            //callHistoryButton.Click += CallHistoryButton_Click;
            //myRemindersButton.Click += MyRemindersButton_Click;
            //addReminderButton.Click += AddReminderButton_Click;
        }

        void AddTab(string tabText, int iconResourceId, Fragment fragment)
        {
            var tab = this.ActionBar.NewTab();
            tab.SetText(tabText);
            tab.SetIcon(iconResourceId);

            // must set event handler for replacing tabs tab
            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e) {
                e.FragmentTransaction.Replace(Resource.Id.fragmentContainer, fragment);
            };

            this.ActionBar.AddTab(tab);
        }

        public void OnTabReselected(ActionBar.Tab tab, FragmentTransaction ft)
        {
            this.RunOnUiThread(() =>
            {
                Toast.MakeText(this, "OnTabReselected " + tab.Text, ToastLength.Long).Show();
            });
        }

        public void OnTabSelected(ActionBar.Tab tab, FragmentTransaction ft)
        {
            this.RunOnUiThread(() =>
            {
                Toast.MakeText(this, "OnTabSelected " + tab.Text, ToastLength.Long).Show();
            });
        }

        public void OnTabUnselected(ActionBar.Tab tab, FragmentTransaction ft)
        {
            this.RunOnUiThread(() =>
            {
                Toast.MakeText(this, "OnTabUnselected " + tab.Text, ToastLength.Long).Show();
            });
        }

        #region Events
        //private void AddReminderButton_Click(object sender, EventArgs e)
        //{
        //    var intent = new Intent(this, typeof(AddReminderActivity));
        //    StartActivityForResult(intent, 0);
        //}

        //private void MyRemindersButton_Click(object sender, EventArgs e)
        //{
        //    var intent = new Intent(this, typeof(MyRemindersActivity));
        //    StartActivity(intent);
        //}

        //private void CallHistoryButton_Click(object sender, EventArgs e)
        //{
        //    var intent = new Intent(this, typeof(CallHistoryActivity));
        //    intent.PutStringArrayListExtra("phoneNumbers", phoneNumbers);
        //    StartActivity(intent);
        //}

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

