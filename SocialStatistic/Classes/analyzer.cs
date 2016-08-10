using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialStatistic.Classes
{
    /// <summary>
    /// анализ данных, подготовка отчетов
    /// </summary>
    public class Analyzer
    {
        public string[] GetSexStatistics()
        {
            int male = 0, female = 0;
            Dictionary<String, User> MyUsers = UserReposytory.Instance.GetUserList();
            
            foreach(KeyValuePair<String,User> user in MyUsers)
            {
                if (user.Value.sex == "0") { male++; } else { female++; }
            }
            string[] output ={male.ToString(), female.ToString()};
            return output;            
        }
    }
}