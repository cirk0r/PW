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

namespace PW.Adapters
{
    public class ReminderListAdapter : BaseAdapter<ReminderModel>
    {
        Activity context;
        List<ReminderModel> list;

        public ReminderListAdapter(Activity _context, List<ReminderModel> _list)
            : base()
        {
            context = _context;
            list = _list;
        }

        public override int Count
        {
            get { return list.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override ReminderModel this[int index]
        {
            get { return list[index]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;

            // re-use an existing view, if one is available
            // otherwise create a new one
            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.ReminderView, parent, false);

            ReminderModel item = this[position];
            view.FindViewById<TextView>(Resource.Id.Title).Text = item.PhoneNumber;
            view.FindViewById<TextView>(Resource.Id.Description).Text = item.AdditionalInfo;

            using (var imageView = view.FindViewById<ImageView>(Resource.Id.Thumbnail))
            {
                //string url = Android.Text.Html.FromHtml(item.thumbnail).ToString();
            }
            return view;
        }
    }
}