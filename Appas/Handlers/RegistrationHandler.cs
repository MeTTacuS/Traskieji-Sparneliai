﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using RestSharp;


namespace Appas.Handlers
{
    class RegistrationHandler
    {
        private static RestClient _client = new RestClient("http://localhost:51237/");
        public static Context context;

        public int Register(string username, string password, string repeatPassword)
        {
            var request = new RestRequest("api/registration", Method.POST);
            RegistrationModel newUser = new RegistrationModel();
            newUser.username = username;
            newUser.password = password;
            newUser.repeatedPassword = repeatPassword;

            string json = JsonConvert.SerializeObject(newUser, Formatting.None);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse response = _client.Execute(request);

            if (!response.IsSuccessful)
                return 0;
            else
            {
                return 1;
            }
        }
    }
}