using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class welkom : Page
    {
          
        public welkom()
        {
             this.InitializeComponent();
            HaalDataOp();

            prLoading.Visibility = Visibility.Collapsed; 
           // lblPleaseWait.Visibility = Visibility.Collapsed;
            btnStart.Visibility = Visibility.Visible;
            lblWelcome.Visibility = Visibility.Visible;
            
        }
        //teller ophalen van Page: EventTracker
     

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            
            this.Frame.Navigate(typeof(EventTracker));
        }
        public async void HaalDataOp()
        {
            try
            {
                var serviceClient = new WebserviceRef.WebServiceClient();
                var accountList = await serviceClient.GetAllAccountsAsync();
                var adminList = await serviceClient.GetAllAdminsAsync();
                
                var cyclusList = await serviceClient.GetAllCyclusAsync();
                
                var eventList = await serviceClient.GetAllEventsAsync();
                var niveausList = await serviceClient.GetAllNiveausAsync();
                var ploegenList = await serviceClient.GetAllPloegenAsync();
                var puntenPerBaanList = await serviceClient.GetAllCoordinatenAsync();
                
                var testbaanList = await serviceClient.GetAllTestbanenAsync();
                var testchauffeurPerCyclusList = await serviceClient.GetAllTestchauffeurPerCyclusAsync();
                var testchauffeursList = await serviceClient.GetAllTestChauffeursAsync();
                var testprocedureList = await serviceClient.GetAllTestProceduresAsync();
               //eventList.Where(i => i.code.Contains( "bgp")).Select(j => j.);
            }
            catch (Exception e)
            {
                MessageDialog dialog = new MessageDialog("Failed to get data from database!\n" + e.ToString(), "Fatal Error");
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
