using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WC001
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            List<double> hours = new List<double>();
            richTextBox1.Text = "";
            richTextBox1.ForeColor = Color.Black;

            double wage = 0;

            double regHours = 0;
            double overtime = 0;
            double overtimeRate = 0;

            double regPay = 0;
            double overPay = 0;
            double totalPay = 0;
            

            try
            {
                wage = double.Parse(txtWage.Text);

                txtWage.Text = string.Format("{0:C2}", txtWage.Text);
            }

            catch
            {
                richTextBox1.ForeColor = Color.Red;
                richTextBox1.Text += "Error: Wage must be numeric\n";
            }

            foreach (TextBox textBox in groupBox2.Controls.OfType<TextBox>())
            {
                double a;
                if(textBox.Text == "")
                {
                    textBox.Text = "0";
                }

                else
                {

                    if (double.TryParse(textBox.Text, out a))
                    {

                        hours.Add(double.Parse(textBox.Text));
                    }

                    else
                    {
                        richTextBox1.ForeColor = Color.Red;
                        richTextBox1.Text += "Error: All Hours Inputs Must Be Numbers\n";
                    }
                }

            }


            if(string.IsNullOrEmpty(richTextBox1.Text))
            {
                double sum = hours.Sum();

                overtimeRate = wage * 1.5;

                if(sum > 44)
                {
                    overtime = (hours.Sum() - 44);
                    overPay = overtime * overtimeRate;

                    regHours = 44;
                    regPay = 44 * wage;

                    totalPay = overPay + regPay;
                }

                else
                {
                    regHours = hours.Sum();
                    regPay = regHours * wage;
                    totalPay = regPay;
                    overtime = 0;
                }


                richTextBox1.Text += $"Name: {txtName.Text}\nWage: {wage.ToString("C2")}\nOvertime Wage: {overtimeRate.ToString("C2")}\n\nRegular Hours: {regHours.ToString("#.##")}\nOvertime Hours: {overtime.ToString("#.##")}\n\n" +
                                    $"Regular Pay: {regPay.ToString("C2")}\nOvertime Pay: ";
                richTextBox1.Text += $"{overPay.ToString("C2")}\n\nTotal Hours: {sum.ToString("#.##")}\nTotal Pay: {totalPay.ToString("C2")}";


            }






        }

        public void ClearForm()
        {
            foreach (TextBox textBox in groupBox1.Controls.OfType<TextBox>())
                textBox.Text = "";

            foreach (TextBox textBox in groupBox2.Controls.OfType<TextBox>())
                textBox.Text = "";

            richTextBox1.Text = "";
        }

        private void ClearForm(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
} 
