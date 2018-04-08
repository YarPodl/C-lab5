using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    /// <summary>
    /// АТС
    /// </summary>
    class APS : AbstractAPS
    {
        /// <summary>
        /// 
        /// </summary>
        public APS(): base() { }
        public APS(String name) : base(name) { }
        public APS(String name, int number) : base(name, number) { }
        public APS(string name,
            int number,
            string addres,
            int countUsers,
            double usersPay,
            string tarif,
            int freeLines
            ) : base (name, number, addres, countUsers, usersPay, tarif, freeLines)  { }

        /// <summary>
        /// Возвращает имя
        /// </summary>
        /// <returns>Содержит имя объекта</returns>
        public override string ToString()
        {
            return name;
        }

        /// <summary>
        /// Возвращает все поля объекта
        /// </summary>
        /// <returns>Строка, содержащая значения всех полей</returns>
        public override String ToStringFull()
        {
            return "Название: "
                + name
                + "\nномер: "
                + number.ToString()
                + ", в шестнадцатиричной СС: "
                + Convert.ToString(number, 16)
                + "\nадрес: "
                + addres
                + "\nколичество пользователей: "
                + countUsers.ToString()
                + "\nАбонентская плата: "
                + usersPay.ToString()
                + "\nтариф: "
                + tarif
                + "\nсвободные линии: "
                + freeLines.ToString();
        }

    }
}
