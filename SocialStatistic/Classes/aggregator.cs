using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialStatistic.Classes
{
    public class Aggregator
    {
        private Classes.IUserRepository _Users = UserReposytory.Instance;
        /// <summary>
        /// собирает данные в одно место ( IUserRepository )
        /// </summary>
        /// <param name="source">Группа соц сети</param>
        public void process(String source)
        {
            _Users.Clear();
            //создаем хранилище данных о пользователях
        
          //  if (0 == _Users.count() )
            {
                Load(source);
            }
        }
        //public void reprocess(String source)        
        //{
        //    _Users.Clear();
        //    Load(source);
        //}
        private void Load(String source)
        {
            //создаем сервис для работы с конкретной соц сетью
            IData Data = new VKService();
            //получаем список пользователей для сбора информации
            String[] UsersId = Data.GetUsersId(source);

            //запрашиваем информацию о каждом пользователе
            foreach (String Id in UsersId)
            {
                //добавляем в репозиторий информацию о каждом пользователе из списка
                _Users.Add(Data.GetUserData(Id));
            }
        }
    }
}