using Calculator.Model;
using Calculator.Service;
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
        DataAccess dataAccess = new DataAccess();
        Log log = new Log();

        long storedResult = 0, prevNum = 0;
        int state = 0, prevOperation = 0;

        string expression = "";
        

        public MainPage()
        {
            InitializeComponent();
        }

        void OnNumberButtonClicked(object sender, EventArgs e)
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

        void OnClearButtonClicked(object sender, EventArgs e)
        {
            this.lblResult.Text = "0";
            this.state = 0;
        }

        void OnOperatorButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string btnText = button.Text;

            string lblText = this.lblResult.Text;
            
            this.expression += lblText + btnText;

            if (this.state == 0)
            {
                storedResult = Convert.ToInt64(lblText);
                this.state = 1;
            }

            if (this.state == 2)
            {
                Calculate(Convert.ToInt64(lblText));
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

        void Calculate(long num2)
        {

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

            prevNum = num2;

        }

        void OnEqualButtonClicked(object sender, EventArgs e)
        {
            if (this.state == 1) Calculate(this.prevNum);

            else
            {
                this.expression += this.lblResult.Text;
                Calculate(Convert.ToInt64(this.lblResult.Text));
            }

            this.lblResult.Text = Convert.ToString(this.storedResult);

            SaveLog();
        }

        async void OnHistoryButtonClicked(object sender, EventArgs e)
        {
            var historyPage = new HistoryPage();
            await Navigation.PushModalAsync(historyPage);
        }

        void SaveLog()
        {
            log.expression = this.expression;
            log.result = Convert.ToString(this.storedResult);
            //log.date = DateTime.Now;

            dataAccess.AddLog(log);

        }

    }
}
