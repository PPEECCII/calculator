using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App11
{
    public partial class MainPage : ContentPage
    {
        public Decimal firstNumber;
        public Decimal secondNumber;
        public String operation;
        public MainPage()
        {
            InitializeComponent();
        }

        void OnNumberPress(object sender, EventArgs e)
        {
            Button numberButton = (Button)sender;
            String text = numberButton.Text;
            if (text.Equals(".") && lblValue.Text.Contains("."))
            {
                return;
            }
            lblValue.Text += numberButton.Text;
        }

        void OnOperatorPress(object sender, EventArgs e)
        {
            Decimal valueToProcess = Convert.ToDecimal("0"+lblValue.Text+(lblValue.Text.Contains(".")?"0":""));
            Button operationButton = (Button)sender;
            //String operationText = operationButton.Text;
            if (operation == null)
            {
                if (firstNumber == 0)
                {
                    firstNumber = valueToProcess;
                }
                operation = operationButton.Text;
            } 
            else {
                secondNumber = valueToProcess;
                Decimal result = process();
                firstNumber = result;
                secondNumber = 0;
                operation = (operationButton.Text.Equals("=")?null:operationButton.Text);
            }
            lblValue.Text = "";
            updateOperationLabel();

        }
        void OnClear(object sender, EventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            operation = null;
            lblOperation.Text = "";
            lblValue.Text = "";
        }
        Decimal process() {
            switch (operation)
            {
                case "X":
                    return firstNumber * secondNumber;
                case "/":
                    return firstNumber / secondNumber;
                case "+":
                    return firstNumber + secondNumber;
                case "-":
                    return firstNumber - secondNumber;
            }
            return 0;
        }
        void updateOperationLabel()
        {
            String text = "";
            if (operation != null)
            {
                text = firstNumber + " " + operation+(!lblValue.Text.Equals("")?" "+secondNumber:"");
            } else if (firstNumber != 0)
            {
                text = ""+firstNumber;
            }
            lblOperation.Text = text;
        }
    }
}
