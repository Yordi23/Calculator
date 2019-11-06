using Calculator.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : ContentPage
    {
        DataAccess dataAccess = new DataAccess();
        public HistoryPage()
        {
            InitializeComponent();
            var sourceData = dataAccess.GetLogs();
            listLog.ItemsSource = sourceData;
        }
    }
}