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
    /// Interaction logic for ProperMainWindow.xaml
    /// </summary>
    public partial class ProperMainWindow : Window
    {
        public ProperMainWindow()
        {
            InitializeComponent();
            DataContext = this;
            buttonList = WindowLinkContainer.WindowContanerList(["Greetings.xaml", "HelloWPF.xaml"]);

        }

        public List<WindowLinkContainer> buttonList { get; set; }

        private void ButtonWindowSelect(object sender, RoutedEventArgs e)
        {
            var newWindow = new HelloWPF();
            newWindow.Show();
        }
    }

    public class WindowLinkContainer
    {
        public string Name { get; set; }
        public WindowLinkContainer(string name)
        {
            this.Name = name;
        }

        public static List<WindowLinkContainer> WindowContanerList(IEnumerable<String> list)
        {
            return list.Select(x=>new WindowLinkContainer(x)).ToList();
        }

    }
}
