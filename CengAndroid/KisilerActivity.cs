using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;

namespace CengAndroid
{
    [Activity(Label = "KisilerActivity")]
    public class KisilerActivity : Activity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Kisiler);

            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);
            // Create your application here
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.navigation_about:
                    StartActivity(typeof(MainActivity));
                    return true;
                case Resource.Id.navigation_kisiler:
                    StartActivity(typeof(KisilerActivity));
                    return true;
                case Resource.Id.navigation_notifications:
                    StartActivity(typeof(MainActivity));
                    return true;
            }
            return false;
        }
    }
}