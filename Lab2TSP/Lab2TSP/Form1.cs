using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2TSP
{
    public partial class Form1 : Form
    {
        private char currentOperation = ' ';
        private double lastOperand = 0.0;

        public Form1()
        {
            InitializeComponent();

            mainTextBox.Text = "0";
        }

        private void buttonNumberClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button) sender;

            if (mainTextBox.Text != "0")
                mainTextBox.Text += clickedButton.Text;
            else
                mainTextBox.Text = clickedButton.Text;
        }

        private void buttonOperationClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button) sender;

            var operation = clickedButton.Text[0];

            if (operation == '=')
            {
                compute();
            }
            else
            {
                currentOperation = operation;

                try
                {
                    lastOperand = double.Parse(mainTextBox.Text);
                }
                catch (Exception) { }

                mainTextBox.Text = string.Empty;
            }
        }

        private void compute()
        {
            if (string.IsNullOrEmpty(mainTextBox.Text))
                mainTextBox.Text = "0";

            double currentOperand = double.Parse(mainTextBox.Text);
            double result = 0.0;

            switch (currentOperation)
            {
                case '+':
                    result = lastOperand + currentOperand;
                    break;

                case '-':
                    result = lastOperand - currentOperand;
                    break;

                case '*':
                    result = lastOperand * currentOperand;
                    break;

                case '/':
                    result = lastOperand / currentOperand;
                    break;

                default:
                    break;
            }

            mainTextBox.Text = result.ToString();
        }

        private void buttonPlusMinusClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mainTextBox.Text))
                return;

            if (mainTextBox.Text.First() == '-')
                mainTextBox.Text = mainTextBox.Text.Remove(0, 1);
            else
                mainTextBox.Text = mainTextBox.Text.Insert(0, "-");
        }

        private void buttonDotClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mainTextBox.Text))
                return;

            if (mainTextBox.Text.Contains(","))
                return;

            mainTextBox.Text += ",";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mainTextBox.Text))
                return;

            mainTextBox.Text = mainTextBox.Text.Remove(mainTextBox.Text.Length - 1);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mainTextBox.Text))
                return;

            mainTextBox.Text = string.Empty;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mainTextBox.Text))
                return;

            mainTextBox.Text = string.Empty;

            currentOperation = ' ';
            lastOperand = 0.0;
        }
    }
}
