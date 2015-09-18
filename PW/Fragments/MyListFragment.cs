
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using PW.Adapters;
using PW.Models;
using System;
using System.Collections.Generic;

namespace PW.Fragments
{
    public class MyListFragment : ListFragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            var reminders = new List<ReminderModel> {
                new ReminderModel()
                {
                    DateOfIssue = DateTime.Now,
                    AdditionalInfo = "pilne",
                    Id = Guid.NewGuid(),
                    PhoneNumber = "666666666"
                }
            };

            ListAdapter = new ReminderListAdapter(Activity, reminders);
        }

        public override void OnListItemClick(ListView l, View v, int position, long id)
        {
            var selectedItem = ((ReminderModel)(l.Adapter.GetItem(position)));
            if (selectedItem != null)
            {
                var callDialog = new AlertDialog.Builder(Activity);
                callDialog.SetMessage("Zadzwonić na " + selectedItem.PhoneNumber + "?");
                callDialog.SetNegativeButton("Anuluj", delegate { });
                callDialog.SetNeutralButton("Zadzwoń", delegate
                {
                    var intent = new Intent(Intent.ActionCall);
                    intent.SetData(Android.Net.Uri.Parse("tel:" + selectedItem.PhoneNumber));
                    StartActivity(intent);
                });

                callDialog.Show();
            }
            else
            {
                Activity.RunOnUiThread(() => { Toast.MakeText(Activity.ApplicationContext, "Pusty wpis", ToastLength.Long).Show(); });
            }
        }
    }
}