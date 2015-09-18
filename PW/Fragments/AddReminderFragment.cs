using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using PW.Helpers;
using PW.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace PW
{
    internal class AddReminderFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.AddReminder, container, false);
            var addReminderbutton = view.FindViewById<Button>(Resource.Id.addReminderButton);
            var datePicker = view.FindViewById<DatePicker>(Resource.Id.datePicker);

            datePicker.UpdateDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);

            addReminderbutton.Click += AddReminderbutton_Click;

            return view;
        }

        private void AddReminderbutton_Click(object sender, System.EventArgs e)
        {
            try
            {
                ReminderModel data = new ReminderModel()
                {
                    AdditionalInfo = View.FindViewById<EditText>(Resource.Id.phoneText).Text,
                    DateOfIssue = View.FindViewById<DatePicker>(Resource.Id.datePicker).DateTime,
                    PhoneNumber = View.FindViewById<EditText>(Resource.Id.phoneText).Text,
                    Id = Guid.NewGuid(),
                    CallDone = false
                };

                var path = Path.GetFullPath(string.Format("{0}\\{1}", AppDomain.CurrentDomain.BaseDirectory, "Assets\\Settings.xml"));

                if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
                {
                    SettingsManager<ReminderModel> manager = new SettingsManager<ReminderModel>(path);
                    List<ReminderModel> items = manager.Deserialize();
                    items.Add(data);
                    string xml = string.Empty;
                    bool result = manager.Serialize(items, ref xml);

                    Activity.RunOnUiThread(() =>
                    {
                        Toast.MakeText(Activity, "Dodano przypomnienie", ToastLength.Long).Show();
                    });

                }
                else
                {
                    Activity.RunOnUiThread(() =>
                    {
                        Toast.MakeText(Activity, "Nie odnaleziono pliku ustawień", ToastLength.Long).Show();
                    });
                }
            }
            catch (Exception ex)
            {
                Activity.RunOnUiThread(() =>
                {
                    Toast.MakeText(Activity, "Podczas dodawania przypomnienia wystąpił błąd: " + ex.Message, ToastLength.Long).Show();
                });
            }
        }
    }
}