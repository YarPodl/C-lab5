using System;

namespace lab5
{
    abstract class AbstractAPS
    {
        public String name { get; set; }     // Название АТС
        public int number { get; set; }      // Номер АТС
        public String addres { get; set; }   // Адрес
        public int countUsers { get; set; }  // Количество пользователей
        public double usersPay { get; set; } // Абонентская плата
        public String tarif { get; set; }    // Тариф
        public int freeLines { get; set; }   // Свободные линии

        public static int count = 0;    // Содержит количество объектов

        public AbstractAPS()
        {
            name = "";
            number = 0;
            addres = "";
            countUsers = 0;
            usersPay = 0;
            tarif = "";
            freeLines = 0;
            count++;
        }
        public AbstractAPS(String name)
        {
            this.name = name;
            number = 0;
            addres = "";
            countUsers = 0;
            usersPay = 0;
            tarif = "";
            freeLines = 0;
            count++;
        }
        public AbstractAPS(String name, int number)
        {
            this.name = name;
            this.number = number;
            addres = "";
            countUsers = 0;
            usersPay = 0;
            tarif = "";
            freeLines = 0;
            count++;
        }

        public AbstractAPS(string name, int number, string addres, int countUsers, double usersPay, string tarif, int freeLines)
        {
            this.name = name;
            this.number = number;
            this.addres = addres;
            this.countUsers = countUsers;
            this.usersPay = usersPay;
            this.tarif = tarif;
            this.freeLines = freeLines;
            count++;
        }
        /// <summary>
        /// Возвращает имя
        /// </summary>
        /// <returns>Содержит имя объекта</returns>
        public abstract override string ToString();
        /// <summary>
        /// Возвращает все поля объекта
        /// </summary>
        /// <returns>Строка, содержащая значения всех полей</returns>
        public abstract String ToStringFull();



        ~AbstractAPS()
        {
            count--;
        }
    }
}
