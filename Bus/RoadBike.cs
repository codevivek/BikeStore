using MYBIKESS.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mybikes.Bus
{
    public class Roadbike : Bike
    {
        private double speed;
        private double seatheight;
        public double Seatheight { get => seatheight; set => seatheight = value; }
        public Roadbike() : base()
        {
            this.seatheight = 00;
        }
        public virtual double GetMaxSpeed()
        {
            double speed = 40;
            return speed;
        }
        public Roadbike(double seatheight, string biketype, long serialnum, double price, string brand,
            string model, EnumColor color, double speed, Date madedate) : base(serialnum,brand, model, color, speed, madedate) => this.Seatheight = seatheight;
        public override string ToString()
        {
            string stat;
            stat =  base.Serialnum + "     " +  base.Model + "    "
                + base.SpeedUp + "    " + Color + "    " + base.Madedate + "    " + "    " + "     " + seatheight;

            return stat;
        }
    }
}
