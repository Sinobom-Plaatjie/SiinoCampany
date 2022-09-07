﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SiinoCampany.Services
{
    public class AppConfigurationService
    {
        static AppConfigurationService _instance;

        public static AppConfigurationService Instance =>
            _instance ?? (_instance = new AppConfigurationService());

        public string SinoCampanyServerUrl { get; set; }

        public AppConfigurationService()
        {
#if LOCALSERVER
            SinoCampanyServerUrl = "https://10.0.2.2:7052/";
#else
            SinoCampanyServerUrl = "https://localhost:7052";
#endif

        }
    }
}
