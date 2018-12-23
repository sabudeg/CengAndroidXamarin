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
using FFImageLoading;
using FFImageLoading.Views;
using Square.Picasso;

namespace CengAndroid
{
    [Activity(Label = "KisilerActivity")]
    public class KisilerActivity : Activity, BottomNavigationView.IOnNavigationItemSelectedListener
    {

        public List<Person> People = new List<Person>();
        public ListView mListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Kisiler);

            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);

            mListView = FindViewById<ListView>(Resource.Id.myListView);

            People.Add(new Person("Dr.Öğr.Üyesi Ahmet ARSLAN", "Mail: aarslan2@anadolu.edu.tr", "+90 (222) 321 35 50 / 6553", "http://ceng.eskisehir.edu.tr/img/aarslan2.jpg"));
            People.Add(new Person("Dr.Öğr.Üyesi Ahmet ARSLAN", "Mail: aarslan2@anadolu.edu.tr", "+90 (222) 321 35 50 / 6553", "http://ceng.eskisehir.edu.tr/img/aarslan2.jpg"));
            People.Add(new Person("Dr.Öğr.Üyesi Ahmet ARSLAN", "Mail: aarslan2@anadolu.edu.tr", "+90 (222) 321 35 50 / 6553", "http://ceng.eskisehir.edu.tr/img/aarslan2.jpg"));
            People.Add(new Person("Dr.Öğr.Üyesi Ahmet ARSLAN", "Mail: aarslan2@anadolu.edu.tr", "+90 (222) 321 35 50 / 6553", "http://ceng.eskisehir.edu.tr/img/aarslan2.jpg"));

            MyListViewAdapter adapter = new MyListViewAdapter(this, People);

            mListView.Adapter = adapter;

        }

        void onSendMailClick(object sender, EventArgs e)
        {
            var subject = new Intent(this, typeof(SendMailActivity));

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


        public class Person
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string ImageSource { get; set; }

            public Person(string name, string email, string phone, string imageSource)
            {
                Name = name;
                Email = email;
                Phone = phone;
                ImageSource = imageSource;
            }
        }

        class MyListViewAdapter : BaseAdapter<Person>
        {
            public List<Person> mItems;
            private Context mContext;

            public MyListViewAdapter(Context context, List<Person> items)
            {
                this.mItems = items;
                this.mContext = context;
            }

            public override Person this[int position]
            {
                get { return mItems[position]; }
            }

            public override int Count
            {
                get { return mItems.Count; }
            }

            public override long GetItemId(int position)
            {
                return position;
            }

            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                View row = convertView;

                if (row == null)
                {
                    row = LayoutInflater.From(mContext).Inflate(Resource.Layout.Kisiler, null, false);
                }

                TextView PersonName = row.FindViewById<TextView>(Resource.Id.PersonName);
                PersonName.Text = mItems[position].Name;

                TextView PersonEmail = row.FindViewById<TextView>(Resource.Id.PersonEmail);
                PersonEmail.Text = mItems[position].Email;

                TextView PersonPhone = row.FindViewById<TextView>(Resource.Id.PersonPhone);
                PersonPhone.Text = mItems[position].Phone;

                return row;
            }
        }



    }


}