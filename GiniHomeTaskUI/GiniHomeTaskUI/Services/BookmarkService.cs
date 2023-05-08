using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace GiniHomeTaskUI.Services
{
    public static class BookmarkService
    { 

        public static void SetBookmark(string key,string value)
        {
            HttpService.PostRequest($"/api/bookmark/{key}", value);
        }

        public static string GetBookmarks(string key)
        {
             return HttpService.GetRequest($"/api/bookmark/{key}").ToString();
            
        }
    }
}
