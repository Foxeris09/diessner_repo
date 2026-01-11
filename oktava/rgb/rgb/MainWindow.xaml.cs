using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace rgb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            zmenBarvu();
        }
        private bool jeVProcesu = false;

        private void zmenBarvu()
        {
            if (sldRed == null || sldGreen == null || sldBlue == null || lblHex == null || rectColor == null)
                return;

            byte r = Convert.ToByte(sldRed.Value);
            byte g = Convert.ToByte(sldGreen.Value);
            byte b = Convert.ToByte(sldBlue.Value);
            rectColor.Fill = new SolidColorBrush(Color.FromRgb(r, g, b));
            lblHex.Content = $"#{r:X2}{g:X2}{b:X2}";
        }

        private void sldColor_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (jeVProcesu || sldRed == null || sldGreen == null || sldBlue == null)
                return;
            jeVProcesu = true;
            txtRed.Text = Convert.ToInt16(sldRed.Value).ToString();
            txtGreen.Text = Convert.ToInt16(sldGreen.Value).ToString();
            txtBlue.Text = Convert.ToInt16(sldBlue.Value).ToString();

            zmenBarvu();
            jeVProcesu = false;
        }

        private void txtColor_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (jeVProcesu)
                return;
            
            TextBox tb = sender as TextBox;
            if(int.TryParse(tb.Text, out int value))
            {
                if (value > 255)
                {
                    MessageBox.Show("Hodnota není v rozmezí 0-255");
                    tb.Text = "255";
                    return;
                }
                jeVProcesu = true;
                if (tb == txtRed)
                {
                    if (sldRed != null)
                        sldRed.Value = value;
                }
                if (tb == txtGreen)
                {
                    if (sldGreen != null)
                        sldGreen.Value = value;
                }
                if (tb == txtBlue)
                {
                    if (sldBlue != null)
                        sldBlue.Value = value;
                }
                
                
                zmenBarvu();
                jeVProcesu = false;
            }

             
        }

        private void Integer(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.All(cc => Char.IsNumber(cc));
            base.OnPreviewTextInput(e);
        }


    }
}