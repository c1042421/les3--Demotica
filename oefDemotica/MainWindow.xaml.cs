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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;

namespace oefDemotica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Lichten lamp;
        Verwarming verwarming;
        PLC plc;

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            ToggleButton toggleButton = (ToggleButton)sender;
            bool btnChecked = toggleButton.IsChecked ?? false;

            switch (toggleButton.Name)
            {
                case "btnLamp":
                    lamp.Power = btnChecked;
                    break;
                case "btnDomoLamp":
                    if (btnChecked)
                    {
                        plc.DoeLichtenAan();
                    }
                    else
                    {
                        Valloirplc.DoeLichtenUit();
                    }
                    break;
                case "btnVerwarming":
                    if (btnChecked)
                    {
                        plc.ZetVerwarmingOp();
                    }
                    else
                    {
                        plc.ZetVerwarmingAf();
                    }
                    break;
            }

            updateView();
        }

        private void updateView()
        {
            updateGraden();
            updateImage();
        }

        private void updateGraden()
        {
            lblCelcius.Content = plc.Chauffage.Graden;
            lblFahrenheit.Content = plc.Chauffage.InFahrenheit();
        }

        private void updateImage()
        {
            bool lampAan = plc.SalonLichten.Power;

            string aan = "images/aan.png";
            string uit = "images/uit.gif";

            BitmapImage source;

            if (lampAan) source = MakeBitmapFor(aan);
            else source = MakeBitmapFor(uit);

            imgLamp.Source = source;
        }

        private BitmapImage MakeBitmapFor(string url)
        {
            Uri uri = new Uri(url, UriKind.Relative);
            return new BitmapImage(uri);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lamp = new Lichten();
            verwarming = new Verwarming();
            plc = new PLC();

            plc.Chauffage = verwarming;
            plc.SalonLichten = lamp;

            updateView();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = (Slider)sender;

            int graden = (int) slider.Value;

            plc.PasTemperatuurAan(graden);

            updateView();
        }
    }
}
