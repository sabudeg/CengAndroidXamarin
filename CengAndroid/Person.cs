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
}