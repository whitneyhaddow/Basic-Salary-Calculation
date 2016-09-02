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
        // contains a mapping of 2-letter state codes to the dictionaries of tax brackets for each state and DC
        Dictionary<String, SortedDictionary<double, double>> stateDict = new Dictionary<String, SortedDictionary<double,double>>(51);
        // a dictionary of <tax rate of a bracket, upper limit in that bracket> sorted by key
        SortedDictionary<double, double> federalBrackets = new SortedDictionary<double, double>
            {
                {0.10, 9275},
                {0.15, 37650},
                {0.396, double.MaxValue},
                {0.35, 415050},
                {0.25, 91150},
                {0.33, 413350},
                {0.28, 190150}
            }; 

        public Form1()
        {
            InitializeComponent();
            InitializeStateBrackets();
        }

        public void InitializeStateBrackets()
        {
            SortedDictionary<double, double> AlabamaBrackets = new SortedDictionary<double, double>
            {
                {0.02, 500},
                {0.04, 3000},
                {0.05, double.MaxValue}
            };
            SortedDictionary<double, double> AlaskaBrackets = new SortedDictionary<double, double>
            {
                {0, double.MaxValue}
            };
            SortedDictionary<double, double> ArizonaBrackets = new SortedDictionary<double, double>
            {
                {0.0259, 10000},
                {0.0288, 25000},
                {0.0336, 50000},
                {0.0424, 150000},
                {0.0454, double.MaxValue}
            };
            SortedDictionary<double, double> ArkansasBrackets = new SortedDictionary<double, double>
            {
                {0.0090, 4299},
                {0.0250, 8399},
                {0.0350, 12599},
                {0.0450, 20999},
                {0.06, 35099},
                {0.069, double.MaxValue}
            };
            SortedDictionary<double, double> CaliforniaBrackets = new SortedDictionary<double, double>
            {
                {0.01, 7850},
                {0.02, 18610},
                {0.04, 29372},
                {0.06, 40773},
                {0.08, 51530},
                {0.0930, 263222},
                {0.1030, 315866},
                {0.1130, 526443},
                {0.1230, 1000000},
                {0.1330, double.MaxValue}
            };
            SortedDictionary<double, double> ColoradoBrackets = new SortedDictionary<double, double>
            {
                {0.0463, double.MaxValue}
            };
            SortedDictionary<double, double> ConnecticutBrackets = new SortedDictionary<double, double>
            {
                {0.03, 10000},
                {0.05, 50000},
                {0.0550, 100000},
                {0.06, 200000},
                {0.0650, 250000},
                {0.0690, 500000},
                {0.0699, double.MaxValue}
            };
            SortedDictionary<double, double> DelawareBrackets = new SortedDictionary<double, double>
            {
                {0, 2000},
                {0.0220, 5000},
                {0.0390, 10000},
                {0.0480, 20000},
                {0.0520, 25000},
                {0.0555, 60000},
                {0.0660, double.MaxValue}
            };
            SortedDictionary<double, double> FloridaBrackets = new SortedDictionary<double, double>
            {
                {0, double.MaxValue}
            };
            SortedDictionary<double, double> GeorgiaBrackets = new SortedDictionary<double, double>
            {
                {0.01, 750},
                {0.02, 2250},
                {0.03, 3750},
                {0.04, 5250},
                {0.05, 7000},
                {0.06, double.MaxValue}
            };
            SortedDictionary<double, double> HawaiiBrackets = new SortedDictionary<double, double>
            {
                {0.014, 2400},
                {0.032, 4800},
                {0.055, 9600},
                {0.064, 14400},
                {0.068, 19200},
                {0.072, 24000},
                {0.076, 36000},
                {0.079, 48000},
                {0.0825, double.MaxValue}
            };
            SortedDictionary<double, double> IdahoBrackets = new SortedDictionary<double, double>
            {
                {0.016, 1452},
                {0.036, 2940},
                {0.041, 4356},
                {0.051, 5808},
                {0.061, 7260},
                {0.071, 10890},
                {0.074, double.MaxValue}
            };
            SortedDictionary<double, double> IllinoisBrackets = new SortedDictionary<double, double>
            {
                {0.0375, double.MaxValue}
            };
            SortedDictionary<double, double> IndianaBrackets = new SortedDictionary<double, double>
            {
                {0.033, double.MaxValue}
            };
            SortedDictionary<double, double> IowaBrackets = new SortedDictionary<double, double>
            {
                {0.0036, 1554},
                {0.0072, 3108},
                {0.0243, 6216},
                {0.0450, 13896},
                {0.0612, 23310},
                {0.0648, 31080},
                {0.0680, 46620},
                {0.0792, 69930},
                {0.0898, double.MaxValue}
            };
            SortedDictionary<double, double> KansasBrackets = new SortedDictionary<double, double>
            {
                {0.027, 15000},
                {0.046, double.MaxValue}
            };
            SortedDictionary<double, double> KentuckyBrackets = new SortedDictionary<double, double>
            {
                {0.02, 3000},
                {0.03, 4000},
                {0.04, 5000},
                {0.05, 8000},
                {0.058, 75000},
                {0.06, double.MaxValue}
            };
            SortedDictionary<double, double> LouisianaBrackets = new SortedDictionary<double, double>
            {
                {0.02, 12500},
                {0.04, 50000},
                {0.06, double.MaxValue}
            };
            SortedDictionary<double, double> MaineBrackets = new SortedDictionary<double, double>
            {
                {0.0580, 21049},
                {0.0675, 37499},
                {0.0715, double.MaxValue}
            };
            SortedDictionary<double, double> MarylandBrackets = new SortedDictionary<double, double>
            {
                {0.02, 1000},
                {0.03, 2000},
                {0.04, 3000},
                {0.0475, 100000},
                {0.05, 125000},
                {0.0525, 150000},
                {0.0550, 250000},
                {0.0575, double.MaxValue}
            };
            SortedDictionary<double, double> MassachusettsBrackets = new SortedDictionary<double, double>
            {
                {0.051, double.MaxValue}
            };
            SortedDictionary<double, double> MichiganBrackets = new SortedDictionary<double, double>
            {
                {0.0425, double.MaxValue}
            };
            SortedDictionary<double, double> MinnesotaBrackets = new SortedDictionary<double, double>
            {
                {0.0535, 25180},
                {0.0705, 82740},
                {0.0785, 155650},
                {0.0985, double.MaxValue}
            };
            SortedDictionary<double, double> MississippiBrackets = new SortedDictionary<double, double>
            {
                {0.03, 5000},
                {0.04, 10000},
                {0.05, double.MaxValue}
            };
            SortedDictionary<double, double> MissouriBrackets = new SortedDictionary<double, double>
            {
                {0.015, 1000},
                {0.02, 2000},
                {0.025, 3000},
                {0.03, 4000},
                {0.035, 5000},
                {0.04, 6000},
                {0.045, 7000},
                {0.05, 8000},
                {0.055, 9000},
                {0.06, double.MaxValue}
            };
            SortedDictionary<double, double> MontanaBrackets = new SortedDictionary<double, double>
            {
                {0.01, 2900},
                {0.02, 5100},
                {0.03, 7800},
                {0.04, 10500},
                {0.05, 13500},
                {0.06, 17400},
                {0.069, double.MaxValue}
            };
            SortedDictionary<double, double> NebraskaBrackets = new SortedDictionary<double, double>
            {
                {0.0246, 3060},
                {0.0351, 18370},
                {0.0501, 29590},
                {0.0684, double.MaxValue}
            };
            SortedDictionary<double, double> NevadaBrackets = new SortedDictionary<double, double>
            {
                {0, double.MaxValue}
            };
            SortedDictionary<double, double> NewHampshireBrackets = new SortedDictionary<double, double>
            {
                {0.05, double.MaxValue}
            };
            SortedDictionary<double, double> NewJerseyBrackets = new SortedDictionary<double, double>
            {
                {0.0140, 20000},
                {0.0175, 35000},
                {0.0350, 40000},
                {0.0553, 75000},
                {0.0637, 500000},
                {0.0897, double.MaxValue}
            };
            SortedDictionary<double, double> NewMexicoBrackets = new SortedDictionary<double, double>
            {
                {0.017, 5500},
                {0.032, 11000},
                {0.047, 16000},
                {0.049, double.MaxValue}
            };
            SortedDictionary<double, double> NewYorkBrackets = new SortedDictionary<double, double>
            {
                {0.04, 8450},
                {0.045, 11650},
                {0.0525, 13850},
                {0.059, 21300},
                {0.0645, 80150},
                {0.0665, 214000},
                {0.0685, 1070350},
                {0.0882, double.MaxValue}
            };
            SortedDictionary<double, double> NorthCarolinaBrackets = new SortedDictionary<double, double>
            {
                {0.0575, double.MaxValue}
            };
            SortedDictionary<double, double> NorthDakotaBrackets = new SortedDictionary<double, double>
            {
                {0.0110, 37450},
                {0.0204, 90750},
                {0.0227, 189300},
                {0.0264, 411500},
                {0.0290, double.MaxValue}
            };
            SortedDictionary<double, double> OhioBrackets = new SortedDictionary<double, double>
            {
                {0.005, 5200},
                {0.0099, 10400},
                {0.0198, 15650},
                {0.0248, 20900},
                {0.0297, 41700},
                {0.0347, 83350},
                {0.0396, 104250},
                {0.0460, 208500},
                {0.05, double.MaxValue}
            };
            SortedDictionary<double, double> OklahomaBrackets = new SortedDictionary<double, double>
            {
                {0.005, 1000},
                {0.01, 2500},
                {0.02, 3750},
                {0.03, 4900},
                {0.04, 7200},
                {0.05, double.MaxValue}
            };
            SortedDictionary<double, double> OregonBrackets = new SortedDictionary<double, double>
            {
                {0.05, 3350},
                {0.07, 8400},
                {0.09, 125000},
                {0.099, double.MaxValue}
            };
            SortedDictionary<double, double> PennsylvaniaBrackets = new SortedDictionary<double, double>
            {
                {0.0307, double.MaxValue}
            };
            SortedDictionary<double, double> RhodeIslandBrackets = new SortedDictionary<double, double>
            {
                {0.0375, 60850},
                {0.0475, 138300},
                {0.0599, double.MaxValue}
            };
            SortedDictionary<double, double> SouthCarolinaBrackets = new SortedDictionary<double, double>
            {
                {0, 2920},
                {0.03, 5840},
                {0.04, 8760},
                {0.05, 11680},
                {0.06, 14600},
                {0.07, double.MaxValue}
            };
            SortedDictionary<double, double> SouthDakotaBrackets = new SortedDictionary<double, double>
            {
                {0, double.MaxValue}
            };
            SortedDictionary<double, double> TennesseeBrackets = new SortedDictionary<double, double>
            {
                {0.06, double.MaxValue}
            };
            SortedDictionary<double, double> TexasBrackets = new SortedDictionary<double, double>
            {
                {0, double.MaxValue}
            };
            SortedDictionary<double, double> UtahBrackets = new SortedDictionary<double, double>
            {
                {0.05, double.MaxValue}
            };
            SortedDictionary<double, double> VermontBrackets = new SortedDictionary<double, double>
            {
                {0.0355, 39900},
                {0.068, 93400},
                {0.078, 192400},
                {0.088, 415600},
                {0.0895, double.MaxValue}
            };
            SortedDictionary<double, double> VirginiaBrackets = new SortedDictionary<double, double>
            {
                {0.02, 3000},
                {0.03, 5000},
                {0.05, 17000},
                {0.0575, double.MaxValue}
            };
            SortedDictionary<double, double> WashingtonBrackets = new SortedDictionary<double, double>
            {
                {0, double.MaxValue}
            };
            SortedDictionary<double, double> WestVirginiaBrackets = new SortedDictionary<double, double>
            {
                {0.03, 10000},
                {0.04, 25000},
                {0.045, 40000},
                {0.06, 60000},
                {0.065, double.MaxValue}
            };
            SortedDictionary<double, double> WisconsinBrackets = new SortedDictionary<double, double>
            {
                {0.04, 11150},
                {0.0584, 22230},
                {0.0627, 244750},
                {0.0765, double.MaxValue}
            };
            SortedDictionary<double, double> WyomingBrackets = new SortedDictionary<double, double>
            {
                {0, double.MaxValue}
            };
            SortedDictionary<double, double> DCBrackets = new SortedDictionary<double, double>
            {
                {0.04, 10000},
                {0.06, 40000},
                {0.065, 60000},
                {0.085, 350000},
                {0.0875, 1000000},
                {0.0895, double.MaxValue}
            };

            this.stateDict.Add("AL", AlabamaBrackets);
            this.stateDict.Add("AK", AlaskaBrackets);
            this.stateDict.Add("AZ", ArizonaBrackets);
            this.stateDict.Add("AR", ArkansasBrackets);
            this.stateDict.Add("CA", CaliforniaBrackets);
            this.stateDict.Add("CO", ColoradoBrackets);
            this.stateDict.Add("CT", ConnecticutBrackets);
            this.stateDict.Add("DE", DelawareBrackets);
            this.stateDict.Add("DC", DCBrackets);
            this.stateDict.Add("FL", FloridaBrackets);
            this.stateDict.Add("GA", GeorgiaBrackets);
            this.stateDict.Add("HI", HawaiiBrackets);
            this.stateDict.Add("ID", IdahoBrackets);
            this.stateDict.Add("IL", IllinoisBrackets);
            this.stateDict.Add("IN", IndianaBrackets);
            this.stateDict.Add("IA", IowaBrackets);
            this.stateDict.Add("KS", KansasBrackets);
            this.stateDict.Add("KY", KentuckyBrackets);
            this.stateDict.Add("LA", LouisianaBrackets);
            this.stateDict.Add("ME", MaineBrackets);
            this.stateDict.Add("MD", MarylandBrackets);
            this.stateDict.Add("MA", MassachusettsBrackets);
            this.stateDict.Add("MI", MichiganBrackets);
            this.stateDict.Add("MN", MinnesotaBrackets);
            this.stateDict.Add("MS", MississippiBrackets);
            this.stateDict.Add("MO", MissouriBrackets);
            this.stateDict.Add("MT", MontanaBrackets);
            this.stateDict.Add("NE", NebraskaBrackets);
            this.stateDict.Add("NV", NevadaBrackets);
            this.stateDict.Add("NH", NewHampshireBrackets);
            this.stateDict.Add("NJ", NewJerseyBrackets);
            this.stateDict.Add("NM", NewMexicoBrackets);
            this.stateDict.Add("NY", NewYorkBrackets);
            this.stateDict.Add("NC", NorthCarolinaBrackets);
            this.stateDict.Add("ND", NorthDakotaBrackets);
            this.stateDict.Add("OH", OhioBrackets);
            this.stateDict.Add("OK", OklahomaBrackets);
            this.stateDict.Add("OR", OregonBrackets);
            this.stateDict.Add("PA", PennsylvaniaBrackets);
            this.stateDict.Add("RI", RhodeIslandBrackets);
            this.stateDict.Add("SC", SouthCarolinaBrackets);
            this.stateDict.Add("SD", SouthDakotaBrackets);
            this.stateDict.Add("TN", TennesseeBrackets);
            this.stateDict.Add("TX", TexasBrackets);
            this.stateDict.Add("UT", UtahBrackets);
            this.stateDict.Add("VT", VermontBrackets);
            this.stateDict.Add("VA", VirginiaBrackets);
            this.stateDict.Add("WA", WashingtonBrackets);
            this.stateDict.Add("WV", WestVirginiaBrackets);
            this.stateDict.Add("WI", WisconsinBrackets);
            this.stateDict.Add("WY", WyomingBrackets);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //validate data
            if (IsPositiveDouble(txtSalary, "Salary"))
            {
                if (!this.stateDict.ContainsKey(txtState.Text))
                {
                    MessageBox.Show("Please enter a valid 2-letter state code.",
                           "Input Error");
                    return;
                }
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
                double federalTax = CalculateFederalTax(salaryContainer[count-1]);
                lblTax.Text = federalTax.ToString("c");

                //display state tax
                double stateTax = CalculateStateTax(txtState.Text, salaryContainer[count - 1]);
                txtState.Text = "";
                lblStateTax.Text = stateTax.ToString("c");
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


        //method to calculate federal tax for a given salary
        public double CalculateFederalTax(double salary)
        {
            return CalculateTax(this.federalBrackets, salary);
        }

        //method to calculate state tax given salary and state
        public double CalculateStateTax(String state, double salary)
        {
            SortedDictionary<double, double> stateBrackets;
            this.stateDict.TryGetValue(state, out stateBrackets);

            return CalculateTax(stateBrackets, salary);
        }

        //method to compute tax of salary given its bracket dictionary
        public double CalculateTax(SortedDictionary<double, double> brackets, double salary)
        {
            double tax = 0;
            double lower = 0;
            foreach (KeyValuePair<double, double> kvp in brackets)
            {
                double upper = Math.Min(salary, kvp.Value);
                tax += (upper - lower) * kvp.Key;
                lower = kvp.Value;
                if (salary <= kvp.Value) // entire salary amount is taxed
                {
                    break;
                }
            }

            return tax;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close(); //terminate application
        }

    }

}


       