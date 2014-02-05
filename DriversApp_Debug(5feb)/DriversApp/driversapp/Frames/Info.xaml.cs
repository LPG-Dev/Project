using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.Data.Xml.Dom;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using DriversApp;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DriversApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Info : Page
    {
        StamFile sf = null;
       
        public Info()
        {
            
            this.InitializeComponent();
            //HaalEventOp();

        }
        public async void HaalEventOp()
        {
            int cyclusblad = 0, evnt = 0, cyclus = 0;

            StorageFile xmlFile = sf.getFile();
            XmlDocument xmldoc = await XmlDocument.LoadFromFileAsync(xmlFile);
            var voortgang = xmldoc.SelectNodes("//voortgang/text()");

            foreach (var item in voortgang)
            {
                cyclusblad = Convert.ToInt32(item.NodeValue.ToString().Substring(0, 2));
                evnt = Convert.ToInt32(item.NodeValue.ToString().Substring(2, 2));
                cyclus = Convert.ToInt32(item.NodeValue.ToString().Substring(4, 2));
            }


            var eventnaam = xmldoc.SelectNodes("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/eventnaam/text()");
            var beschrijving = xmldoc.SelectNodes("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/beschrijving/text()");
            var frequentie = xmldoc.SelectNodes("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/frequentie/text()");
            var snelheid = xmldoc.SelectNodes("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/snelheid/text()");
            var versnelling = xmldoc.SelectNodes("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/versnelling/text()");
            var baan = xmldoc.SelectNodes("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/baan/baanCode/text()");
            foreach (var item in eventnaam)
            {
                txtEvent.Text = "Event: " + item.NodeValue.ToString();
            }
            foreach (var item in beschrijving)
            {
                txtOmschrijving.Text = "Beschrijving: " + item.NodeValue.ToString();
            }
            foreach (var item in frequentie)
            {
                txtAantalUitVoeren.Text = "Frequentie: " + item.NodeValue.ToString();
            }
            foreach (var item in snelheid)
            {
                txtSnelheid.Text = "Snelheid: " + item.NodeValue.ToString();
            }
            foreach (var item in versnelling)
            {
                txtVersnelling.Text = "Versnelling: " + item.NodeValue.ToString();
            }
            foreach (var item in baan)
            {
                txtBaan.Text = "Baan: " + item.NodeValue.ToString();
            }

        }
        protected  override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                sf = e.Parameter as StamFile;
                HaalEventOp();
            }
            catch
            { }
        }

        private void btnTerug_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
                this.Frame.Navigate(typeof(EventTracker), sf);
        }
        
    }
}
