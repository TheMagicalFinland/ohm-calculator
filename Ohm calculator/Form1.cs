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
            string value = Interaction.InputBox("Enter the value and I'll do the math part for you. You will be able to see the type and the answer.", "Ohm calculator");
            if (value != "")
            {
                double count = Convert.ToDouble(value);
                double answer = 0;
                string typeUsed = "No type detected";
                if (count >= 1000000 && count < 1000000000 && count < 1000000000000 && count > 0.99)
                {
                    typeUsed = "Mega (Divided by 1000000)";
                    answer = count / 1000000;
                } else if (count >= 1000 && count < 1000000 && count < 1000000000 && count < 1000000000000 && count > 0.99)
                {
                    typeUsed = "Kilo (Divided by 1000)";
                    answer = count / 1000;
                } else if (count >= 1000000000 && count > 1000 && count < 1000000000000 && count > 0.99 && count > 1000000)
                {
                    typeUsed = "Giga (Divided by 1000,000,000)";
                    answer = count / 1000000000;
                } else if (count >= 1000000000000 && count > 1000 && count > 0.99 && count > 1000000 && count > 1000000000)
                {
                    typeUsed = "Tera (Divided by 1000,000,000,000)";
                    answer = count / 1000000000000;
                } else if (count < 1 && count < 0.000000999 && count > 0.000000001) {
                    typeUsed = "Nano. (Multiplied by 1000)";
                    answer = count * 1000;
                } else if (count < 1 && count < 0.000999999 && count > 0.000000999)
                {
                    typeUsed = "Micro. (Multiplied by 1000)";
                    answer = count * 1000;
                } else if (count < 1 && count < 0.999999999 && count > 0.000999999) {
                    typeUsed = "Milli. (Multiplied by 1000)";
                    answer = count * 1000;
                } else if (count < 1000 && count > 0)
                {
                    typeUsed = "Kilo (Divided by 1000, triggered else if)"; // Added this comment in case something goes wrong.
                    answer = count / 1000;
                }
                answerLine.Text = "The answer would be " + answer.ToString() + " Ohms\nType used: " + typeUsed;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            answerLine.Text = "(Results will come here)";
        }
    }
}