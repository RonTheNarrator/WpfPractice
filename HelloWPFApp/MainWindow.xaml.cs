using System.Windows;
using System.Windows.Controls;

namespace HelloWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            buttonList = WindowLinkContainer.WindowContanerList([typeof(GreetingsWindow), typeof(HelloWPF), typeof(AnimatedButtonWindow), typeof(StopwatchWindow)]);
        }

        public List<WindowLinkContainer> buttonList { get; set; }

        private void ButtonWindowSelect(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            var windowLink = (WindowLinkContainer)clickedButton.DataContext;
            var newWindow = windowLink.CreateWindowInstance();
            newWindow.Show();
        }
    }

    public class WindowLinkContainer
    {
        public string Name {
            get{
                return LinkedWindowType.Name;
            }
        }

        public Type LinkedWindowType { get; }
        public WindowLinkContainer(Type windowMemberType)
        {
            if (!typeof(Window).IsAssignableFrom(windowMemberType))
            {
                throw new ArgumentException("Type must be a Window");
            }
            this.LinkedWindowType = windowMemberType;
        }

        public Window CreateWindowInstance()
        {
            return (Window)Activator.CreateInstance(this.LinkedWindowType)!;
        }

        public static List<WindowLinkContainer> WindowContanerList(IEnumerable<Type> list)
        {
            return list.Select(x=>new WindowLinkContainer(x)).ToList();
        }

    }
}
