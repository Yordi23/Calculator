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
        int storedResult = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        void SelectNumber(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string btnText = button.Text;

            if (this.lblResult.Text == "0")
            {
                this.lblResult.Text = btnText;
                return;
            }

            this.lblResult.Text += btnText;
        }

        void ClearLabel(object sender, EventArgs e)
        {
            this.lblResult.Text = "0";
        }

        void SelectOperator(object sender, EventArgs e)
        {
            storedResult = Convert.ToInt32(this.lblResult.Text);

            Button button = (Button)sender;
            string btnText = button.Text;

            switch (btnText)
            {
                case ""
            }
        }

    }
}
