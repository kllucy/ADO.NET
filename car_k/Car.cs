using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_k
{
    internal class Car
    {
        public int Id {get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public DateTime Date { get; set; }
        public decimal price { get; set; }
        public string print_info()
        {
            return $"Машина{brand}, {model} выпуск {Date} цена:{price} ";
        }


    }
}
