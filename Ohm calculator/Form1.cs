using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;



namespace Ohm_calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string value = Interaction.InputBox("Enter the value and I'll do the hard work");
            if (value != "")
            {
                double count = Convert.ToDouble(value);
                double answer = 0;
                string typeUsed = "none";
                if (count >= 1000000 && count < 1000000000 && count < 1000000000000 && count > 0.99)
                {
                    typeUsed = "Mega";
                    answer = count / 1000000;
                } else if (count >= 1000 && count < 1000000 && count < 1000000000 && count < 1000000000000 && count > 0.99)
                {
                    typeUsed = "Kilo";
                    answer = count / 1000;
                } else if (count >= 1000000000 && count > 1000 && count < 1000000000000 && count > 0.99 && count > 1000000)
                {
                    typeUsed = "Giga";
                    answer = count / 1000000000;
                } else if (count >= 1000000000000 && count > 1000 && count > 0.99 && count > 1000000 && count > 1000000000)
                {
                    typeUsed = "Tera";
                    answer = count / 1000000000;
                } else if (count < 1 && count < 0.000000999 && count > 0.000000001) {
                    typeUsed = "Nano. Answer multiplied by 1000.";
                    answer = count * 1000;
                } else if (count < 1 && count < 0.000999999 && count > 0.000000999)
                {
                    typeUsed = "Micro. Answer multiplied by 1000.";
                    answer = count * 1000;
                } else if (count < 1 && count < 0.999999999 && count > 0.000999999) {
                    typeUsed = "Milli. Answer multiplied by 1000.";
                    answer = count * 1000;
                }
                answerLine.Text = "The answer would be " + answer.ToString() + " Ohms\nType used: " + typeUsed;
            }
        }
    }
}