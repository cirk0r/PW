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
using PW.Services;

namespace PW.Receivers
{
    public class NotifierReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            Intent receiveIntent = new Intent(context, typeof(NotifierService));
            context.StartService(receiveIntent);
        }
    }
}