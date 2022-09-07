using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
            string dataString = Interaction.InputBox("Choose how you would like to go calculate the answer:\n1. From ohms to type\n2. From type to ohms", "Ohm calculator");
            if (dataString == null || dataString == "")
            {
                Interaction.MsgBox("No valid answer was provided.", MsgBoxStyle.OkOnly, "Ohm calculator");
                return;
            }

            int dataType = Convert.ToInt32(dataString);

            if (dataType == 1)
            {
                string value = Interaction.InputBox("Enter the value and I'll do the math part for you. You will be able to see the type and the answer.\nNOTE: Use \".\" to splice the numbers.", "Ohm calculator");
                if (value != "")
                {
                    double count = Convert.ToDouble(value);
                    double answer = 0;
                    string typeUsed = "No type detected";
                    if (count >= 1000000 && count < 1000000000 && count < 1000000000000 && count > 0.99)
                    {
                        typeUsed = "Mega (Divided by 1000000)";
                        answer = count / 1000000;
                    }
                    else if (count >= 1000 && count < 1000000 && count < 1000000000 && count < 1000000000000 && count > 0.99)
                    {
                        typeUsed = "Kilo (Divided by 1000)";
                        answer = count / 1000;
                    }
                    else if (count >= 1000000000 && count > 1000 && count < 1000000000000 && count > 0.99 && count > 1000000)
                    {
                        typeUsed = "Giga (Divided by 1000,000,000)";
                        answer = count / 1000000000;
                    }
                    else if (count >= 1000000000000 && count > 1000 && count > 0.99 && count > 1000000 && count > 1000000000)
                    {
                        typeUsed = "Tera (Divided by 1000,000,000,000)";
                        answer = count / 1000000000000;
                    }
                    else if (count < 1 && count < 0.000000999 && count > 0.000000001)
                    {
                        typeUsed = "Nano. (Multiplied by 1000)";
                        answer = count * 1000;
                    }
                    else if (count < 1 && count < 0.000999999 && count > 0.000000999)
                    {
                        typeUsed = "Micro. (Multiplied by 1000)";
                        answer = count * 1000;
                    }
                    else if (count < 1 && count < 0.999999999 && count > 0.000999999)
                    {
                        typeUsed = "Milli. (Multiplied by 1000)";
                        answer = count * 1000;
                    }
                    else if (count < 1000 && count > 0)
                    {
                        typeUsed = "Kilo (Divided by 1000, triggered else if)"; // Added this comment in case something goes wrong.
                        answer = count / 1000;
                    }
                    answerLine.Text = "The answer would be " + string.Format("{0:#,0}", answer) + " Ohms\nType used: " + typeUsed;
                }
            } else
            {
                double answer = 0;
                string value = Interaction.InputBox("Enter the count in numbers (Not ohms).\nNOTE: Use \".\" to splice the numbers.", "Ohm calculator");
                string type = Interaction.InputBox("Enter the type. (K = Kilo, M = Mega, G = Giga, T = Tera, N = Nano, Mi = Milli, Mik = Mikro)").ToLower();
                if (value != "" && type != "")
                {
                    double number = Convert.ToDouble(value);
                    if (type == "k" || type == "kilo")
                    {
                        answer = number * 1000;
                    } else if (type == "m" || type == "mega")
                    {
                        answer = number * 1000000;
                    } else if (type == "g" || type == "giga")
                    {
                        answer = number * 1000000000;
                    } else if (type == "t" || type == "tera")
                    {
                        answer = number * 1000000000000;
                    } else if (type == "n" || type == "nano")
                    {
                        answer = number / 0.0000000001;
                    } else if (type == "mik" || type == "mikro")
                    {
                        answer = number / 0.000001;
                    } else if (type == "mi" || type == "milli")
                    {
                        answer = number / 0.001;
                    }

                    answerLine.Text = "The answer would be " + string.Format("{0:#,0}", answer) + " Ohms";
                } else
                {
                    Interaction.MsgBox("Can't proceed without a valid type and value.", MsgBoxStyle.OkOnly, "Ohm calculator");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            answerLine.Text = "(Results will come here)";
        }
    }
}