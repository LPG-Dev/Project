using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
namespace DriversApp
{
    /// <summary>
    /// Het welkomscherm waar een xml file gekozen moet worden voor de events.
    /// </summary>
    public sealed partial class welkom : Page
    {
        private static StamFile sf = null;
        public welkom()
        {
            this.InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {

            this.Frame.Navigate(typeof(EventTracker), sf);
        }


        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            sf = e.Parameter as StamFile;
        }

        private async void OnFileClick(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openpicker = new FileOpenPicker();
            openpicker.ViewMode = PickerViewMode.Thumbnail;
            openpicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            openpicker.FileTypeFilter.Add(".xml");
            StorageFile xmlFile = await openpicker.PickSingleFileAsync();
            sf.setFile(xmlFile);
            btnStart.Visibility = Visibility.Visible;
        }
    }
}
