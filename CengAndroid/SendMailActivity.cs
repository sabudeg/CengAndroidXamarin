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

namespace CengAndroid
{
    [Activity(Label = "SendMailActivity")]
    public class SendMailActivity : Activity
    {
        TextView chosenEmail;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SendMail);


            FindViewById<EditText>(Resource.Id.toSend).Text = Intent.GetStringExtra("emailInfo");
            FindViewById<EditText>(Resource.Id.subject).Text = Intent.GetStringExtra("subjectInfo");


            var subject = Intent.GetStringExtra("subjectInfo");
            var message = FindViewById<EditText>(Resource.Id.message);
            var send = FindViewById<Button>(Resource.Id.sendMailButton);

            send.Click += (s, e) =>
            {
                Intent email = new Intent(Intent.ActionSend);
                email.PutExtra(Intent.ExtraEmail, new String[]
                {
                     Intent.GetStringExtra("emailInfo").ToString()
                });
                email.PutExtra(Intent.ExtraSubject, subject);
                email.PutExtra(Intent.ExtraText, message.Text.ToString());
                email.SetType("message/rfc822");
                StartActivity(Intent.CreateChooser(email, "Send email via"));

            };

        }
    }
}