using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialStatistic.Classes
{
    public class VKService : IData
    {
        Random rand = new Random((int)DateTime.Now.Millisecond);
        public String[] GetUsersId(string source)
        {
            return generateFakeUserId();
        }
        public User GetUserData(string id)
        {
            return GenerateFakeUserData(id);
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
            user.name = "user_" + id.ToString();
            user.age = rand.Next(15,100).ToString();
            user.sex = rand.Next(2).ToString();
            user.id= id;   

            return user;
        }

    }
}