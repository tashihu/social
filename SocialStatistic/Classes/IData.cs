using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialStatistic.Classes
{
    interface IData
    {        
        /// <summary>
        ///  получение списка пользователей.
        /// </summary>
        /// <param name="source">Список пользователей. Для соц сетей название группы, для БД имя таблицы</param>
        /// <returns></returns>
         String[] GetUsersId(string source);

        /// <summary>
        /// получение данных об 1 пользователе.
        /// </summary>
        /// <param name="id">ИД записи пользователя</param>
        /// <returns>Все данные об 1 пользователе</returns> 
         User GetUserData(string id);
    }
}
