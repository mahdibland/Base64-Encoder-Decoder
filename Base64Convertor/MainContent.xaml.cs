using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using Storyboard = System.Windows.Media.Animation.Storyboard;

namespace Base64Convertor
{
    /// <summary>
    /// Interaction logic for MainContent.xaml
    /// </summary>
    public partial class MainContent : UserControl
    {
        /// <summary>
        /// Set Some Helper For the First Run of program
        /// </summary>
        public MainContent()
        {
            InitializeComponent();
            const string registryKey = @"HKEY_CURRENT_USER\Base64Convertor";
            const string registyValue = "FirstRun";
            if (Convert.ToInt32(Microsoft.Win32.Registry.GetValue(registryKey, registyValue, 0)) == 0)
            {
                FirstShow.Visibility = Visibility.Visible;
                FirstShow1.Visibility = Visibility.Visible;
                FirstShow2.Visibility = Visibility.Visible;
                Microsoft.Win32.Registry.SetValue(registryKey, registyValue, 1, Microsoft.Win32.RegistryValueKind.DWord);
            }
            StateValues.DataContext = new EncodingsStatic();
        }

        private void RightTextBoxBase_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            FirstShow.Visibility = Visibility.Collapsed;
            FirstShow1.Visibility = Visibility.Collapsed;
            FirstShow2.Visibility = Visibility.Collapsed;
            BindingOperations.ClearBinding(TextBoxLeft, TextBox.TextProperty);
            TextBoxRight.IsReadOnly = false;
            TextBoxRight.IsReadOnlyCaretVisible = false;
            TextBoxLeft.Text = "";
            TextBoxRight.Text = "";
            RightText.Text = "Your Text";
            LeftText.Text = "Result";
            Binding binding = new Binding();
            binding.Path = new PropertyPath("Text");
            binding.ConverterParameter = EncodingsStatic.CurrentEncoding;
            binding.Source = TextBoxRight;
            binding.Converter = new BaseConvert();
            binding.Mode = BindingMode.OneWay;
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            TextBoxLeft.IsReadOnly = true;
            TextBoxLeft.IsReadOnlyCaretVisible = true;
            BindingOperations.SetBinding(TextBoxLeft, TextBox.TextProperty, binding);


            var textbox = sender as TextBox;
            if (textbox.Width == 300)
            {
                TextBoxRight.FontSize = 18;
                DoubleAnimation doubleAnimation = new DoubleAnimation()
                {
                    Duration = TimeSpan.FromSeconds(0.4),
                    From = 300,
                    To = 350
                };
                PointAnimation pointAnimation = new PointAnimation()
                {
                    Duration = TimeSpan.FromSeconds(0.4),
                    //From = new Point(0.51, 0.75),
                    To = new Point?(new Point(0.45, 0.75))
                };
                DoubleAnimation doubleAnimation2 = new DoubleAnimation()
                {
                    To = 100,
                    Duration = TimeSpan.FromSeconds(0.2)
                };
                ThicknessAnimation thicknessAnimation2 = new ThicknessAnimation()
                {
                    //From = new Thickness?(new Thickness(0, 0, 0, 0)),
                    To = new Thickness(0, 0, 40, 0),
                    Duration = TimeSpan.FromSeconds(0.4)
                };
                Storyboard.SetTargetProperty(thicknessAnimation2, new PropertyPath(Grid.MarginProperty));
                Storyboard.SetTargetName(thicknessAnimation2, "DecodePurpose");
                Storyboard.SetTargetProperty(doubleAnimation2, new PropertyPath("(Grid.Opacity)"));
                Storyboard.SetTargetName(doubleAnimation2, "DecodePurpose");
                Storyboard.SetTargetProperty(pointAnimation, new PropertyPath("(Border.Background).(LinearGradientBrush.EndPoint)"));
                Storyboard.SetTargetName(pointAnimation, "MainBackground");
                Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(TextBlock.WidthProperty));
                Storyboard.SetTargetName(doubleAnimation, "TextBoxRight");
                Storyboard storyboard = new Storyboard();
                storyboard.Children.Add(doubleAnimation);
                storyboard.Children.Add(pointAnimation);
                //storyboard.Children.Add(doubleAnimation2);
                storyboard.Children.Add(thicknessAnimation2);
                storyboard.Completed += (o, args) => { DecodePurpose.Opacity = 100; };
                storyboard.Begin(this);
            }

            if (TextBoxLeft.Width == 350)
            {
                TextBoxLeft.FontSize = 16;
                DoubleAnimation doubleAnimation = new DoubleAnimation()
                {
                    Duration = TimeSpan.FromSeconds(0.4),
                    From = 350,
                    To = 300
                };
                PointAnimation pointAnimation = new PointAnimation()
                {
                    Duration = TimeSpan.FromSeconds(0.4),
                    //From = new Point(0.51, 0.75),
                    To = new Point?(new Point(0.45, 0.75))
                };
                DoubleAnimation doubleAnimation2 = new DoubleAnimation()
                {
                    From = 100,
                    To = 0,
                    Duration = TimeSpan.FromSeconds(0.4)
                };
                ThicknessAnimation thicknessAnimation2 = new ThicknessAnimation()
                {
                    //From = new Thickness?(new Thickness(0, 0, 0, 0)),
                    To = new Thickness(60, 0, 0, 0),
                    Duration = TimeSpan.FromSeconds(0.4)
                };
                Storyboard.SetTargetProperty(thicknessAnimation2, new PropertyPath(Grid.MarginProperty));
                Storyboard.SetTargetName(thicknessAnimation2, "EncodePurpose");
                Storyboard.SetTargetProperty(doubleAnimation2, new PropertyPath("(Grid.Opacity)"));
                Storyboard.SetTargetName(doubleAnimation2, "EncodePurpose");

                Storyboard.SetTargetProperty(pointAnimation, new PropertyPath("(Border.Background).(LinearGradientBrush.EndPoint)"));
                Storyboard.SetTargetName(pointAnimation, "MainBackground");
                Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(TextBlock.WidthProperty));
                Storyboard.SetTargetName(doubleAnimation, "TextBoxLeft");
                Storyboard storyboard = new Storyboard();
                storyboard.Children.Add(doubleAnimation);
                storyboard.Children.Add(pointAnimation);
                storyboard.Children.Add(thicknessAnimation2);
                //storyboard.Children.Add(doubleAnimation2);
                //storyboard.Completed += (o, args) => {  };
                storyboard.Begin(this);
                EncodePurpose.Opacity = 0;
            }
            PointAnimation pointsAnimation = new PointAnimation()
            {
                From = new Point?(new Point(-2, 0.5)),
                To = new Point(2, 0.5),
                Duration = TimeSpan.FromSeconds(1)
            };
            ThicknessAnimation thicknessAnimation = new ThicknessAnimation()
            {
                From = new Thickness(0, 0, 0, 1),
                To = new Thickness(0, 0, 0, 0),
                Duration = TimeSpan.FromSeconds(0.5)
            };

            Storyboard.SetTargetProperty(pointsAnimation, new PropertyPath("(Border.Background).(LinearGradientBrush.StartPoint)"));
            Storyboard.SetTargetName(pointsAnimation, "MainBackground");
            Storyboard.SetTargetProperty(thicknessAnimation, new PropertyPath("(Border.BorderThickness)"));
            Storyboard.SetTargetName(thicknessAnimation, "MainBackground");
            Storyboard storyboard1 = new Storyboard();
            storyboard1.Children.Add(pointsAnimation);
            storyboard1.Children.Add(thicknessAnimation);
            storyboard1.Begin(this);
        }

        private void LeftTextBoxBase_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            FirstShow.Visibility = Visibility.Collapsed;
            FirstShow1.Visibility = Visibility.Collapsed;
            FirstShow2.Visibility = Visibility.Collapsed;
            BindingOperations.ClearBinding(TextBoxRight, TextBox.TextProperty);
            TextBoxLeft.Text = "";
            TextBoxRight.Text = "";
            LeftText.Text = "Your Text";
            RightText.Text = "Result";
            TextBoxLeft.IsReadOnly = false;
            TextBoxLeft.IsReadOnlyCaretVisible = false;
            Binding binding = new Binding();
            binding.Path = new PropertyPath("Text");
            binding.Source = TextBoxLeft;
            binding.ConverterParameter = EncodingsStatic.CurrentEncoding;
            binding.ConverterCulture = CultureInfo.CurrentCulture;
            binding.Converter = new FromBaseConvert();
            binding.Mode = BindingMode.OneWay;
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            TextBoxRight.IsReadOnly = true;
            TextBoxRight.IsReadOnlyCaretVisible = true;
            BindingOperations.SetBinding(TextBoxRight, TextBox.TextProperty, binding);


            var textbox = sender as TextBox;
            if (textbox.Width == 300)
            {
                TextBoxLeft.FontSize = 18;
                DoubleAnimation doubleAnimation = new DoubleAnimation()
                {
                    Duration = TimeSpan.FromSeconds(0.4),
                    From = 300,
                    To = 350
                };
                PointAnimation pointAnimation = new PointAnimation()
                {
                    Duration = TimeSpan.FromSeconds(0.4),
                    //From = new Point(0.51, 0.75),
                    To = new Point?(new Point(0.58, 0.75))
                };
                DoubleAnimation doubleAnimation2 = new DoubleAnimation()
                {
                    From = 0,
                    To = 100,
                    Duration = TimeSpan.FromSeconds(0.2)
                };
                ThicknessAnimation thicknessAnimation2 = new ThicknessAnimation()
                {
                    //From = new Thickness?(new Thickness(0, 0, 0, 0)),
                    To = new Thickness(60, 0, 0, 0),
                    Duration = TimeSpan.FromSeconds(0.4)
                };
                Storyboard.SetTargetProperty(thicknessAnimation2, new PropertyPath(Grid.MarginProperty));
                Storyboard.SetTargetName(thicknessAnimation2, "EncodePurpose");
                Storyboard.SetTargetProperty(doubleAnimation2, new PropertyPath("(Grid.Opacity)"));
                Storyboard.SetTargetName(doubleAnimation2, "EncodePurpose");
                Storyboard.SetTargetProperty(pointAnimation, new PropertyPath("(Border.Background).(LinearGradientBrush.EndPoint)"));
                Storyboard.SetTargetName(pointAnimation, "MainBackground");
                Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(TextBlock.WidthProperty));
                Storyboard.SetTargetName(doubleAnimation, "TextBoxLeft");
                Storyboard storyboard = new Storyboard();
                storyboard.Children.Add(doubleAnimation);
                storyboard.Children.Add(pointAnimation);
                //storyboard.Children.Add(doubleAnimation2);
                storyboard.Children.Add(thicknessAnimation2);
                storyboard.Completed += (o, args) => { EncodePurpose.Opacity = 100; };
                storyboard.Begin(this);

            }

            if (TextBoxRight.Width == 350)
            {
                TextBoxRight.FontSize = 16;
                DoubleAnimation doubleAnimation = new DoubleAnimation()
                {
                    Duration = TimeSpan.FromSeconds(0.4),
                    From = 350,
                    To = 300
                };
                PointAnimation pointAnimation = new PointAnimation()
                {
                    Duration = TimeSpan.FromSeconds(0.4),
                    //From = new Point(0.51, 0.75),
                    To = new Point?(new Point(0.58, 0.75))
                };
                DoubleAnimation doubleAnimation2 = new DoubleAnimation()
                {
                    To = 0,
                    Duration = TimeSpan.FromSeconds(0.2)
                };
                ThicknessAnimation thicknessAnimation2 = new ThicknessAnimation()
                {
                    //From = new Thickness?(new Thickness(0, 0, 0, 0)),
                    To = new Thickness(0, 0, 40, 0),
                    Duration = TimeSpan.FromSeconds(0.4)
                };
                Storyboard.SetTargetProperty(thicknessAnimation2, new PropertyPath(Grid.MarginProperty));
                Storyboard.SetTargetName(thicknessAnimation2, "DecodePurpose");
                Storyboard.SetTargetProperty(doubleAnimation2, new PropertyPath("(Grid.Opacity)"));
                Storyboard.SetTargetName(doubleAnimation2, "DecodePurpose");
                Storyboard.SetTargetProperty(pointAnimation, new PropertyPath("(Border.Background).(LinearGradientBrush.EndPoint)"));
                Storyboard.SetTargetName(pointAnimation, "MainBackground");
                Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(TextBlock.WidthProperty));
                Storyboard.SetTargetName(doubleAnimation, "TextBoxRight");
                Storyboard storyboard = new Storyboard();
                storyboard.Children.Add(doubleAnimation);
                storyboard.Children.Add(pointAnimation);
                storyboard.Children.Add(thicknessAnimation2);
                //storyboard.Children.Add(doubleAnimation2);
                //storyboard.Completed += (o, args) => {  };
                storyboard.Begin(this);
                DecodePurpose.Opacity = 0;
            }

            PointAnimation pointsAnimation = new PointAnimation()
            {
                From = new Point?(new Point(-2, 0.5)),
                To = new Point(2, 0.5),
                Duration = TimeSpan.FromSeconds(1)
            };
            ThicknessAnimation thicknessAnimation = new ThicknessAnimation()
            {
                From = new Thickness(0, 0, 0, 1),
                To = new Thickness(0, 0, 0, 0),
                Duration = TimeSpan.FromSeconds(0.5)
            };

            Storyboard.SetTargetProperty(pointsAnimation, new PropertyPath("(Border.Background).(LinearGradientBrush.StartPoint)"));
            Storyboard.SetTargetName(pointsAnimation, "MainBackground");
            Storyboard.SetTargetProperty(thicknessAnimation, new PropertyPath("(Border.BorderThickness)"));
            Storyboard.SetTargetName(thicknessAnimation, "MainBackground");
            Storyboard storyboard1 = new Storyboard();
            storyboard1.Children.Add(pointsAnimation);
            storyboard1.Children.Add(thicknessAnimation);
            storyboard1.Begin(this);
        }

        private void EncodeResult_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetText(TextBoxLeft.Text);
        }

        private void DecodeResult_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetText(TextBoxRight.Text);
        }

        private void OnMoreEncodingButtonPressed(object sender, MouseButtonEventArgs e)
        {

            BlurEffect blur = new BlurEffect()
            {
                Radius = 5
            };
            MainContainer.Effect = blur;
            MainContainer.Opacity = 85;
            EncodingsStatic.MainContainer = MainContainer;


            MoreEncoding.Children.Add(new MoreEncoding());
        }
    }
}
