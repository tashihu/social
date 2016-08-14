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
        Dictionary<String, User> _Users = UserReposytory.Instance.GetUserList();
        public string getcount()
        {
            return _Users.Count.ToString();
        }
        public string[] GetSexStatistics()
        {
            int male = 0, female = 0, hide = 0;      
            
            foreach(KeyValuePair<String,User> user in _Users)
            {
                switch (user.Value.sex)
                {
                    case "male": male++; break;
                    case "female": female++; break;
                    case "hide": hide++;  break;
                }                
            }
            string[] output ={male.ToString(), female.ToString(),hide.ToString()};
            return output;            
        }
        public Dictionary<string, int> GetAgeStatistics()
        {
            Dictionary<string, int> ageStats = new Dictionary<string, int>();
            foreach (KeyValuePair<String, User> user in _Users)
            {
                if (ageStats.ContainsKey(user.Value.age)) { ageStats[user.Value.age]++; }
                else { ageStats[user.Value.age] = 1; }
            }            
            return ageStats;
        }
        public string test()
        {
            string output = "";
            foreach (KeyValuePair<String, User> user in _Users)
            {
                //output += string.Format("id = {0}, name = {1}, bdate = {2}, sex = {3} ,", user.Value.uid,user.Value.,user.Value.age,user.Value.sex);
            }
            return output;
        }
    }
}