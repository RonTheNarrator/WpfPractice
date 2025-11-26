using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace HelloWPFApp
{
    /// <summary>
    /// Interaction logic for AnimatedDVD.xaml
    /// </summary>
    public partial class AnimatedDVD : Window
    {
        public AnimatedDVD()
        {
            InitializeComponent();
            DataContext = this;
            SizeChanged += AnimatedDVD_UpdateAnimation;
        }

        private void AnimatedDVD_UpdateAnimation(object? sender, EventArgs e)
        {
            dvdTranslateTransform.BeginAnimation(TranslateTransform.XProperty, getNewBounceAnimation(dvdTextBlock.ActualWidth - dvdTextBlock.DesiredSize.Width));
            dvdTranslateTransform.BeginAnimation(TranslateTransform.YProperty, getNewBounceAnimation(dvdTextBlock.ActualHeight - dvdTextBlock.DesiredSize.Height));
        }

        private DoubleAnimation getNewBounceAnimation(double to, double speed = 100)
        {
           return new DoubleAnimation
            {
                From = 0,
                To = to,
                Duration = TimeSpan.FromSeconds(to / speed),
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever
            };
        }
    }
}
