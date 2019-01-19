using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OfakimAPI.Models;

namespace OfakimAPI.App_Code
{
    public class Utils
    {
        public static string ToJson<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T ToObject<T>(string json)
        {
            try
            {
                T result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
            catch 
            {
                return default(T);
            }
        }

        public struct AppSettingsKeys
        {
            public static string FileName = "FilePath"; 
        }

        internal static int? GetLastId(List<UserEntity> users)
        {
            var lastId = (from UserEntity u in users
                          orderby u.Id descending
                          select u).FirstOrDefault();
            if (lastId != null)
                return lastId.Id ;

            return 0;
        }
    }
}