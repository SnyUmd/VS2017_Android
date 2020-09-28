using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;

namespace KitchenTimer0
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //****************************************************************************************
            var Btn_10m = FindViewByld<Button>(Resource.Id.Button10m);
        }



        //****************************************************************************************
        private static object FindViewByld<T>(int button10m)
        {
            throw new NotImplementedException();
        }
    }


}