using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HelloWPFApp
{
    /// <summary>
    /// Interaction logic for HelloWPF.xaml
    /// </summary>
    public partial class HelloWPF : Window
    {
        public HelloWPF()
        {
            InitializeComponent();
            Pain.MouseUp += new MouseButtonEventHandler(textMouseUp);
            Pain.MouseMove += new MouseEventHandler(mouseLeave);
        }

        public void textMouseUp(object sender, MouseEventArgs e)
        {
            MessageBox.Show($"Click at {e.GetPosition(this).ToString()}", ">.<");
        }

        public void mouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            returnBox.Text = "Selection starts at character #" + textBox.SelectionStart + Environment.NewLine;
            returnBox.Text += "Selection is " + textBox.SelectionLength + " character(s) long" + Environment.NewLine;
            returnBox.Text += "Selected text: '" + textBox.SelectedText + "'";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            Pain.Foreground = new SolidColorBrush(Color.FromRgb(
                (byte)random.Next(1,255), (byte)random.Next(1, 255), (byte)random.Next(1, 255)));
        }

        private void Enable_All_Changed(object sender, RoutedEventArgs e)
        {
            bool newVal = (sender as CheckBox)!.IsChecked == true;
            CheckboxStack.Children.OfType<CheckBox>().Select(x=>x.IsChecked = newVal).ToList();
        }

        private void Checkbox_changed(object sender, RoutedEventArgs e)
        {
            var checkboxQuery = CheckboxStack.Children.OfType<CheckBox>().Select(x => x.IsChecked);
            if (checkboxQuery.Any(x=>x!.Value)) {
                if (checkboxQuery.All(x=>x!.Value))
                    Enable_All.IsChecked = true;
                else
                    Enable_All.IsChecked = null;
            }
            else
                Enable_All.IsChecked = false;
        }
    }
}
