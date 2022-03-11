using Mybikes.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBIKESS.Bus
{
        public class Bike
        {
            private long serialnum;
            private string model;
            private EnumColor color;
            private double SpeedUp;
            private Date madedate;
       

        public int Serialnum { get => (int)serialnum; set => serialnum = value; }
        public string Model { get => model; set => model = value; }
        public EnumColor Color { get => color; set => color = value; }
        public string Madedate { get; internal set; }

        public virtual double GetMaxSpeed()
        {
            double speed = 20;
            return speed;
        }

        public abstract void SpeedUp(double newspeed)
        {
            double speed = speed + newspeed;
            return speed;
        }

        public Date Madedate => madedate;

        public void SetMadedate(Date value)
        {
            madedate = value;
        }

        public Bike()
            {
              
                this.serialnum = 0000;
                this.model = "Undefined";
                this.color = EnumColor.Undefined;
                
            }

            public Bike(long serialnum, string model, EnumColor color, double speed, Date madedate)
            {
                
                this.serialnum = serialnum
                this.model = model;
                this.color = color;
                this.SpeedUp = speed;
                this.madedate = madedate;
            }

        public Bike(long serialnum,string model, object age, EnumColor color, double speed, Date madedate)
        {
            this.serialnum = serialnum;
            this.model = model;
           
            this.color = color;
            this.SpeedUp = speed;
            this.madedate = madedate;
        }

        public override string ToString()
            {
                string state;
                state = serialnum + "\t    " +  model + "\t  "
                    + SpeedUp + "\t  " + color + "\t  " + madedate;
                return state;
            }
        }
    }




