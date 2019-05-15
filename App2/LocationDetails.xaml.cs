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
using App2.Object;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LocationDetails : Page
    {
        public LocationDetails()
        {
            this.InitializeComponent();
            if(((App)Application.Current).globalLocation.getLine1() != null)
            {
                addrLine1Box.Text = ((App)Application.Current).globalLocation.getLine1();
                addrLine2Box.Text = ((App)Application.Current).globalLocation.getLine2();
                addrLine3Box.Text = ((App)Application.Current).globalLocation.getLine3();
                nameNumBox.Text = ((App)Application.Current).globalLocation.getName();
                cityBox.Text = ((App)Application.Current).globalLocation.getCity();
                postcodeBox.Text = ((App)Application.Current).globalLocation.getPostcode();

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool mainsite = true;
            Organisation tmpOrg;
            if (mainSiteCheckBox.IsChecked == false || mainSiteCheckBox.IsChecked == null)  //translate into not-null bool
            {
                mainsite = false;
            }
            else if(mainSiteCheckBox.IsChecked == true)
            {
                mainsite = true;
            }
            if (addrLine1Box.Text == "" || addrLine2Box.Text == "" || nameNumBox.Text == "" || cityBox.Text == "" || postcodeBox.Text == "")
            {
                string eb = "This field is required.";
                addrLine1Box.PlaceholderText = eb;
                addrLine2Box.PlaceholderText = eb;
                addrLine3Box.PlaceholderText = eb;
                nameNumBox.PlaceholderText = eb;
                postcodeBox.PlaceholderText = eb;
                cityBox.PlaceholderText = eb;
            }
            else
            {
                tmpOrg = ((App)Application.Current).globalOrganisation;
                Location loc = new Location(tmpOrg, nameNumBox.Text, addrLine1Box.Text, addrLine2Box.Text, addrLine3Box.Text, cityBox.Text, postcodeBox.Text, mainsite);
                ((App)Application.Current).globalLocation = loc;
                MainPage.completionStatus = 4;
            }
        }
    }
}
