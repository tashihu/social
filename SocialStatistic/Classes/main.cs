using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialStatistic.Classes
{
    public class main
    {
    }
    
    //***** сбор данных
    //данные(соц сеть)
    interface Idata2 { }
    //сервис для скачки данных
    class VKService2 : Idata2 { }
    //сбор данных в одном месте
    class agregator2 { }
    //сохранение данных
    class users2 : IUserRepository2 { }
    class proccessor2 { //???????
    }
    //***** создание отчетов
    //загрузка данных 
    // - users.load();
    //генерация отчетов
    class analyzer2 { }
    //вывод в UI
    // - chart;
    //тип данных (users)
    interface IUserRepository2 { }
}