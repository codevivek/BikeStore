using System;
using System.Collections.Generic;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

using System.Xml;
using System.Xml.Serialization;
using Mybikes.Bus;
using MYBIKESS.Bus;

namespace Mybikes.Client
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int index;
        List<Bike> Bikelist = new List<Bike>();
        List<Mountainbike> Mountainlist = new List<Mountainbike>();
        List<Roadbike> Roadlist = new List<Roadbike>();

        private void Form1_Load(object sender, EventArgs e)
        {
            // color
            foreach (EnumColor color in Enum.GetValues(typeof(EnumColor)))
            {
                this.color.Items.Add(color);
            }
            this.color.Text = Convert.ToString(color.Items[0]);

            // type of suspension
            foreach (EnumSuspension suspension in Enum.GetValues(typeof(EnumSuspension)))
            {
                this.suspension.Items.Add(suspension);
            }
            this.suspension.Text = Convert.ToString(suspension.Items[0]);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (mountainbike.Checked == true)
            {

                Mountainbike M1 = new Mountainbike();
                M1.Biketype = mountainbike.Text;
                M1.Serialnum = (Convert.ToInt32(serialnum.Text));
                M1.Model = model.Text;
                M1.Color = ((EnumColor)this.comboBoxColor.SelectedItem);
                M1.SpeedUp = (Convert.ToInt32(speed.Text));
                M1.Typefs = ((EnumType)this.suspension.SelectedItem);
               

                Date madedate = new Date();
                madedate.date = (Convert.ToInt32(date.Text));
                

                M1.Madedate = madedate;
                Bike b1 = M1;
                Bikelist.Add(b1);
                Mountainlist.Add(M1);
            }
            else if (roadbike.Checked == true)
            {
                Roadbike R1 = new Roadbike();
                R1.Biketype = roadbike.Text;
                R1.Serialnum = (Convert.ToInt32(serialnum.Text));
                R1.Model = model.Text;
                R1.Color = ((EnumColor)this.comboBoxColor.SelectedItem);
                R1.Speed = (Convert.ToInt32(speed.Text));
                R1.Typefs = ((EnumType)this.suspension.SelectedItem);


                Date madedate = new Date();
                madedate.date = (Convert.ToInt32(date.Text));


                R1.Madedate = madedate;
                Bike b1 = R1;
                Bikelist.Add(b1);
                Mountainlist.Add(R1);
            }

        }

        private void ShowMountainbike(List<Mountainbike> Mountainlist, ListBox listBox)
        {
            this.result.Items.Clear();

            if (this.Mountainlist.Capacity != 0)
            {
                foreach (Mountainbike list in this.Mountainlist)
                {
                    this.result.Items.Add(list);
                }
            }
            else
            {
                MessageBox.Show("................. NO DATA ....................");
                serialnum.Focus();
            }
        }

        private void ShowRoadbike(List<Roadbike> Roadlist, ListBox listbox)
        {
            this.result.Items.Clear();
            if (this.Roadlist.Capacity != 0)
            {
                foreach (Roadbike list in this.Roadlist)
                {
                    this.result.Items.Add(list);
                }
            }
            else
            {
                MessageBox.Show("................. NO DATA ....................");
                serialnum.Focus();
            }
        }

        private void buttonDisplayall_Click(object sender, EventArgs e)
        {
            foreach (Bike bike in Bikelist)
            {
                result.Items.Add(bike);
            }

        }

        private void Display_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = Display.SelectedIndex;

            //MessageBox.Show("Index Number is "+index);

            if (mountainbike.Checked == true)
            {
                mountainbike.Checked = true;

                serialnum.Text = Convert.ToString(this.Mountainlist[index].Serialnum);
                model.Text = this.Mountainlist[index].Model;
                color.Text = Convert.ToString(this.Mountainlist[index].Color);
                speed.Text = Convert.ToString(this.Mountainlist[index].Speed);
                date.Text = Convert.ToString(this.Mountainlist[index].Madedate.date);
                suspension.Text = Convert.ToString(this.Mountainlist[index].Typefs);
            }
            else if (roadbike.Checked == true)
            {
                serialnum.Text = Convert.ToString(this.Mountainlist[index].Serialnum);
                model.Text = this.Mountainlist[index].Model;
                color.Text = Convert.ToString(this.Mountainlist[index].Color);
                speed.Text = Convert.ToString(this.Mountainlist[index].Speed);
                date.Text = Convert.ToString(this.Mountainlist[index].Madedate.date);
                suspension.Text = Convert.ToString(this.Mountainlist[index].Typefs);
                textBoxSeat.Text = Convert.ToString(this.Roadlist[index].Seatheight);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (mountainbike.Checked == true)
            {
                this.Mountainlist[index].Serialnum = Convert.ToInt32(serialnum.Text);
                this.Mountainlist[index].Model = model.Text;
                this.Mountainlist[index].Color = (EnumColor)this.comboBoxColor.SelectedIndex;
                this.Mountainlist[index].Speed = Convert.ToInt32(speed.Text);
                this.Mountainlist[index].Madedate.date = Convert.ToInt32(date.Text);
                this.Mountainlist[index].Typefs = (EnumSuspension)this.suspension.SelectedIndex;
                ShowMountainbike(Mountainlist, result);
            }
            else if (roadbike.Checked == true)
            {
                this.Roadlist[index].Serialnum = Convert.ToInt32(serialnum.Text);
                this.Roadlist[index].Model = model.Text;
                this.Roadlist[index].Color = (EnumColor)this.comboBoxColor.SelectedIndex;
                this.Roadlist[index].Speed = Convert.ToInt32(speed.Text);
                this.Roadlist[index].Madedate.date = Convert.ToInt32(date.Text);
                this.Roadlist[index].Typefs = (EnumSuspension)this.suspension.SelectedIndex;
                ShowRoadbike(Roadlist, result);
            }

        }

        private void ShowMountainbike(List<Mountainbike> mountainlist, TextBox result)
        {
            throw new NotImplementedException();
        }

        private void ShowRoadbike(List<Roadbike> roadlist, TextBox result)
        {
            throw new NotImplementedException();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }

    private void removebtn(object sender, EventArgs e)
    {
        if (Mountainbike.Checked == true)
        {
            this.Mountainlist.RemoveAt(index);
            ShowMountainbike(Mountainlist, result);
        }
        else if (Roadbike.Checked == true)
        {
            this.Roadlist.RemoveAt(index);
            ShowRoadbike(Roadlist, result);
        }
    }

    private void searchbtn(object sender, EventArgs e)
    {
        if (Mountainbike.Checked == true)
        {
            int temp = Convert.ToInt32(serialnumsearch.Text);

            bool found = false;
            Mountainbike searchedMountain = new Mountainbike();

            foreach (Mountainbike item in this.Mountainlist)
            { 
                if (item.serialnum == temp)
                {
                    found = true;
                    searchedMountain = item;
                    break;
                }
            }

            if (found)
            {
                MessageBox.Show("Mountianbike Found....\n" + searchedMountain);
            }
            else
            {
                MessageBox.Show("Mountainbike Not Found");
            }
        }
        else if (roadbike.Checked == true)
        {
            int temp = Convert.ToInt32(search.Text);

            bool found = false;

            Roadbike searchedRoad = new Roadbike();

            foreach (Roadbike item in this.Roadlist)
            {
                if (item.Serialnum == temp)
                {
                    found = true;
                    searchedRoad = item;
                    break;
                }
            }

            if (found)
            {
                MessageBox.Show("Roadbike Found....\n" + searchedRoad);
            }
            else
            {
                MessageBox.Show("Roadbike Not Found");
            }
        }
    }

    private void groupBox1_Enter(object sender, EventArgs e)
    {

    }
}
}




