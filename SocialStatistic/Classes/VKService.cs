using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetOpenAuth;
using System.Net;
using System.IO;

namespace SocialStatistic.Classes
{
    public class VKService : IData
    {
        //class AccessToken
        //{
        //    public string access_token = null;
        //    public string user_id = null;
        //}
        //private string appId = "5582218";
        //private string appSecret = "Gt1uKaF1Wfajb8FyE4jH";       
        public class Response
        {
            public groupuserslist response { get; set; }
        }
        public class groupuserslist 
        {
            public String count { get; set; }
            public String[] users { get; set; }
        }
        Random rand = new Random((int)DateTime.Now.Millisecond);

        public String[] GetUsersId(string source)
        {
            string jsonIds = Load("https://api.vk.com/method/groups.getMembers?group_id="+source);
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            Response resp = serializer.Deserialize<Response>(jsonIds);
            return resp.response.users;
        }
        public User GetUserData(string id)
        {
            // load data from VK API
            string jsonIds = Load("https://api.vk.com/method/users.get?user_ids=" + id + "&fields=photo_id,verified,sex,bdate,city,country,home_town,has_photo,online,lists,has_mobile,timezone");//
            // convert Json to DATA object
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            VKUserInfoResponse resp = serializer.Deserialize<VKUserInfoResponse>(jsonIds);

            User user = new User();
            //convert DATA object to user info object
            user = ConvertToUser(resp.response[0]);  
            return user;
        }
        /// <summary>
        ///  convert DATA object to user info object
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private User ConvertToUser(vkuser info)
        {
            User user = new User();
            user.uid = info.uid;
            user.bdate = info.bdate;
            switch (info.sex) {
                case "1":user.sex="male";break;
                case "2":user.sex="female";break;               
                default: user.sex = "hide"; break;                
            }
            user.first_name = info.first_name;
            user.last_name = info.last_name;
            user.photo_id = info.photo_id;
            user.verified = info.verified;
            user.city = info.city;
            user.country = info.country;
            user.home_town = info.home_town;
            user.has_photo = info.has_photo;
            user.online = info.online;
            user.lists = info.lists;
            user.has_mobile = info.has_mobile;
            user.timezone = info.timezone;
            string year;
            if (info.bdate != null)
            {
                if (info.bdate.Split('.').Length == 3) { year = info.bdate.Split('.')[2]; user.age = (DateTime.Now.Year - Convert.ToInt32(year)).ToString(); }
                else { user.age = "hide"; }
            }
            else { user.age = "hide"; }
            return user;
        }
        private class VKUserInfoResponse
        {
            public vkuser[] response { get; set; }
        }
        public class vkuser
        {
            public String uid { get; set; }
            public String first_name { get; set; }
            public String last_name { get; set; }
            public String photo_id { get; set; }
            public String verified { get; set; }
            public String sex { get; set; }
            public String bdate { get; set; }
            public String city { get; set; }
            public String country { get; set; }
            public String home_town { get; set; }
            public String has_photo { get; set; }
            public String online { get; set; }
            public String lists { get; set; }
            public String has_mobile { get; set; }
            public String timezone { get; set; }
        }
        private String[] generateFakeUserId()
        {
            String[] output = new String[10];
            for (int i = 0; i < 10; i++)
            {
                output[i] = rand.Next(100000).ToString();
            }
            return output;
        }
        private User GenerateFakeUserData(string id)
        {
            User user = new User();
            user.first_name = "user_" + id.ToString();
            user.age = rand.Next(15, 100).ToString();
            user.sex = rand.Next(2).ToString();
            user.uid = id;

            return user;
        }
        private static string Load(string address)
        {
            var request = WebRequest.Create(address) as HttpWebRequest;
            using (var response = request.GetResponse() as HttpWebResponse)
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            }
        }
        public static T DeserializeJson<T>(string input)
        {
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Deserialize<T>(input);
        }
        private void login()
        {
           
           
                //var address = String.Format(
                //        "https://oauth.vk.com/access_token?client_id={0}&client_secret={1}&code={2}&redirect_uri={3}",
                //        this.appId, this.appSecret, "9993d08df3dd36995e", "localhost");
 
                //var response = Load(address);
                //var accessToken = DeserializeJson<AccessToken>(response);
            
                //return accessToken.access_token;
            
        }
        private void login1()
        {
            //var APP_ID = this.appId;
            //string redirectUri = "localhost";
            //var address = String.Format(
            //        "https://oauth.vk.com/authorize?client_id=5582218&redirect_uri=localhost&response_type=code",
            //        APP_ID, redirectUri
            //    );

            //HttpContext.Current.Response.Redirect(address, false);
        }
        public string login2()
        {
            //
            return Load("https://api.vk.com/method/users.get?user_ids=20382979&fields=photo_id,verified,sex,bdate,city,country,home_town,has_photo,online,lists,has_mobile,timezone");//&access_token=87ff0ca052260cb6643101c69050362cc54a8baf7c69e8404973d9a66d0c0335318f0abbe5f072c3b27e4
        }


    }
}
