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

            //BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            //navigation.SetOnNavigationItemSelectedListener(this);

            mListView = FindViewById<ListView>(Resource.Id.myListView);

            People.Add(new Person("Dr.Öğr.Üyesi Ahmet ARSLAN", "Mail: aarslan2@anadolu.edu.tr", "+90 (222) 321 35 50 / 6553", "http://ceng.eskisehir.edu.tr/img/aarslan2.jpg"));
            People.Add(new Person("Prof.Dr. Yaşar HOŞCAN", "Mail: hoscan@anadolu.edu.tr", "+90 (222) 321 35 50 / 6558", "http://ceng.eskisehir.edu.tr/img/aarslan2.jpg"));
            People.Add(new Person("Assoc.Prof.Dr. Serkan GÜNAL", "Mail: serkangunal@anadolu.edu.tr", "+90 (222) 321 35 50 / 6567", "http://ceng.eskisehir.edu.tr/img/aarslan2.jpg"));
            People.Add(new Person("	Assoc.Prof.Dr. Cihan KALELİ", "Mail: ckaleli@anadolu.edu.tr", "+90 (222) 321 35 50 / 6564", "http://ceng.eskisehir.edu.tr/img/aarslan2.jpg"));

            MyListViewAdapter adapter = new MyListViewAdapter(this, People);

            mListView.Adapter = adapter;

            Button callBtn = FindViewById<Button>(Resource.Id.callButton);
            callBtn.Click += delegate {
                onCallClick();
            };

            Button mailBtn = FindViewById<Button>(Resource.Id.sendMail);
            mailBtn.Click += delegate {

                PopupMenu popup = new PopupMenu(this, mailBtn);
                popup.Inflate(Resource.Layout.popup);
                

                String chosenSubject;

                popup.MenuItemClick += (s, arg) =>
                {
                    chosenSubject = arg.Item.TitleFormatted.ToString();
                    onSendMailClick(chosenSubject);
                };

                popup.Show();
            };

        }

        void onSendMailClick(String cs)
        {

            // String mail = FindViewById<TextView>(Resource.Id.PersonEmail).Text;
            // Toast.MakeText(this, "Hello from " + mail, ToastLength.Long).Show();

            
            var emailinfo = FindViewById<TextView>(Resource.Id.PersonEmail);
            var send = FindViewById<Button>(Resource.Id.sendMail);

                Intent info = new Intent(this, typeof(SendMailActivity));
                info.PutExtra("emailInfo", emailinfo.Text.ToString().Substring(6));
                info.PutExtra("subjectInfo", cs);
                info.SetType("message/rfc822");
                StartActivity(info);
        }

        void onCallClick()
        {
            //sadece ilk call butonu çalışıyor
            //diğerlerine basınca tepki yok
            Toast.MakeText(this, "Phone number is: " + FindViewById<TextView>(Resource.Id.PersonPhone).Text, ToastLength.Long).Show();
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


