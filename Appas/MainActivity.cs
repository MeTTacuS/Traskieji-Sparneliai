﻿using System;
using Android;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using SupportFragment = Android.Support.V4.App.Fragment;

namespace Appas
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = false)]
    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        private Fragments.DemoFragment demo;
        private Fragments.DemoFragment2 demo2;
        private Fragments.PersonFragment person;
        private SupportFragment currentFragment;

        private void ShowFragment(SupportFragment fragment)
        {
            if (fragment.IsVisible)
            {
                return;
            }

            var transaction = SupportFragmentManager.BeginTransaction();
            transaction.SetCustomAnimations(Resource.Animation.slide_in, Resource.Animation.slide_out, Resource.Animation.slide_in, Resource.Animation.slide_out);
            transaction.Hide(currentFragment);
            transaction.Show(fragment);
            transaction.Commit();
            currentFragment = fragment;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);

            var transaction = SupportFragmentManager.BeginTransaction();
            demo = new Fragments.DemoFragment();
            demo2 = new Fragments.DemoFragment2();
            person = new Fragments.PersonFragment();
            currentFragment = demo;

            transaction.Add(Resource.Id.fragment_container, demo, "demo");
            transaction.Add(Resource.Id.fragment_container, demo2, "demo2");
            transaction.Add(Resource.Id.fragment_container, person, "person");
            transaction.Hide(demo2);
            transaction.Hide(person);
            transaction.Commit();
        }

        public override void OnBackPressed()
        {
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            if(drawer.IsDrawerOpen(GravityCompat.Start))
            {
                drawer.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                base.OnBackPressed();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;

            if (id == Resource.Id.nav_camera)
            {
                StartActivity(typeof(GalleryActivity));
                //ShowFragment(demo);
            }
            else if (id == Resource.Id.nav_gallery)
            {
                ShowFragment(demo2);
            }
            else if (id == Resource.Id.nav_slideshow)
            {
                ShowFragment(person);
            }
            else if (id == Resource.Id.nav_manage)
            {
                ShowFragment(person);
            }
            else if (id == Resource.Id.nav_share)
            {
                ShowFragment(person);
            }
            else if (id == Resource.Id.nav_send)
            {
                ShowFragment(person);
            }

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }
    }
}

