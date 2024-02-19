using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static romedt_calculator_app.MainPage;

namespace romedt_calculator_app
{
    public partial class MainPage : ContentPage
    {
        string operation;
        double result;
        double lastNumber;
        double value1;
        double value2;
        public Operator _operator;

        public MainPage()
        {
            InitializeComponent();

            //handlers for function buttons
            btnClear.Clicked += btnClear_Clicked;
            btnPercent.Clicked += btnPercent_Clicked;
            btnNegative.Clicked += btnNegative_Clicked;
            btnEquals.Clicked += btnEquals_Clicked;
      

            //handlers for number buttons
            btn0.Clicked += (sender, e) => setValue(0);
            btn1.Clicked += (sender, e) => setValue(1);
            btn2.Clicked += (sender, e) => setValue(2);
            btn3.Clicked += (sender, e) => setValue(3);
            btn4.Clicked += (sender, e) => setValue(4);
            btn5.Clicked += (sender, e) => setValue(5);
            btn6.Clicked += (sender, e) => setValue(6);
            btn7.Clicked += (sender, e) => setValue(7);
            btn8.Clicked += (sender, e) => setValue(8);
            btn9.Clicked += (sender, e) => setValue(9); 

        }
        public void setValue(int value)
        {
            if(labelResult.Text.ToString() == "0")
            {
                labelResult.Text = value.ToString();
            }
            else
            {
                labelResult.Text = $"{labelResult.Text}{value}";
            }
        }


        private void btnNegative_Clicked(object sender, EventArgs e)
        {
            if(double.TryParse(labelResult.Text, out lastNumber))
            {
                lastNumber *= -1;
                labelResult.Text = $"{lastNumber}";
            }
        }
        private void btnClear_Clicked(object sender, EventArgs e)
        {
            lastNumber = 0;
            result = 0;
            labelResult.Text = lastNumber.ToString();
        }

        private void btnOperator_Click(object sender, EventArgs e)
        {
            if (double.TryParse(labelResult.Text.ToString(), out lastNumber))
            {
                labelResult.Text = "0";
            }

            if (sender == btnMultiply)
            {
                _operator = Operator.Multiplication;
            }
            else if (sender == btnAdd)
            {
                _operator = Operator.Addition;
            }
            else if (sender == btnDivide)
            {
                _operator = Operator.Division;
            }
            else if (sender == btnSubtract)
            {
                _operator = Operator.Subtraction;
            }
        }

        private void btnDecimal_Clicked(object sender, EventArgs e)
        {
            if(!labelResult.Text.ToString().Contains("."))
            {
                labelResult.Text = $"{labelResult.Text}.";
            }
        }

        private void btnEquals_Clicked(object sender, EventArgs e)
        {
            if (double.TryParse(labelResult.Text.ToString(), out double newNumber))
            {
                switch (_operator)
                {
                    case Operator.Addition:
                        result = Calculate.Add(lastNumber, newNumber);
                        break;
                    case Operator.Division:
                        result = Calculate.Divide(lastNumber, newNumber);
                        break;
                    case Operator.Multiplication:
                        result = Calculate.Multiply(lastNumber, newNumber);
                        break;
                    case Operator.Subtraction:
                        result = Calculate.Subtract(lastNumber, newNumber);
                        break;
                }

                labelResult.Text = result.ToString();
            }
        }

        

        private void btnPercent_Clicked(object sender, EventArgs e)
        {
            double temp;
            if(double.TryParse(labelResult.Text.ToString(), out temp)) 
            {
                temp /= 100;
                if(lastNumber !=0)
                {
                    temp *= lastNumber;
                }
                labelResult.Text = $"{temp}";
            }
        }
        public enum Operator
        {
            Addition,
            Subtraction,
            Multiplication,
            Division
        }
        public class Calculate
        {
            public static double Add(double val1, double val2)
            {
                return val1 + val2;
            }
            public static double Subtract(double val1, double val2)
            {
                return val1 - val2;
            }
            public static double Multiply(double val1, double val2)
            {
                return val1 * val2;
            }
            public static double Divide(double val1, double val2)
            {
                return val1 / val2;
            }
        }

    }
}
