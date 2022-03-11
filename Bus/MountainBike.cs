using MYBIKESS.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mybikes.Bus
{
    [Serializable]
    public class Mountainbike : Bike
    {
        private double seatheight;
        public double Seatheight { get => seatheight; set => seatheight = value; }
        public Mountainbike() : base()
        {
            this.seatheight = 00;
        }
        public Mountainbike(double seatheight,long serialnum, string model,EnumColor color, double speed, Date madedate) : base(serialnum,model, age, color, speed, madedate) => this.Seatheight = seatheight;
        public override string ToString()
        {
            string stat;
            stat = base.Biketype + "\t    " + base.Sn + "     " + base.Brand + "    " + base.Model + "    "
                + base.Speed + "    " + base.Color + "    " + base.Style + "    " + base.Price +
                "    " + base.Madedate + "    " + "    " + "     " + seatheight;

            return stat;
        }

    }
}

