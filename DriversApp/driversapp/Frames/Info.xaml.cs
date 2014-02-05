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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DriversApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Info : Page
    {
        int originalTeller;   
        public Info()
        {
            
            this.InitializeComponent();
            HaalEventsOp();

        }
        public async void HaalEventsOp()
        {
            int cyclusblad = 0, evnt = 0, cyclus = 0;
            StorageFolder folder = await Package.Current.InstalledLocation.GetFolderAsync("Assets");
            StorageFile xmlFile = await folder.GetFileAsync("AB123varid18.xml");
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
                txtAantalUitVoeren.Text = "Aantal keer uitvoeren: " + item.NodeValue.ToString();
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
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            //info ophalen via WCF
          /*  try
            {
                int teller = Convert.ToInt16(e.Parameter);
                originalTeller = Convert.ToInt16(e.Parameter);
                var serviceClient = new WebserviceRef.WebServiceClient();
                var procPerWagen = await serviceClient.GetAllProceduresPerWagenAsync();
                var cyclusPerVariantList = await serviceClient.GetAllCyclusbladenPerVariantAsync();
                var EventPerCyclList = await serviceClient.GetAllEventsPerCyclusbladAsync();
                var EventList = await serviceClient.GetAllEventsAsync();
                var query = from procPwagen in procPerWagen
                            where procPwagen.wagencode.Equals("AB123")
                            join cyclPerVar in cyclusPerVariantList on procPwagen.procedureCode equals cyclPerVar.procedure_code
                            join eventPerCyclus in EventPerCyclList on cyclPerVar.cyclusblad_code equals eventPerCyclus.codeCyclusblad
                            join events in EventList on eventPerCyclus.naam equals events.code
                            select new { events.beschrijving, eventPerCyclus.baan, eventPerCyclus.versnelling, eventPerCyclus.snelheid, eventPerCyclus.naam, eventPerCyclus.frequentie };
                txtBaan.Text = "Baan code: " + query.ElementAt(teller).baan;
                txtEvent.Text = "Event code: " + query.ElementAt(teller).naam;
                txtOmschrijving.Text ="Beschrijving: "+ query.ElementAt(teller).beschrijving.ToString();
                txtAantalUitVoeren.Text = "Aantal keer uitvoeren: " + query.ElementAt(teller).frequentie;
                txtSnelheid.Text = "Snelheid: " + query.ElementAt(teller).snelheid + "km/h";
                txtVersnelling.Text = "Versnelling: " + query.ElementAt(teller).versnelling;
                
            }
            catch (Exception ex)
            {
                MessageDialog msgDialog = new MessageDialog("Something went wrong! \n" + ex.ToString(), "Error!");
                 msgDialog.ShowAsync();
            }*/
            
        }

        private void btnTerug_Click(object sender, RoutedEventArgs e)
        {
            Teller teller = new Teller(originalTeller);
            if (this.Frame.CanGoBack)
                this.Frame.Navigate(typeof(EventTracker), teller.getTeller());
        }
        
    }
}
