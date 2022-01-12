using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMO_BIM_m1_lab19
{
    class Comp
    {
        public int Id_code { get; set; } //код
        public string Brand { get; set; } //марка
        public string Cpu_socket { get; set; } //тип процессора
        public int Cpu_freq { get; set; } //частота процессора
        public int Ram_size { get; set; } //объем оп.памяти 
        public int Hdd_size { get; set; } //объем жесткого диска
        public int Vcard_ram_size { get; set; } //объем памяти видеокарты
        public decimal Price { get; set; } //цена
        public int Qty { get; set; } //кол-во в наличии, шт

        public string GetInfo()
        {
            return $"{Id_code}  Марка:{Brand}  Тип ЦП:{Cpu_socket}  Частота ЦП:{Cpu_freq}  ОЗУ:{Ram_size}Гб  Диск:{Ram_size}Гб  Видеокарта:{Vcard_ram_size}Гб  {Price}руб  Наличие - {Qty}шт.";
        }
    }
}
