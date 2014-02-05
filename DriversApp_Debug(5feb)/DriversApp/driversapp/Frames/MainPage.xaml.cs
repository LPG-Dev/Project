using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Globalization;
using Windows.ApplicationModel.Resources;
using Windows.UI.Popups;
using Windows.Storage.Streams;
using LPG_DEV5;
using System.Xml;
using System.Text;
namespace DriversApp
{
    /// <summary>
    /// De startpagina van de 
    /// </summary>
    public sealed partial class MainPage : Page
    {
        /// <summary>
        /// Initizializatie van het frame
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Het login event aanroepen door middel van het klikken op de login knop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoginKnop_Click(object sender, RoutedEventArgs e)
        {
            String login;
            String wachtwoord;

            login = txtLogin.Text;
            wachtwoord = getHashSha256(txtPaswoord.Password, "blmlwst05");            //functie om de sha256 te berekenen

            if (LogIn(login, wachtwoord))
                ShowMainApp(login);
        }


        /// <summary>
        /// Het ophalen van login gegevens en deze vergelijken emt de ingevoerde gegevens
        /// </summary>
        /// <returns> een bool om te tonen of de login correct is</returns>
        public bool LogIn(String login, String wachtwoord)
        {
            //variabele declaratie
            String currElement = "";
            int check = 0; //controlecijfer
            try
            {
                //instellen van de xml reader die de accounts moet afgaan
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ConformanceLevel = ConformanceLevel.Fragment;
                settings.IgnoreWhitespace = true;
                settings.IgnoreComments = true;
                XmlReader lezer = XmlReader.Create(@"Assets\Data\account.xml");     //xml bestand waarin de accounts zich bevinden

                while (lezer.Read())                                                 //afgaan van de xmlReader
                {
                    switch (lezer.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (lezer.Name.Equals("stamnr"))
                            {
                                currElement = lezer.Name;
                            }
                            else if (lezer.Name.Equals("wachtwoord"))
                            {
                                currElement = lezer.Name;
                            }
                            else
                            {
                                currElement = "";
                            }
                            break;
                        case XmlNodeType.Text:
                            if (currElement.Equals("stamnr"))
                                if (lezer.Value.Equals(login))
                                {
                                    check = 1;
                                }
                                else
                                {
                                    check = 0;
                                }
                            if (currElement.Equals("wachtwoord"))
                            {
                                if (lezer.Value.Equals(wachtwoord))
                                {
                                    check += 1;
                                }
                                else
                                {
                                    check = 3;
                                }
                            }
                            if (check == 2)
                                return true;
                            break;
                        case XmlNodeType.EndElement:
                            break;
                    }
                }
                if (check == 0)
                {
                    MessageDialog foutLogin = new MessageDialog("U heeft de foute login gegevens ingegeven");
                    foutLogin.ShowAsync();
                }
                else if (check == 3)
                {
                    MessageDialog foutWachtwoord = new MessageDialog("U heeft het verkeerde wachtwoord ingegeven");
                    foutWachtwoord.ShowAsync();
                }

            }
            catch (Exception e)
            {
                MessageDialog error = new MessageDialog("Error processing xml file");
                error.ShowAsync();

            }
            return false;
        }

        /// <summary>
        /// Navigeren naar het welkomsscherm
        /// </summary>
        public void ShowMainApp(String login)
        {

            StamFile sf = new StamFile(login);
            this.Frame.Navigate(typeof(welkom), sf);
        }


        /// <summary>
        /// Het berekenen van de MD5 Hash van een string
        /// </summary>
        /// <param name="str">Tekst die geëncrypteerd word</param>
        /// <param name="salt">De salt waarde</param>
        /// <returns>MD5 String</returns>
        //public string CalculateMD5Hash(string str, String salt)
        //{
        //    try
        //    {
        //        var alg = HashAlgorithmProvider.OpenAlgorithm("MD5");
        //        IBuffer buff = CryptographicBuffer.ConvertStringToBinary(str, BinaryStringEncoding.Utf8);
        //        var hashed = alg.HashData(buff);
        //        var res = CryptographicBuffer.EncodeToHexString(hashed);
        //        return res;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageDialog msgDialog = new MessageDialog("Something went wrong! \n" + ex.ToString(), "Error!");
        //        msgDialog.ShowAsync();
        //        return null;
        //    }
        //}


        /// <summary>
        /// Encrypteren naar Sha256 met een salt
        /// </summary>
        /// <param name="str">Tekst die geëncrypteerd word</param>
        /// <param name="salt">De salt waarde</param>
        /// <returns>SHA256 string</returns>
        public static string getHashSha256(string str, String salt)
        {
            try
            {
                //Converteren van de input string naar binair om in een buffer te stoppen
                IBuffer input = CryptographicBuffer.ConvertStringToBinary(str + salt, BinaryStringEncoding.Utf8);

                //het algorithme dat gebruikt zal worden toekennen en hashen
                var hasher = HashAlgorithmProvider.OpenAlgorithm("SHA256");
                IBuffer hashed = hasher.HashData(input);

                //teruggeven van de hash in een hexadecimale string
                return CryptographicBuffer.EncodeToHexString(hashed);

            }
            catch (Exception ex)
            {
                MessageDialog msgDialog = new MessageDialog("Er is iets misgelopen! \n" + ex.ToString(), "Error!");
                msgDialog.ShowAsync();
                return null;
            }
        }
    }
}
