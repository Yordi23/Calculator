using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        long storedResult = 0;
        int state = 0;
        int prevOperation;

        public MainPage()
        {
            InitializeComponent();
        }

        void SelectNumber(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string btnText = button.Text;

            if (this.lblResult.Text == "0" || this.state == 1)
            {
                this.lblResult.Text = btnText;

                if (this.state == 1) this.state = 2;

            }

            else this.lblResult.Text += btnText;



        }

        void ClearLabel(object sender, EventArgs e)
        {
            this.lblResult.Text = "0";
            this.state = 0;
        }

        void SelectOperator(object sender, EventArgs e)
        {

            Button button = (Button)sender;
            string btnText = button.Text;

            if (this.state == 0)
            {
                storedResult = Convert.ToInt64(this.lblResult.Text);
                this.state = 1;
            }

            if (this.state == 2)
            {
                Calculate();
            }


            switch (btnText)
            {
                case "÷":
                    this.prevOperation = 0;
                    break;

                case "+":
                    this.prevOperation = 1;
                    break;

                case "-":
                    this.prevOperation = 2;
                    break;

                case "x":
                    this.prevOperation = 3;
                    break;
            }
        }

        void Calculate()
        {
                long num2 = Convert.ToInt64(this.lblResult.Text);

                switch (prevOperation)
                {
                    case 0:
                        this.storedResult /= num2;
                        break;

                    case 1:
                        this.storedResult += num2;
                        break;

                    case 2:
                        this.storedResult -= num2;
                        break;

                    case 3:
                        this.storedResult *= num2;
                        break;
                }

                this.lblResult.Text = Convert.ToString(this.storedResult);
                this.state = 1;
         
        }

        void ShowResult(object sender, EventArgs e)
        {
            Calculate();
            this.lblResult.Text = Convert.ToString(this.storedResult);           
        }

    }
}
