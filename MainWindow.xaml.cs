using Currency_Converter.Currency_Code;
using System.Text;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Currency_Converter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<Currency> currency = new List<Currency>
        {

            new Currency{ Name = "USD" , Value = 75 },
            new Currency{ Name = "EUR" , Value = 85 },
            new Currency{ Name = "CFH" , Value = 78 }
        };

        

        public MainWindow()
        {
            InitializeComponent();
            BindiningData();
            
        }

        private void BindiningData ()
        {
            DataTable dtcurrency = new DataTable();
            dtcurrency.Columns.Add("Text");
            dtcurrency.Columns.Add("Value");

            dtcurrency.Rows.Add("--Select--", 0);
            dtcurrency.Rows.Add("EUR", 85);
            dtcurrency.Rows.Add("USD", 75);
            dtcurrency.Rows.Add("POUND", 100);
            dtcurrency.Rows.Add("CFH", 78);

            FromBox.ItemsSource = dtcurrency.DefaultView;
            FromBox.DisplayMemberPath = "Text";
            FromBox.SelectedValuePath = "Value";
            FromBox.SelectedIndex = 0;
            
            ToBox.ItemsSource = dtcurrency.DefaultView;
            ToBox.ItemsSource = dtcurrency.DefaultView;
            ToBox.DisplayMemberPath = "Text";
            ToBox.SelectedValuePath = "Value";
            ToBox.SelectedIndex = 0;
        }

        private void ConvertButton(object sender, RoutedEventArgs e)
        {
            double ConvertedValue;

            //Condition to show error box if the boxes are empty
            if (Amount.Text == null || Amount.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the right Currency", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
                Amount.Focus();
                return;
            }
            else if ( FromBox.SelectedValue == null || FromBox.SelectedIndex == 0)
            {
                MessageBox.Show ("Please select the currency to convert From", "Information", MessageBoxButton.OK, MessageBoxImage.Error );
                FromBox.Focus();
                return;
            }
            else if (ToBox.SelectedValue == null || ToBox.SelectedIndex == 0)
            {
                MessageBox.Show("Please select the currency to convert To", "Information", MessageBoxButton.OK, MessageBoxImage.Error);
                ToBox.Focus();
                return;
            }


            if (FromBox.Text == ToBox.Text) 
            {
                ConvertedValue = double.Parse(Amount.Text);
                converted.Content = ToBox.Text + " " + ConvertedValue.ToString();
            }

            else
            {
                ConvertedValue = (double.Parse(FromBox.SelectedValue.ToString()) 
                    * double.Parse(Amount.Text)) 
                    / double.Parse(ToBox.SelectedValue.ToString());

                converted.Content = ToBox.Text + " " + ConvertedValue.ToString();
            }
        }

        private void ClearButton(object sender, RoutedEventArgs e)
        {

            Amount.Text = " ";
            FromBox.SelectedIndex = 0;
            ToBox.SelectedIndex = 0;
            
        }
    }
}