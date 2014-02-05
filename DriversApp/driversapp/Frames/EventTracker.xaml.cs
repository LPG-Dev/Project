using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using Windows.Devices.Geolocation;
using Windows.ApplicationModel;
using Windows.UI.Core;
using DriversApp.WebserviceRef;
using Windows.Storage;
using Windows.Data.Xml.Dom;
using Windows.Storage.Pickers;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DriversApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EventTracker : Page
    {
        Teller teller = new Teller(0);
        Gps locatie;
        private Geolocator _geolocator = null;

        string eventnaam, aantalUitvoeren, snelheid, baan, versnelling;
        public EventTracker()
        {
            this.InitializeComponent();
            /* if (txtEvent.Text.Equals("Event")) { 
             GetEvents(teller);
             GetOnvoltooidEvent();
        }else{
             GetNextEvent();
     }*/
            locatie = new Gps("0", "0", "0");
            _geolocator = new Geolocator();
            _geolocator.PositionChanged += new TypedEventHandler<Geolocator, PositionChangedEventArgs>(OnPositionChanged);
            _geolocator.StatusChanged += new TypedEventHandler<Geolocator, StatusChangedEventArgs>(OnStatusChanged);
            HaalEventsOp();
        }

        public async void HaalEventsOp()
        {
            //default waarde
            int cyclusblad = 0, evnt = 0, cyclus = 0;
            StorageFolder folder = await Package.Current.InstalledLocation.GetFolderAsync("Assets");
            StorageFile xmlFile = await folder.GetFileAsync("AB123varid18.xml");
            XmlDocument xmldoc = await XmlDocument.LoadFromFileAsync(xmlFile);
            var voortgang = xmldoc.SelectSingleNode("//voortgang/text()");

            cyclusblad = Convert.ToInt32(voortgang.NodeValue.ToString().Substring(0, 2));
            evnt = Convert.ToInt32(voortgang.NodeValue.ToString().Substring(2, 2));
            cyclus = Convert.ToInt32(voortgang.NodeValue.ToString().Substring(4, 2));

            var eventnaam = xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/eventnaam/text()");

            var frequentie = xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/frequentie/text()");
            var snelheid = xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/snelheid/text()");
            var versnelling = xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/versnelling/text()");
            var baan = xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/baan/baanCode/text()");

            txtEvent.Text = "Event: " + eventnaam.NodeValue.ToString();
            txtAantalUitVoeren.Text = "Aantal keer uitvoeren: " + frequentie.NodeValue.ToString();
            txtSnelheid.Text = "Snelheid: " + snelheid.NodeValue.ToString();
            txtVersnelling.Text = "Versnelling: " + versnelling.NodeValue.ToString();
            txtBaan.Text = "Baan: " + baan.NodeValue.ToString();
        }

        private void pctInfo_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Info), teller.getTeller());
        }

        private async void pctStop_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            var messageDialog = new MessageDialog("Bent u zeker dat u wilt stoppen?");

            messageDialog.Commands.Add(new UICommand("Ja", null, 0));
            messageDialog.Commands.Add(new UICommand("Nee", null, 1));

            messageDialog.DefaultCommandIndex = 1;

            var commandGekozen = await messageDialog.ShowAsync();

            if (commandGekozen.Id.Equals(0))
            {
                this.Frame.Navigate(typeof(DriversApp.EindPagina));
            }
        }

        private void pctPauze_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(welkom));
            /*  WebserviceRef.WebServiceClient obj = new WebserviceRef.WebServiceClient();
              EventStatus eventstatus = new EventStatus();
              eventstatus.CyclCode = "Test4";
              eventstatus.EventNaam = "Cobblestones";
              eventstatus.ProcCode = "00.00-R-398";
              eventstatus.Voltooid = 2;
              obj.InsertEventStatusAsync(eventstatus);*/


            //this.Frame.Navigate(typeof(Info), teller);
        }

        async private void OnPositionChanged(Geolocator sender, PositionChangedEventArgs e)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Geoposition pos = e.Position;


                locatie.setLat(pos.Coordinate.Point.Position.Latitude.ToString());
                locatie.setLon(pos.Coordinate.Point.Position.Longitude.ToString());
                locatie.setAcc(pos.Coordinate.Accuracy.ToString());
            });
        }

        async private void OnStatusChanged(Geolocator sender, StatusChangedEventArgs e)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                switch (e.Status)
                {
                    case PositionStatus.Disabled:

                        locatie.setLat("No data");
                        locatie.setLon("No data");
                        locatie.setAcc("No data");
                        break;
                    default:
                        break;
                }
            });
        }

        private void pctNext_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            SkipEvent();
            // GetNextEvent();
        }
        public async void SkipEvent()
        {
            //open bestand
            FileOpenPicker openpicker = new FileOpenPicker();
            openpicker.ViewMode = PickerViewMode.Thumbnail;
            openpicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            openpicker.FileTypeFilter.Add(".xml");
            StorageFile xmlFile = await openpicker.PickSingleFileAsync();

            //default waarde toekennen aan variabelen
            int cyclusblad = 0, evnt = 0, cyclus = 0;
            string v_voortgang, v_cyclusblad, v_evnt, v_cyclus;

            XmlDocument xmldoc = await XmlDocument.LoadFromFileAsync(xmlFile);
            var voortgang = xmldoc.SelectSingleNode("//voortgang/text()");

            //voortgangcode ontleden
            cyclusblad = Convert.ToInt32(voortgang.NodeValue.ToString().Substring(0, 2));
            evnt = Convert.ToInt32(voortgang.NodeValue.ToString().Substring(2, 2));
            cyclus = Convert.ToInt32(voortgang.NodeValue.ToString().Substring(4, 2));

            int aantalEvents = Convert.ToInt32(xmldoc.SelectNodes("//cyclusblad["+cyclusblad+"]/event").Count());
            int cycli = Convert.ToInt32(xmldoc.SelectNodes("//cyclusblad[" + cyclusblad + "]/event/cel["+cyclus+"]").Count());
            int aantalCyclusbladen = Convert.ToInt32(xmldoc.SelectNodes("//cyclusblad").Count());

            //pas xml aan -> skipped event = volgende cel(oftewel cyclus) -> x1.
            //x = geskipt, 1 = aantal keer geskipt
            var volgCycl = (cyclus+1);
            var updateEvent = xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event["+evnt+"]/cel" + volgCycl  + "/text()");
            var huidigCycl = xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event["+evnt+"]/cel" + cyclus  + "/text()");
            if (huidigCycl.NodeValue.ToString().Substring(0, 1).Equals("x"))
            {
              var aantalSkips = Convert.ToInt32(huidigCycl.InnerText.Substring(1,huidigCycl.InnerText.Length-1));
              aantalSkips = aantalSkips + 1;
              updateEvent.InnerText = "x" + aantalSkips;
            }
            else if (huidigCycl.NodeValue.ToString().Equals("1"))
            {
                updateEvent.InnerText = "x1";
            }
           MessageDialog ms = new MessageDialog(huidigCycl.NodeValue.ToString()+" "+ updateEvent.NodeValue.ToString());
          ms.ShowAsync();

            //
            if (evnt == aantalEvents)
            {
                evnt = 1;
                if (cyclus == cycli)
                {
                    cyclus = 1;
                    if (cyclusblad == aantalCyclusbladen)
                    {
                        MessageDialog msg = new MessageDialog("Alle cyclusbladen zijn voltooid.");
                        msg.ShowAsync();
                    }
                    else { cyclusblad = cyclusblad + 1; }
                }else { cyclus = cyclus + 1; }

            }else{evnt = evnt + 1;}
            if (cyclusblad.ToString().Length == 1)
            {
                 v_cyclusblad = "0" + cyclusblad.ToString();

            }
            else 
            { 
                v_cyclusblad = cyclusblad.ToString();
            }
            if (evnt.ToString().Length == 1)
            {
                 v_evnt = "0" + evnt.ToString();
            }
            else
            {
                v_evnt = evnt.ToString();
            }
            if (cyclus.ToString().Length == 1)
            {
                v_cyclus = "0" + cyclus.ToString();
            }
            else
            {
                v_cyclus = cyclus.ToString();
            }
            v_voortgang = v_cyclusblad+""+v_evnt+""+v_cyclus;
            
            //update huidige voortgang in xml file
            xmldoc.SelectSingleNode("//voortgang").InnerText = v_voortgang;
            await xmldoc.SaveToFileAsync(xmlFile);
           
           

            var eventnaam = xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/eventnaam/text()");
            var frequentie = xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/frequentie/text()");
            var snelheid = xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/snelheid/text()");
            var versnelling = xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/versnelling/text()");
            var baan = xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/baan/baanCode/text()");

            txtEvent.Text = "Event: " + eventnaam.NodeValue.ToString();
            txtAantalUitVoeren.Text = "Aantal keer uitvoeren: " + frequentie.NodeValue.ToString();
            txtSnelheid.Text = "Snelheid: " + snelheid.NodeValue.ToString();
            txtVersnelling.Text = "Versnelling: " + versnelling.NodeValue.ToString();
            txtBaan.Text = "Baan: " + baan.NodeValue.ToString();
            
        }




        private void pctVoltooid_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
          
        }
        /*
         * onvoltooide events ophalen via WCF
         public async void GetOnvoltooidEvent()
         {
             var serviceClient = new WebserviceRef.WebServiceClient();
             var procPerWagen = await serviceClient.GetAllProceduresPerWagenAsync();
             var cyclusPerVariantList = await serviceClient.GetAllCyclusbladenPerVariantAsync();
             var EventOpvolgList = await serviceClient.GetAllEventsOpvolgingAsync();

             var query = from procPwagen in procPerWagen
                         where procPwagen.wagencode == "AB123"
                         join cyclPerVar in cyclusPerVariantList on procPwagen.procedureCode equals cyclPerVar.procedure_code
                         join eventOpvolg in EventOpvolgList on cyclPerVar.cyclusblad_code equals eventOpvolg.idCyclusblad
                         select new {eventOpvolg.baan, eventOpvolg.versnelling, eventOpvolg.snelheid, eventOpvolg.naam, eventOpvolg.frequentie, eventOpvolg.id, eventOpvolg.cel1, eventOpvolg.cel2, eventOpvolg.cel3, eventOpvolg.cel4, eventOpvolg.cel5, eventOpvolg.cel6, eventOpvolg.cel7, eventOpvolg.cel8, eventOpvolg.cel9, eventOpvolg.cel10, eventOpvolg.cel11, eventOpvolg.cel12, eventOpvolg.cel13, eventOpvolg.cel14, eventOpvolg.cel15, eventOpvolg.cel16, eventOpvolg.cel17, eventOpvolg.cel18, eventOpvolg.cel19, eventOpvolg.cel20, eventOpvolg.cel21, eventOpvolg.cel22, eventOpvolg.cel23, eventOpvolg.cel24, eventOpvolg.cel25 };
            
             foreach(var item in query){
                 if (item.cel1.Equals("1"))
                 {
                     var query1 = from procPwagen in procPerWagen
                                 where procPwagen.wagencode == "AB123"
                                 join cyclPerVar in cyclusPerVariantList on procPwagen.procedureCode equals cyclPerVar.procedure_code
                                 join eventOpvolg in EventOpvolgList on cyclPerVar.cyclusblad_code equals eventOpvolg.idCyclusblad
                                 where eventOpvolg.cel1 == "1" && eventOpvolg.id.Equals(item.cel1)
                                  select new { eventOpvolg.baan, eventOpvolg.versnelling, eventOpvolg.snelheid, eventOpvolg.naam, eventOpvolg.frequentie };
                   
                     eventnaam = "Event: " +item.naam;
                     aantalUitvoeren = "Aantal keer uitvoeren: " + item.frequentie;
                     snelheid = "Snelheid: " + item.snelheid + "km/h";
                     baan = "Baan code: " + item.baan;
                     versnelling = "Versnelling: " + item.versnelling;

                     txtBaan.Text = baan;
                     txtEvent.Text = eventnaam;
                     txtAantalUitVoeren.Text = aantalUitvoeren;
                     txtSnelheid.Text = snelheid;
                     txtVersnelling.Text = versnelling;
                 }
                 else if (item.cel2.Equals("1"))
                 {
                     var query1 = from procPwagen in procPerWagen
                                  where procPwagen.wagencode == "AB123"
                                  join cyclPerVar in cyclusPerVariantList on procPwagen.procedureCode equals cyclPerVar.procedure_code
                                  join eventOpvolg in EventOpvolgList on cyclPerVar.cyclusblad_code equals eventOpvolg.idCyclusblad
                                  where eventOpvolg.cel2 == "1" && eventOpvolg.id.Equals(item.cel2)
                                  select new { eventOpvolg.baan, eventOpvolg.versnelling, eventOpvolg.snelheid, eventOpvolg.naam, eventOpvolg.frequentie };


                     eventnaam = "Event: " + item.naam;
                     aantalUitvoeren = "Aantal keer uitvoeren: " + item.frequentie;
                     snelheid = "Snelheid: " + item.snelheid + "km/h";
                     baan = "Baan code: " + item.baan;
                     versnelling = "Versnelling: " + item.versnelling;

                     txtBaan.Text = baan;
                     txtEvent.Text = eventnaam;
                     txtAantalUitVoeren.Text = aantalUitvoeren;
                     txtSnelheid.Text = snelheid;
                     txtVersnelling.Text = versnelling;
                 }
                 else if (item.cel3.Equals("1"))
                 {
                     var query1 = from procPwagen in procPerWagen
                                  where procPwagen.wagencode == "AB123"
                                  join cyclPerVar in cyclusPerVariantList on procPwagen.procedureCode equals cyclPerVar.procedure_code
                                  join eventOpvolg in EventOpvolgList on cyclPerVar.cyclusblad_code equals eventOpvolg.idCyclusblad
                                  where eventOpvolg.cel3 == "1" && eventOpvolg.id.Equals(item.cel3)
                                  select new { eventOpvolg.baan, eventOpvolg.versnelling, eventOpvolg.snelheid, eventOpvolg.naam, eventOpvolg.frequentie };


                     eventnaam = "Event: " + item.naam;
                     aantalUitvoeren = "Aantal keer uitvoeren: " + item.frequentie;
                     snelheid = "Snelheid: " + item.snelheid + "km/h";
                     baan = "Baan code: " + item.baan;
                     versnelling = "Versnelling: " + item.versnelling;

                     txtBaan.Text = baan;
                     txtEvent.Text = eventnaam;
                     txtAantalUitVoeren.Text = aantalUitvoeren;
                     txtSnelheid.Text = snelheid;
                     txtVersnelling.Text = versnelling;
                 }

             }
         }*/
        //skip naar volgend event via WCF
        /* public async void GetNextEvent()
         {
           
             teller.setTeller(teller.getTeller() + 1);
             var serviceClient = new WebserviceRef.WebServiceClient();
             var procPerWagen = await serviceClient.GetAllProceduresPerWagenAsync();
             var cyclusPerVariantList = await serviceClient.GetAllCyclusbladenPerVariantAsync();
             var EventOpvolgList = await serviceClient.GetAllEventsOpvolgingAsync();

             var query = from procPwagen in procPerWagen
                         where procPwagen.wagencode == "AB123"
                         join cyclPerVar in cyclusPerVariantList on procPwagen.procedureCode equals cyclPerVar.procedure_code
                         join eventOpvolg in EventOpvolgList on cyclPerVar.cyclusblad_code equals eventOpvolg.idCyclusblad
                         where eventOpvolg.cel1 == "1"
                         select new { eventOpvolg.baan, eventOpvolg.versnelling, eventOpvolg.snelheid, eventOpvolg.naam, eventOpvolg.frequentie };
             if (teller.getTeller() < query.Count())
             {
                 txtBaan.Text = "Baan code: " + query.ElementAt(teller.getTeller()).baan;
                 txtEvent.Text = "Event: " + query.ElementAt(teller.getTeller()).naam;
                 txtAantalUitVoeren.Text = "Aantal keer uitvoeren: " + query.ElementAt(teller.getTeller()).frequentie;
                 txtSnelheid.Text = "Snelheid: " + query.ElementAt(teller.getTeller()).snelheid + "km/h";
                 txtVersnelling.Text = "Versnelling: " + query.ElementAt(teller.getTeller()).versnelling;
             }
             else
             {
                 var messageDialog = new MessageDialog("Cyclus voltooid!");
                 await messageDialog.ShowAsync();
                 teller.setTeller(0);
                 GetEvents(teller);
             }
         }*/
        //load first event
        /*
         * events ophalen via WCF
         * public async void GetEvents(Teller teller)
         {
             var serviceClient = new WebserviceRef.WebServiceClient();
             var procPerWagen = await serviceClient.GetAllProceduresPerWagenAsync();
             var cyclusPerVariantList = await serviceClient.GetAllCyclusbladenPerVariantAsync();
             var EventOpvolgList = await serviceClient.GetAllEventsOpvolgingAsync();


             var query = from procPwagen in procPerWagen
                         where procPwagen.wagencode == "AB123"
                         join cyclPerVar in cyclusPerVariantList on procPwagen.procedureCode equals cyclPerVar.procedure_code
                         join eventOpvolg in EventOpvolgList on cyclPerVar.cyclusblad_code equals eventOpvolg.idCyclusblad
                         where eventOpvolg.cel1 == "1"
                         select new { eventOpvolg.baan, eventOpvolg.versnelling, eventOpvolg.snelheid, eventOpvolg.naam, eventOpvolg.frequentie };
            
             eventnaam = "Event: " + query.ElementAt(teller.getTeller()).naam;
             aantalUitvoeren = "Aantal keer uitvoeren: " + query.ElementAt(teller.getTeller()).frequentie;
             snelheid = "Snelheid: " + query.ElementAt(teller.getTeller()).snelheid + "km/h";
             baan = "Baan code: " + query.ElementAt(teller.getTeller()).baan;
             versnelling = "Versnelling: " + query.ElementAt(teller.getTeller()).versnelling;
                
             txtBaan.Text = baan;
             txtEvent.Text = eventnaam;
             txtAantalUitVoeren.Text = aantalUitvoeren;
             txtSnelheid.Text = snelheid;
             txtVersnelling.Text = versnelling;
            
         }*/
    }
}
