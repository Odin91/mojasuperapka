using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool a = false, b = false, c = false;

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            double a=0, b=0, c=0;

            try
            {

                a = Convert.ToDouble(TB1.Text);
                b = Convert.ToDouble(TB2.Text);
                c = Convert.ToDouble(TB3.Text);
            }
            catch
            {
                MessageBox.Show("Niewłaściwe dane.");
                TB1.Text = "";
                TB2.Text = "";
                TB3.Text = "";
                debug.Text = "Niewłaściwe dane.";
            }

            double wynik = 0,x1,x2;
            double delta = Math.Pow(b,2) - 4 * a * c;

            if (delta == 0)
            {
                wynik = -b / (2 * a);
                debug.Text = "x1: " + Convert.ToString(wynik);
            }
            else if(delta>0)
            {
                x1 = (-b + delta) / (2 * a);
                x2 = (-b - delta) / (2 * a);
                debug.Text = "x1: " + Convert.ToString(x1) + ", x2: " + Convert.ToString(x2);
            }
            else
            {
                debug.Text = "Brak miejsc zerowych.";
            }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void TB1_TextInput(object sender, TextCompositionEventArgs e)
        {
        }

        private void TB1_KeyUp(object sender, KeyEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TB1.Text))
            {
                a = false;
                policz1.IsEnabled = false;

            }
            else
                a = true;
            if (a == true && b == true && c == true) policz1.IsEnabled = true;
                
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
        
        }

        private void TB3_TextChanged(object sender, TextChangedEventArgs e)
        {
            
               
            

            
            
        }

        private void TB3_KeyUp(object sender, KeyEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TB3.Text))
            {
                c = false;
                policz1.IsEnabled = false;

            }
            else
                c = true;
            if (a == true && b == true && c == true) policz1.IsEnabled = true;
        }

        private void TB3_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            blokadaKlawiszy(sender, e);
        }

        private void txtInput_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            /*
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                var text = e.DataObject.GetData(typeof(string)) as string;
                if (!Regex.IsMatch(text, "^[0-9a-zA-Z]*$"))
                {
                    //replace and recopy
                    var trimmed = Regex.Replace(text, "[^0-9a-zA-Z]+", string.Empty);
                    e.CancelCommand();
                    Clipboard.SetData(DataFormats.Text, trimmed);
                    ApplicationCommands.Paste.Execute(trimmed, e.Source as FrameworkElement);
                }
            }
             */
        }

        private void TB3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void TB3_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = "";
            tb.GotFocus -= TB3_GotFocus;
        }

        private void TB2_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = "";
            tb.GotFocus -= TB2_GotFocus;
        }

        private void TB1_GotFocus(object sender, RoutedEventArgs e)
        {
            
            TextBox tb = (TextBox)sender;
            tb.Text = "";
            tb.GotFocus -= TB1_GotFocus;
        }

        private void debug_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void debug_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Regex.IsMatch(e.Text, @"^^[\s]$"))
                e.Handled = true;

                
        }

        private void TB2_KeyUp(object sender, KeyEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TB2.Text))
            {
                b = false;
                policz1.IsEnabled = false;

            }
            else
                b = true;
            if (a == true && b == true && c == true) policz1.IsEnabled = true;
        }

        private void tb1_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (
                e.Command == ApplicationCommands.Cut ||
                e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }
        private void tb2_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (
                e.Command == ApplicationCommands.Cut ||
                e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }
        private void tb3_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (
                e.Command == ApplicationCommands.Cut ||
                e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }
        private void debug_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (
                e.Command == ApplicationCommands.Cut ||
                e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }

        private void TB2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {


            blokadaKlawiszy(sender, e);
        }

        private void TB1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            blokadaKlawiszy(sender, e);
        }




        private void blokadaKlawiszy(object sender, TextCompositionEventArgs e)
        {
            TextBox TB = (TextBox)sender;
            

            if (Regex.IsMatch(e.Text, @"^\,|[0-9]|\.|\-$"))
            {

                if ((TB.Text == "" && (e.Text == "," || e.Text == ".")) || (Regex.IsMatch(TB.Text, @"\,{1}") && (e.Text == "," || e.Text == ".")) || (Regex.IsMatch(TB.Text, @"\-{1}") && (e.Text == "-")))
                { //jeśli nie ma w oknie tekstu a chcesz wpisać przecinek/kropkę, lub jeśli jest już kropka/przecinek lub chcesz dodać kolejny 'minus', to nic nie wpisuj
                    e.Handled = true;
                }
                else if ((e.Text == "," || e.Text == ".") && !Regex.IsMatch(TB.Text, @"\,{1}"))
                {  //jeśli chcesz wpisać kropkę, to zamień ją na przecinek jeśli go nie ma jeszcze(i nie ma minusa)
                    e.Handled = true;
                    if(Regex.IsMatch(TB.Text, @"\d|(\-\d)"))TB.Text += ",";
                }
                else if (e.Text == "-")
                {
                    e.Handled = true;
                    if(!Regex.IsMatch(TB.Text, @"\-{1}"))TB.Text = TB.Text.PadLeft(TB.Text.Length + 1, '-');
                    
                }
                else if (Regex.IsMatch(e.Text, @"^[0-9]$") && Regex.IsMatch(TB.Text, @"\-{1}"))
                {
                    string cyfra=e.Text;
                    
                    TB.Text = TB.Text.PadRight(TB.Text.Length + 1, cyfra[0] );
                    e.Handled = true;
                }

            }
            else
            {
                e.Handled = true;
            }

        }

        private void rysujFunkcje()
        {

            


        }

    }
}
