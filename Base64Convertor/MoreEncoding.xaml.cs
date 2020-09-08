using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Base64Convertor
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class MoreEncoding : UserControl
    {
        public MoreEncoding()
        {
            InitializeComponent();
        }

        private async void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e)
        {
            List<Encodings> encodings = new List<Encodings>();


            await Task.Run(() => { encodings = new List<Encodings>(EncodingsStatic.EncodeList.Select(x => new Encodings() { EncodeName = x })); });


            ComboBoxEncodes.ItemsSource = encodings;
        }

        private void OnMoreEncodingButtonPressed(object sender, MouseButtonEventArgs e)
        {
            try
            {
                EncodingsStatic.CurrentEncodingName = ((Encodings)ComboBoxEncodes.SelectedValue).EncodeName;
            }
            catch (Exception exception)
            {
                EncodingsStatic.CurrentEncodingName = "utf-8";
            }
            
            EncodingsStatic.CurrentEncoding = Encoding.GetEncoding(EncodingsStatic.CurrentEncodingName);

            this.Visibility = Visibility.Collapsed;
            EncodingsStatic.MainContainer.Opacity = Opacity;
            EncodingsStatic.MainContainer.Effect = null;
            new MainContent().StateValues.DataContext = this;
            EncodingsStatic.MainContainer.Children.Clear();
            var data = new MainContent();
            data.EncodeState.Text = "Encoding: " + EncodingsStatic.CurrentEncodingName;
            EncodingsStatic.MainContainer.Children.Add(data);


           EncodingsStatic.State = "Encoding: " + EncodingsStatic.CurrentEncodingName;
        }
    }
}
