using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalAssessment
{
    public partial class Form1 : Form
    {
        //declare an array
        const int MAX = 50;
        double[] salaryContainer = new double[MAX];
        int count = 0; //default number of values is 0


        public Form1()
        {
            InitializeComponent();
        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            //validate data
            if (IsPositiveDouble(txtSalary, "Salary"))
            {
                if (count < MAX)
                {
                    salaryContainer[count] = Double.Parse(txtSalary.Text);
                    count++;
                    txtSalary.Text = "";
                    txtSalary.Focus();
                }
                else
                {
                    btnDone.Focus();
                    btnNext.Enabled = false;
                    MessageBox.Show("You cannot enter any more salary values.",
                           "Input Error");
                }

                //display salary in list box

                lstSalaries.Items.Clear();
                for (int i = 0; i < count; i++)
                {
                    lstSalaries.Items.Add(salaryContainer[i].ToString("c"));
                }

                //display federal tax
                double federalTax = CalculateTax(salaryContainer, count);
                lblTax.Text = federalTax.ToString("c");


            }


        }


        private void btnDone_Click(object sender, EventArgs e)
        {
            //make sure there is at least one salary entered
            if (count < 1)
            {
                MessageBox.Show("Please enter at least 1 salary.");
            }
            else
            {
                //get the sum
                double salarySum = Sum(salaryContainer, count);

                //get the average and display
                double average = salarySum / count;
                lblAvg.Text = "The average salary is " + average.ToString("c");

                //find the  smallest
                double small = Min(salaryContainer, count);

                //find the largest
                double large = Max(salaryContainer, count);

                //find and display the midpoint
                double midpoint = (small + large) / 2;
                lblMidpoint.Text = midpoint.ToString("c");
            }
        }


        //method to calculate sum of values in an array
        public double Sum(double[] numbers, int howMany)
        {
            double result = 0;
            for (int i = 0; i < howMany; i++)
            {
                result = result + numbers[i];
            }
            return result;
        }

        //method to find smallest salary value
        public double Min(double[] numbers, int howMany)
        {
            double smallest = numbers[0]; //suppose the first element is the smallest
            for (int i = 0; i < howMany; i++)
            {
                if (numbers[i] < smallest) //found a smaller one
                {
                    smallest = numbers[i];
                }
            }
            return smallest;
        }

        //method to find largest salary value
        public double Max(double[] numbers, int howMany)
        {
            double biggest = numbers[0]; //suppose the first element is the smallest
            for (int i = 0; i < howMany; i++)
            {
                if (numbers[i] > biggest) //found a smaller one
                {
                    biggest = numbers[i];
                }
            }
            return biggest;
        }

        //function to validate if a text box is above zero and a double
        public static bool IsPositiveDouble(TextBox inputBox, string inputName)
        {
            bool result = true; //default
            double temp; //temporary variable for try parse
            if (!Double.TryParse(inputBox.Text, out temp)) //bad number format
            {
                MessageBox.Show(inputName + " has to be a numeric value.",
                    "Input Error");
                result = false;
            }
            else if (temp <= 0) //zero or negative
            {
                MessageBox.Show(inputName + " must be higher than 0.",
                    "Input Error");
                result = false;
            }
            return result;
        }


        //method to calculate federal tax                  
        public double CalculateTax(double[] salaryContainer, int howMany)
        {
            double tax = 0;
            for (int i = 0; i < howMany; i++)
            {
                if (salaryContainer[i] <= 43561)
                    tax = salaryContainer[i] * 0.15;
                else if (salaryContainer[i] > 43561 && salaryContainer[i] <= 87123)
                    tax = ((salaryContainer[i] - 43561) * 0.22) + 6534;
                else if (salaryContainer[i] > 87123)
                    tax = ((salaryContainer[i] - 87123) * 0.26) + 16118;
            }
            return tax;

        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close(); //terminate application
        }

    }

}


       