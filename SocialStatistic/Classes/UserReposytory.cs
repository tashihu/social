using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialStatistic.Classes
{
    /// <summary>
    /// CRUD user repository
    /// </summary>
    public class UserReposytory : IUserRepository
    {
        private static readonly Lazy<UserReposytory> _instance = new Lazy<UserReposytory>(() => new UserReposytory());
        UserReposytory() { }
        public static UserReposytory Instance { get { return _instance.Value; } }


        private Dictionary<String, User> _users = new Dictionary<string, User>();
        public Dictionary<string, User> GetUserList()
        {
            return _users;
        }
        public User Get(string id)
        {
            return null;
        }
        public void Add(User item)
        {
            _users.Add(item.id, item);
        }
        public void Update(User item)
        {
            _users[item.id] = item;
        }
        public void Delete(User item)
        {
            _users.Remove(item.id);
        }
        public int count()
        {
            return _users.Count();
        }
        public void Clear()
        {
            _users.Clear();
        }
    }
}