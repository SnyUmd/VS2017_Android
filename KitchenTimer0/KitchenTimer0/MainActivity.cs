using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using System.Threading;

namespace KitchenTimer0
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Timer _Timer;

        private int _remaining_mSec = 0;
        private bool _isStart = false;


        //***************************************************************
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var Btn10m = FindViewById<Button>(Resource.Id.Button10m);
            Btn10m.Click += Btn10m_Click1;

            var Btn1m = FindViewById<Button>(Resource.Id.Button1m);
            Btn1m.Click += Btn1m_Click;

            var Btn10s = FindViewById<Button>(Resource.Id.Button10s);
            Btn10s.Click += Btn10s_Click;

            var Btn1s = FindViewById<Button>(Resource.Id.Button1s);
            Btn1s.Click += Btn1s_Click;

            var BtnClear = FindViewById<Button>(Resource.Id.ButtonClear);
            BtnClear.Click += BtnClear_Click;

            var BtnStart = FindViewById<Button>(Resource.Id.ButtonStart);
            BtnStart.Click += BtnStart_Click;

            _Timer = new Timer(Timer_OnTick, null, 0, 1000);
        }


        //***************************************************************
        public void Timer_OnTick(object state)
        {
            if (_isStart)
            {
                _remaining_mSec -= 1000;
                RefreshTimeText(_remaining_mSec);

                if (_remaining_mSec <= 0)
                {
                    _isStart = false;
                    FindViewById<Button>(Resource.Id.ButtonStart).Text = "start";
                    //FindViewById<Button>(Resource.Id.ButtonClear).Enabled = true;
                }
            }
        }

        #region Button処理
        //***************************************************************
        private void BtnStart_Click(object sender, EventArgs e)
        {
            switch (_isStart)
            {
                case false:
                    if (_remaining_mSec > 0)
                    {
                        FindViewById<Button>(Resource.Id.ButtonStart).Text = "stop";
                        //FindViewById<Button>(Resource.Id.ButtonClear).Enabled = false;
                    }
                    break;
                case true:
                    FindViewById<Button>(Resource.Id.ButtonStart).Text = "start";
                    //FindViewById<Button>(Resource.Id.ButtonClear).Enabled = true;
                    break;
            }
            _isStart = !_isStart;


        }

        //***************************************************************
        private void BtnClear_Click(object sender, EventArgs e)
        {
            _remaining_mSec = 0;
            RefreshTimeText(_remaining_mSec);
        }

        //***************************************************************
        private void Btn10m_Click1(object sender, EventArgs e)
        {
            _remaining_mSec += 600 * 1000;
            RefreshTimeText(_remaining_mSec);
        }

        //***************************************************************
        private void Btn1m_Click(object sender, EventArgs e)
        {
            _remaining_mSec += 60 * 1000;
            RefreshTimeText(_remaining_mSec);
        }

        //***************************************************************
        private void Btn10s_Click(object sender, EventArgs e)
        {
            _remaining_mSec += 10 * 1000;
            RefreshTimeText(_remaining_mSec);
        }

        //***************************************************************
        private void Btn1s_Click(object sender, EventArgs e)
        {
            _remaining_mSec += 1 * 1000;
            RefreshTimeText(_remaining_mSec);
        }

        //***************************************************************
        private void RefreshTimeText(int time_mSec)
        {
            var sec = time_mSec / 1000;
            //int min = 
            FindViewById<TextView>(Resource.Id.TextViewTime).Text =
                                string.Format("{0:d2}:{1:d2}", sec / 60, sec % 60);
        }
        #endregion

        //***************************************************************
        //***************************************************************
        //***************************************************************


    }
}