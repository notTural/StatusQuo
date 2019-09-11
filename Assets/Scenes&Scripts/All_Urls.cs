﻿/**
 * 
 * This class will be used for all urls and some kinda texts
 * 
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class All_Urls
{
    public static bool val = true;//true -->  Global ; false -->  Local

    public static generalUrls getUrl(string strng="unchanged")//can be modified from other sources
    {
        if (strng.Equals("global"))
            val = true;
        else if (strng.Equals("local"))
            val = false;
#if !UNITY_EDITOR && (UNITY_ANDROID || UNITY_IOS)
        val = true;
#endif
        generalUrls urls = new generalUrls();
        if (val)//Global Urls will be used
        {
            urls.login = globalUrls.login;
            urls.register = globalUrls.register;
            urls.fbregister = globalUrls.fbregister;
            urls.gregister = globalUrls.gregister;
            urls.store = globalUrls.store;
            urls.userResource = globalUrls.userResource;
            urls.userBuildings = globalUrls.userBuildings;
            urls.setUserBuildings = globalUrls.setUserBuildings;
            urls.getUserTimeLineInfo = globalUrls.getUserTimeLineInfo;


        }
        else//Local Urls Will be used
        {
            urls.login = localUrls.login;
            urls.register = localUrls.register;
            urls.fbregister = localUrls.fbregister;
            urls.gregister = localUrls.gregister;
            urls.store = localUrls.store;
            urls.userResource = localUrls.userResource;
            urls.userBuildings = localUrls.userBuildings;
            urls.setUserBuildings = localUrls.setUserBuildings;
            urls.getUserTimeLineInfo = localUrls.getUserTimeLineInfo;

        }
        return urls;
    }

    //Global Urls
    [SerializeField]
    public class globalUrls
    {
        //scene:Login
        public static string login = "http://anar.labproxy.com/api/login";

        //scene:Register
        public static string register = "http://anar.labproxy.com/api/register";
        public static string fbregister = "http://anar.labproxy.com/login/facebook";
        public static string gregister = "http://anar.labproxy.com/login/google";

        //scene:GAME
        public static string store = "http://anar.labproxy.com/getStoreBuildings";
        public static string userResource = "http://anar.labproxy.com/getUserInfo";
        public static string userBuildings = "http://anar.labproxy.com/getbuildings";
        public static string setUserBuildings = "http://anar.labproxy.com/setUserBuildings ";
        public static string getUserTimeLineInfo = "http://anar.labproxy.com/getUserTimeLineInfo";
    }
    //Local URLS
    [SerializeField]
    public class localUrls
    {
        //scene:Login
        public static string login = "http://statusco.test/api/login";

        //scene:Register
        public static string register = "http://statusco.test/api/register";
        public static string fbregister = "http://statusco.test/login/facebook";
        public static string gregister = "http://statusco.test/login/google";

        //scene:GAME
        public static string store = "http://statusco.test/getStoreBuildings";
        public static string userResource = "http://statusco.test/getUserInfo";
        public static string userBuildings = "http://statusco.test/getbuildings";
        public static string setUserBuildings = "http://statusco.test/setUserBuildings ";
        public static string getUserTimeLineInfo = "http://statusco.test/getUserTimeLineInfo";

    }

    [SerializeField]
    public class generalUrls
    {
        //scene:Login
        public string login = string.Empty;

        //scene:Register
        public string register = string.Empty;
        public string fbregister = string.Empty;
        public string gregister = string.Empty;

        //scene:GAME
        public string store = string.Empty;
        public string userResource = string.Empty;
        public string userBuildings = string.Empty;
        public string setUserBuildings = string.Empty;
        public string getUserTimeLineInfo = string.Empty;


    }
}
