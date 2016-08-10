using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialStatistic.Classes
{
    public interface IUserRepository
    {
        Dictionary<String, User> GetUserList();
        int count();
        User Get(string id);
        void Add(User item);
        void Update(User item);
        void Delete(User item);
        void Clear();
        //void Save();
        //void Load(string time);
    }
}
