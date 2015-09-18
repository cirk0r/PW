using Android.App;
using Android.OS;
using Android.Views;

namespace PW
{
    internal class HistoryFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.Main, container, false);

            return view;
        }
    }
}