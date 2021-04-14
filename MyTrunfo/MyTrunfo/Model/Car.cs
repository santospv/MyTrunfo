using MyTrunfo.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MyTrunfo.Model
{
    public class Car
    {
        public Int32 Id { get; set; }
        public String Code { get; set; }
        public String Name { get; set; }
        public String Brand { get; set; }
        public ECountry Country { get; set; }
        public Image Image { get; set; }
        public Decimal Consumption { get; set; }
        public Int32 HorsePower { get; set; }
        public Int32 Length { get; set; }
        public Int32 MaxSpeed { get; set; }
        public Int32 Displacements { get; set; }
        public Int32 Price { get; set; }
    }
}
