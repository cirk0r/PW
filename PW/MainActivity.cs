using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace PW
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        string translatedNumber = string.Empty;
        EditText textNumber;
        Button translateButton;
        Button callButton;
        Button callHistoryButton;
        static readonly List<string> phoneNumbers = new List<string>();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            textNumber = FindViewById<EditText>(Resource.Id.numberText);
            translateButton = FindViewById<Button>(Resource.Id.translateButton);
            callButton = FindViewById<Button>(Resource.Id.callButton);
            callHistoryButton = FindViewById<Button>(Resource.Id.button1);

            translateButton.Click += TranslateButton_Click;
            callButton.Click += CallButton_Click;
            callHistoryButton.Click += CallHistoryButton_Click;
        }

        private void CallHistoryButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(CallHistoryActivity));
            intent.PutStringArrayListExtra("phoneNumbers", phoneNumbers);
            StartActivity(intent);
        }

        private void CallButton_Click(object sender, EventArgs e)
        {
            var callDialog = new AlertDialog.Builder(this);
            callDialog.SetMessage("Zadzwonić na " + translatedNumber + "?");
            callDialog.SetNegativeButton("Anuluj", delegate { });
            callDialog.SetNeutralButton("Zadzwoń", delegate
            {
                phoneNumbers.Add(translatedNumber);
                callHistoryButton.Enabled = phoneNumbers.Count > 0;
                var intent = new Intent(Intent.ActionCall);
                intent.SetData(Android.Net.Uri.Parse("tel:" + translatedNumber));
                StartActivity(intent);
            });

            callDialog.Show();
        }

        private void TranslateButton_Click(object sender, EventArgs e)
        {
            translatedNumber = PW.Helpers.PhonewordTranslator.ToNumber(textNumber.Text);

            callButton.Text = string.IsNullOrWhiteSpace(translatedNumber) ? "Zadzwoń" : "Zadzwoń na: " + translatedNumber;
            callButton.Enabled = !string.IsNullOrWhiteSpace(translatedNumber);
        }
    }
}

