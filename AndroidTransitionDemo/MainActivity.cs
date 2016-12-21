using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Content;
using Android.Util;

namespace AndroidTransitionDemo
{
    [Activity(Label = "AndroidTransitionDemo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        SearchView sv;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            sv = FindViewById<SearchView>(Resource.Id.searchView1);
            showProgressBar(sv, this);   
        }

        void showProgressBar(SearchView searchView, Context context)
        {
            int id = searchView.Context.Resources.GetIdentifier("android:id/search_plate", null, null);
            View searchPlate = searchView.FindViewById(id);

            if (searchView.FindViewById(id).FindViewById(Resource.Id.progressBar1) != null)
            {
                searchView.FindViewById(id).FindViewById(Resource.Id.progressBar1).Animate().SetDuration(200).Alpha(1).Start();
            }
            else
            {
                View v = LayoutInflater.From(context).Inflate(Resource.Layout.loading, null);
                ((ViewGroup)searchView.FindViewById(id)).AddView(v, 1);
            }
        }
    }
}

