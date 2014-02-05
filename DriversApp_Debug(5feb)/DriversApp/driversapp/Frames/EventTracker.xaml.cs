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
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DriversApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EventTracker : Page
    {
        StamFile sf = null;
        int aantalEvents = 0;
        StorageFile xmlFile = null;
        XmlDocument xmldoc = null;
        Teller teller = new Teller(0);
        Gps locatie;
        private Geolocator _geolocator = null;

        string eventnaam, aantalUitvoeren, snelheid, baan, versnelling;
        public EventTracker()
        {
            List<string> events = new List<string>();
            this.InitializeComponent();
            
            locatie = new Gps("0", "0", "0");
            _geolocator = new Geolocator();
            _geolocator.PositionChanged += new TypedEventHandler<Geolocator, PositionChangedEventArgs>(OnPositionChanged);
            _geolocator.StatusChanged += new TypedEventHandler<Geolocator, StatusChangedEventArgs>(OnStatusChanged);
        
           
        }
        public async void vulLijst(List<string> e)
        {
            try
            {
                XmlDocument xmldoc = await XmlDocument.LoadFromFileAsync(sf.getFile());
                var voortgang = xmldoc.SelectSingleNode("//voortgang/text()");
                var cyclusblad = Convert.ToInt32(voortgang.NodeValue.ToString().Substring(0, 2));
                var evnt = Convert.ToInt32(voortgang.NodeValue.ToString().Substring(2, 2));
                var cyclus = Convert.ToInt32(voortgang.NodeValue.ToString().Substring(4, 2));
               
                lstbEvents.Items.Clear();
                await vulLijst2(e);
                foreach (string s in e)
                {
                    lstbEvents.Items.Add(s);
                }
                lstbEvents.SelectedIndex = lstbEvents.Items.IndexOf(xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/eventnaam/text()").NodeValue.ToString());
                
            }catch{}
        }
        public async Task<List<string>> vulLijst2(List<string> e)
        {
            XmlDocument xmldoc = await XmlDocument.LoadFromFileAsync(sf.getFile());
            var voortgang = xmldoc.SelectSingleNode("//voortgang/text()");
            int cyclusblad = 0, evnt = 0, cyclus = 0;
            
            cyclusblad = Convert.ToInt32(voortgang.NodeValue.ToString().Substring(0, 2));
            evnt = Convert.ToInt32(voortgang.NodeValue.ToString().Substring(2, 2));
            cyclus = Convert.ToInt32(voortgang.NodeValue.ToString().Substring(4, 2));
            int aantalEvents = Convert.ToInt32(xmldoc.SelectNodes("//cyclusblad[" + cyclusblad + "]/event").Count());
            for (int i = 1; i <= aantalEvents; i++)
            {
                try
                {
                    if (xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + i + "]/cel" + cyclus + "/text()").NodeValue.Equals("0") || xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + i + "]/cel" + cyclus + "/text()").NodeValue.ToString().Substring(0, 1).Equals("x"))
                    {

                        e.Add(xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + i + "]/eventnaam/text()").NodeValue.ToString());
                    }
                    
                }
                catch (Exception ex)
                {

                }



            }
            return e;
        }
      public async void SetCurrentEvent()
        {
            Event e = await HaalEventsOp();

            txtEvent.Text = e.eventNaam;
            txtAantalUitVoeren.Text += e.frequentie;
            txtSnelheid.Text += e.snelheid;
            txtVersnelling.Text += e.versnelling;
            txtBaan.Text += e.baan;
            lstbEvents.SelectedIndex = lstbEvents.Items.IndexOf(e.eventNaam);
        }
        public async Task<Event> HaalEventsOp()
        {
            //default waarde toekennen aan variabelen
            int cyclusblad = 0, evnt = 0, cyclus = 0, aantalEvents = 0, cycli = 0, aantalCyclusbladen = 0;
            string v_voortgang="", v_cyclusblad="", v_evnt="", v_cyclus="";
            int frequentie = 0;
            XmlDocument xmldoc = await XmlDocument.LoadFromFileAsync(sf.getFile());
            var voortgang = xmldoc.SelectSingleNode("//voortgang/text()");

            cyclusblad = Convert.ToInt32(voortgang.NodeValue.ToString().Substring(0, 2));
            evnt = Convert.ToInt32(voortgang.NodeValue.ToString().Substring(2, 2));
            cyclus = Convert.ToInt32(voortgang.NodeValue.ToString().Substring(4, 2));

             aantalEvents = Convert.ToInt32(xmldoc.SelectNodes("//cyclusblad[" + cyclusblad + "]/event").Count());
             cycli = Convert.ToInt32(xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/cycli/text()").NodeValue);
             aantalCyclusbladen = Convert.ToInt32(xmldoc.SelectNodes("//cyclusblad").Count());
             int volgCycl = cyclus + 1;
            var updateEvent = xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/cel" + volgCycl + "/text()");
            var huidigCycl = xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/cel" + cyclus + "/text()");

            v_cyclusblad = voortgang.NodeValue.ToString().Substring(0, 2);
            v_evnt = voortgang.NodeValue.ToString().Substring(2, 2);
            v_cyclus = voortgang.NodeValue.ToString().Substring(4, 2);

            //zoek eerste event dat nog niet gereden is.
            while (!xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/cel" + cyclus + "/text()").NodeValue.Equals("0"))
            {
                 //neem volgende event
                evnt = evnt + 1;
                //als huidige event = laatste event -> neem volgende cyclus
                if (evnt > aantalEvents)
                {
                    evnt = 1;
                    cyclus = cyclus + 1;
                    //als huidige cyclus = laatste cyclus -> neem volgend cyclusblad
                    if (cyclus > cycli)
                    {
                        cyclus = 1;
                        cyclusblad = cyclusblad + 1;
                    }
                }
            }//eind while

            //omzetten naar het juiste formaat bv 113 -> 010103
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
           
            v_voortgang = v_cyclusblad + "" + v_evnt + "" + v_cyclus;
            //voortgang opslaan
            xmldoc.SelectSingleNode("//voortgang").InnerText = v_voortgang;
            await xmldoc.SaveToFileAsync(sf.getFile());

            cyclusblad = Convert.ToInt32(v_cyclusblad);
            evnt = Convert.ToInt32(v_evnt);
            cyclus = Convert.ToInt32(v_cyclus);

               var eventnaam = xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/eventnaam/text()");
               if (huidigCycl.NodeValue.ToString().Substring(0, 1).Equals("x"))
               {
                   frequentie = Convert.ToInt32(huidigCycl.NodeValue.ToString().Substring(1, huidigCycl.NodeValue.ToString().Length - 1)) * Convert.ToInt32(xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/frequentie/text()").NodeValue) + Convert.ToInt32(xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/frequentie/text()").NodeValue);
               }
               else
               {
                    frequentie = Convert.ToInt32(xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/frequentie/text()").NodeValue);
               }
                var snelheid = xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/snelheid/text()");
                var versnelling = xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/versnelling/text()");
                var baan = xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/baan/baanCode/text()");
               /* txtEvent.Text = eventnaam.NodeValue.ToString();
                txtAantalUitVoeren.Text = "Frequentie: " + frequentie.NodeValue.ToString();
                txtSnelheid.Text = "Snelheid: " + snelheid.NodeValue.ToString();
                txtVersnelling.Text = "Versnelling: " + versnelling.NodeValue.ToString();
                txtBaan.Text = "Baan: " + baan.NodeValue.ToString();
            */
                Event e = new Event(eventnaam.NodeValue.ToString(), Convert.ToInt32(frequentie)
                                    , snelheid.NodeValue.ToString(), versnelling.NodeValue.ToString(), baan.NodeValue.ToString());
                return e;
        }

        private void pctInfo_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Info), sf);
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
                this.Frame.Navigate(typeof(DriversApp.welkom),sf);
            }
        }

        private void pctPauze_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(welkom),sf);
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
                        BitmapImage bmi = new BitmapImage(new Uri("ms-appx:///Assets/Images/gps_no.png"));
                        imgGPS.Source = bmi;

                        locatie.setLat("No data");
                        locatie.setLon("No data");
                        locatie.setAcc("No data");
                        break;
                    default:
                        BitmapImage bmi2 = new BitmapImage(new Uri("ms-appx:///Assets/Images/gps_yes.png"));
                        imgGPS.Source = bmi2;
                        break;
                }
            });
        }
        private void pctNext_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            SkipEvent();
          
        }
        public async void SkipEvent()
        {
            var messageDialog = new MessageDialog("Bent u zeker dat u wilt overslaan?");

            messageDialog.Commands.Add(new UICommand("Ja", null, 0));
            messageDialog.Commands.Add(new UICommand("Nee", null, 1));

            messageDialog.DefaultCommandIndex = 1;

            var commandGekozen = await messageDialog.ShowAsync();

            if (commandGekozen.Id.Equals(0))
            {
                StorageFile xmlFile = sf.getFile();

                //default waarde toekennen aan variabelen
                int cyclusblad = 0, evnt = 0, cyclus = 0, frequentie = 0;
                string v_voortgang="", v_cyclusblad="", v_evnt="", v_cyclus="";

                XmlDocument xmldoc = await XmlDocument.LoadFromFileAsync(xmlFile);
                var voortgang = xmldoc.SelectSingleNode("//voortgang/text()");

                //voortgangcode ontleden
                cyclusblad = Convert.ToInt32(voortgang.NodeValue.ToString().Substring(0, 2));
                evnt = Convert.ToInt32(voortgang.NodeValue.ToString().Substring(2, 2));
                cyclus = Convert.ToInt32(voortgang.NodeValue.ToString().Substring(4, 2));
                int vergelijkCyclus = cyclus;
                int aantalEvents = Convert.ToInt32(xmldoc.SelectNodes("//cyclusblad[" + cyclusblad + "]/event").Count());
                int cycli = Convert.ToInt32(xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/cycli/text()").NodeValue); 
                int aantalCyclusbladen = Convert.ToInt32(xmldoc.SelectNodes("//cyclusblad").Count());

                //pas xml aan -> skipped event = volgende cel(oftewel cyclus) -> x1.
                //x = geskipt, 1 = aantal keer geskipt
                var volgCycl = (cyclus + 1);
                var updateEvent = xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/cel" + volgCycl + "/text()");
                var huidigCycl = xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/cel" + cyclus + "/text()");
                //als huidig cyclus al een geskipte event extra heeft, tel dan 1 extra en schrijf weg naar volgende keer wanneer dezelfde event gereden moet worden
                if (xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/cel" + cyclus + "/text()").NodeValue.ToString().Substring(0, 1).Equals("x"))
                {
                    var aantalSkips = Convert.ToInt32(huidigCycl.InnerText.Substring(1,huidigCycl.InnerText.Length - 1));
                    aantalSkips = aantalSkips + 1;
                    
                    while (!xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/cel" + volgCycl + "/text()").NodeValue.Equals("0"))
                    {
                        volgCycl = volgCycl + 1;
                    }
                    xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/cel" + volgCycl + "/text()").InnerText = "x" + aantalSkips;
                }
                else
                {
                    while (!xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/cel" + volgCycl + "/text()").NodeValue.Equals("0"))
                    {
                        volgCycl = volgCycl + 1;
                    }
                    xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/cel" + volgCycl + "/text()").InnerText = "x1";
                    
                }

                //als huidige event = laatste event -> neem volgende cyclus
              if (evnt == aantalEvents)
                {
                    evnt = 1;
                    cyclus = cyclus + 1;
                    //als huidige cyclus = laatste cyclus -> neem volgend cyclusblad
                    if (cyclus == cycli)
                    {
                        cyclus = 1;
                        cyclusblad = cyclusblad + 1;
                        if (cyclusblad == aantalCyclusbladen)
                        {
                            MessageDialog voltooid = new MessageDialog("Cyclusblad voltooid!");
                            voltooid.ShowAsync();
                        }
                    }

                }
                else
                {
                    evnt = evnt + 1;
                }
                    //toon volgende event dat gereden moet worden
                while (!xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/cel" + cyclus + "/text()").NodeValue.ToString().Equals("0") && !xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/cel" + cyclus + "/text()").NodeValue.ToString().Substring(0, 1).Equals("x"))
                    {
                      
                        if (evnt >= aantalEvents)
                        {
                            evnt = 1;
                            cyclus = cyclus + 1;
                            //als huidige cyclus = laatste cyclus -> neem volgend cyclusblad
                            if (cyclus >= cycli)
                            {
                                cyclus = 1;
                                cyclusblad = cyclusblad + 1;
                                if (cyclusblad >= aantalCyclusbladen)
                                {
                                    MessageDialog voltooid = new MessageDialog("Cyclusblad voltooid!");
                                    voltooid.ShowAsync();
                                }
                            }
                            //neem volgende event
                        }
                        else
                        {
                            evnt = evnt + 1;
                        }
                    }//eind while

               

                

                //pas formaat aan bv.113 ->010103
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
                    updateEvent = xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/cel" + cyclus + "/text()");

                
                v_voortgang = v_cyclusblad + "" + v_evnt + "" + v_cyclus;
                //update huidige voortgang en frequentie in xml file 
                
                xmldoc.SelectSingleNode("//voortgang").InnerText = v_voortgang;
                await xmldoc.SaveToFileAsync(xmlFile);

                var eventnaam = xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/eventnaam/text()");
                if (xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/cel" + cyclus + "/text()").NodeValue.ToString().Substring(0, 1).Equals("x"))
                {
                    var aantalSkips = Convert.ToInt32(xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/cel" + cyclus + "/text()").NodeValue.ToString().Substring(1, xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/cel" + cyclus + "/text()").NodeValue.ToString().Length -1));
                    var vasteFrequentie = Convert.ToInt32(xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/frequentie/text()").NodeValue);
                    frequentie = vasteFrequentie + (vasteFrequentie * aantalSkips);
                }
                else
                {
                    frequentie = Convert.ToInt32(xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/frequentie/text()").NodeValue);
                }
                var snelheid = xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/snelheid/text()");
                var versnelling = xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/versnelling/text()");
                var baan = xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/baan/baanCode/text()");

                txtEvent.Text = eventnaam.NodeValue.ToString();
                txtAantalUitVoeren.Text = "Frequentie: " + frequentie.ToString();
                txtSnelheid.Text = "Snelheid: " + snelheid.NodeValue.ToString();
                txtVersnelling.Text = "Versnelling: " + versnelling.NodeValue.ToString();
                txtBaan.Text = "Baan: " + baan.NodeValue.ToString();
                if(cyclus != vergelijkCyclus){
                    List<string> events = new List<string>();
                vulLijst(events);
                }
                else
                {
                    lstbEvents.SelectedIndex = lstbEvents.Items.IndexOf(txtEvent.Text);

                }
            }
            
            
        }
        private async void pctVoltooid_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            StorageFile xmlFile = sf.getFile();

            //default waarde toekennen aan variabelen
            int cyclusblad = 0, evnt = 0, cyclus = 0, frequentie = 0;
            string v_voortgang="", v_cyclusblad="", v_evnt="", v_cyclus="";

            XmlDocument xmldoc = await XmlDocument.LoadFromFileAsync(xmlFile);
            var voortgang = xmldoc.SelectSingleNode("//voortgang/text()");

            //voortgangcode ontleden
            cyclusblad = Convert.ToInt32(voortgang.NodeValue.ToString().Substring(0, 2));
            evnt = Convert.ToInt32(voortgang.NodeValue.ToString().Substring(2, 2));
            cyclus = Convert.ToInt32(voortgang.NodeValue.ToString().Substring(4, 2));
            int vergelijkCyclus = cyclus;
            int aantalEvents = Convert.ToInt32(xmldoc.SelectNodes("//cyclusblad[" + cyclusblad + "]/event").Count());
            int cycli = Convert.ToInt32(xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/cycli/text()").NodeValue);
            int aantalCyclusbladen = Convert.ToInt32(xmldoc.SelectNodes("//cyclusblad").Count());
            var updateEvent = xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/cel" + evnt+1 + "/text()");

           var huidigCycl = xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/cel" + cyclus + "/text()");
            
               huidigCycl.InnerText = sf.getStamnr();

               //als huidige event = laatste event -> neem volgende cyclus
               if (evnt == aantalEvents)
               {
                   evnt = 1;
                   cyclus = cyclus + 1;
                   //als huidige cyclus = laatste cyclus -> neem volgend cyclusblad
                   if (cyclus == cycli)
                   {
                       cyclus = 1;
                       cyclusblad = cyclusblad + 1;
                       if (cyclusblad == aantalCyclusbladen)
                       {
                           MessageDialog voltooid = new MessageDialog("Cyclusblad voltooid!");
                           voltooid.ShowAsync();
                       }
                   }

               }
               else
               {
                   evnt = evnt + 1;
               }
               //toon volgende event dat gereden moet worden
               while (!xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/cel" + cyclus + "/text()").NodeValue.Equals("0") && !xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/cel" + cyclus  + "/text()").NodeValue.ToString().Substring(0, 1).Equals("x"))
               {

                   if (evnt == aantalEvents)
                   {
                       evnt = 1;
                       cyclus = cyclus + 1;
                       //als huidige cyclus = laatste cyclus -> neem volgend cyclusblad
                       if (cyclus == cycli)
                       {
                           cyclus = 1;
                           cyclusblad = cyclusblad + 1;
                           if (cyclusblad == aantalCyclusbladen)
                           {
                               MessageDialog voltooid = new MessageDialog("Cyclusblad voltooid!");
                               voltooid.ShowAsync();
                           }
                       }
                       //neem volgende event
                   }
                   else
                   {
                       evnt = evnt + 1;
                   }
               }//eind while





               //pas formaat aan bv.113 ->010103
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
               updateEvent = xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/cel" + cyclus + "/text()");


               v_voortgang = v_cyclusblad + "" + v_evnt + "" + v_cyclus;
               //update huidige voortgang in xml file
               xmldoc.SelectSingleNode("//voortgang").InnerText = v_voortgang;
               await xmldoc.SaveToFileAsync(xmlFile);

               var eventnaam = xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/eventnaam/text()");
               if (xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/cel" + cyclus + "/text()").NodeValue.ToString().Substring(0, 1).Equals("x"))
               {
                   var aantalSkips = Convert.ToInt32(xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/cel" + cyclus + "/text()").NodeValue.ToString().Substring(1, xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/cel" + cyclus + "/text()").NodeValue.ToString().Length - 1));
                   var vasteFrequentie = Convert.ToInt32(xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/frequentie/text()").NodeValue);
                   frequentie = vasteFrequentie + (vasteFrequentie * aantalSkips);
               }
               else
               {
                   frequentie = Convert.ToInt32(xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/frequentie/text()").NodeValue);
               }
               var snelheid = xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/snelheid/text()");
               var versnelling = xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/versnelling/text()");
               var baan = xmldoc.SelectSingleNode("//cyclusblad[" + cyclusblad + "]/event[" + evnt + "]/baan/baanCode/text()");

               txtEvent.Text = eventnaam.NodeValue.ToString();
               txtAantalUitVoeren.Text = "Frequentie: " + frequentie.ToString();
               txtSnelheid.Text = "Snelheid: " + snelheid.NodeValue.ToString();
               txtVersnelling.Text = "Versnelling: " + versnelling.NodeValue.ToString();
               txtBaan.Text = "Baan: " + baan.NodeValue.ToString();
               if (cyclus != vergelijkCyclus)
               {
                   List<string> events = new List<string>();
                   vulLijst(events);
               }
               else
               {
                   lstbEvents.SelectedIndex = lstbEvents.Items.IndexOf(txtEvent.Text);

               }
        }

        protected  override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                List<string> events = new List<string>();
                sf = e.Parameter as StamFile;
                
               
                vulLijst(events);
                SetCurrentEvent();
                lstbEvents.SelectedItem = txtEvent.Text;
            }catch
            {}
        }
    }
}
