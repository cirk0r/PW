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
using Java.Lang;

namespace PW.Services
{
    public class NotifierService : Service
    {
        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public override void OnStart(Intent intent, int startId)
        {
            base.OnStart(intent, startId);
        }

        public override void OnCreate()
        {
            base.OnCreate();
        }
    }
}