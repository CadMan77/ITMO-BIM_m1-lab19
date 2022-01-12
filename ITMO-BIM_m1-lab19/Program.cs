using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//1.Модель компьютера характеризуется кодом и названием марки компьютера, типом процессора, частотой работы процессора, объемом
//оперативной памяти, объемом жесткого диска, объемом памяти видеокарты, стоимостью компьютера в условных единицах и количеством
//экземпляров, имеющихся в наличии. Создать список, содержащий 6-10 записей с различным набором значений характеристик.

//Определить:
//-все компьютеры с указанным процессором. Название процессора запросить у пользователя;
//-все компьютеры с объемом ОЗУ не ниже, чем указано. Объем ОЗУ запросить у пользователя;
//-вывести весь список, отсортированный по увеличению стоимости;
//-вывести весь список, сгруппированный по типу процессора; ???
//-найти самый дорогой и самый бюджетный компьютер;
//-есть ли хотя бы один компьютер в количестве не менее 30 штук?

namespace ITMO_BIM_m1_lab19
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Comp> comps = new List<Comp>()
            {
            new Comp() { Id_code = 1235, Cpu_socket = "AM2", Brand = "Acer", Cpu_freq = 1000, Ram_size = 2, Hdd_size = 128, Vcard_ram_size = 1, Price = 100, Qty = 0 },
            new Comp() { Id_code = 1236, Cpu_socket = "SocketH2", Brand = "Intel", Cpu_freq = 1100, Ram_size = 4, Hdd_size = 256, Vcard_ram_size = 2, Price = 19999.99M, Qty = 1 },
            new Comp() { Id_code = 1237, Cpu_socket = "AM3+", Brand = "Asus", Cpu_freq = 2400, Ram_size = 16, Hdd_size = 1024, Vcard_ram_size = 8, Price = 100000, Qty = 3 },
            new Comp() { Id_code = 1238, Cpu_socket = "SocketH3", Brand = "Intel", Cpu_freq = 1600, Ram_size = 8, Hdd_size = 512, Vcard_ram_size = 4, Price = 65000, Qty = 5 },
            new Comp() { Id_code = 1234, Cpu_socket = "AM3", Brand = "AMD", Cpu_freq = 1600, Ram_size = 8, Hdd_size = 512, Vcard_ram_size = 6, Price = 74000, Qty = 11 },
            new Comp() { Id_code = 1233, Cpu_socket = "AM3", Brand = "AMD", Cpu_freq = 1600, Ram_size = 8, Hdd_size = 500, Vcard_ram_size = 4, Price = 49500, Qty = 31 },
            new Comp() { Id_code = 1232, Cpu_socket = "SocketH3", Brand = "Intel", Cpu_freq = 1600, Ram_size = 8, Hdd_size = 512, Vcard_ram_size = 4, Price = 55000, Qty = 29 },
            new Comp() { Id_code = 1231, Cpu_socket = "AM4", Brand = "AMD", Cpu_freq = 2500, Ram_size = 16, Hdd_size = 2048, Vcard_ram_size = 8, Price = 250000, Qty = 20 }
            };

            //string user_cpu = "SocketH3";
            Console.Write("Запрос №1. Введите необходимый тип процессора:\n\r\t"); //(!! В условиях задачи присутствует неоднозначность - тип процессора не эквивалентен его названию)
            string user_cpu_type = Console.ReadLine();
            List <Comp> comps1 = comps.Where(pc =>pc.Cpu_socket == user_cpu_type).ToList();
            Console.WriteLine("Результат:");
            foreach (Comp pc in comps1)
                Console.WriteLine("\t"+pc.GetInfo());

            Console.Write("\nЗапрос №2. Укажите минимальный объем ОЗУ:\n\r\t");
            int user_ram_size = Convert.ToInt32(Console.ReadLine());
            List<Comp> comps2 = comps.Where(pc => pc.Ram_size >= user_ram_size).ToList();
            Console.WriteLine("Результат:");
            foreach (Comp pc in comps2)
                Console.WriteLine("\t"+pc.GetInfo());

            Console.WriteLine("\nПеречень ПК (сортировка по цене):");
            List<Comp> comps3 = comps.OrderBy(pc=>pc.Price).ToList();
            foreach (Comp pc in comps3)
                Console.WriteLine("\t" + pc.GetInfo());

            Console.WriteLine("\nПеречень ПК (группировка по ЦП):"); // выполнено по мотивам просмотра вебинара№3!!
            IEnumerable<IGrouping<string, Comp>> comps4 = comps.GroupBy(pc => pc.Cpu_socket);
            foreach (IGrouping<string, Comp> gr in comps4)
            {
                Console.WriteLine($"\n{gr.Key}");
                foreach (Comp pc in gr)
                {
                    Console.WriteLine("\t" + pc.GetInfo());
                }
            }

            Console.WriteLine("\nСамый бюджетный ПК в БД:");
            Comp minPricePc = comps.First();
            Console.WriteLine("\t" + minPricePc.GetInfo());

            Console.WriteLine("\nСамый дорогой ПК в БД:");
            Comp maxPricePc = comps.Last();
            Console.WriteLine("\t" + maxPricePc.GetInfo());

            Console.Write($"\nЗапрос №3. Укажите необходимое кол-во (однотипных) компьютеров:\n\r\t");
            //int orderQty = 30;
            int orderQty = Convert.ToInt32(Console.ReadLine());
            bool enoughQty = comps.Any(pc => pc.Qty >= orderQty);
            Console.WriteLine($"\tВозможность поставки - {enoughQty}.");
            Console.ReadKey();
        }
    }
}
