using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OrgDetails : Page
    {
        public OrgDetails()
        {
            this.InitializeComponent();
            if(((App)Application.Current).globalOrganisation.getName() != null)
            {
                orgNameBox.Text = ((App)Application.Current).globalOrganisation.getName();
                orgSectorBox.Text = ((App)Application.Current).globalOrganisation.getSector();
                orgWebBox.Text = ((App)Application.Current).globalOrganisation.getWebAddress();
                employeesBox.Text = ((App)Application.Current).globalOrganisation.getEmployees().ToString();
                incRegBox.IsChecked = ((App)Application.Current).globalOrganisation.getIncludeRegister();
                incMarBox.IsChecked = ((App)Application.Current).globalOrganisation.getIncludeMarketing();
            }
        }

        private Object.Organisation newOrg;
        private static Object.Person POC, invPOC;

        private void SubmitBTN_Click(object sender, RoutedEventArgs e)
        {
            
            float noOfEmps = new float();
            bool regBoxChecked = false, marBoxChecked = false;
            if (employeesBox.Text != "")                        //check for empty box
            {
                try
                {
                    noOfEmps = float.Parse(employeesBox.Text);  
                }
                catch (FormatException)                         //check for valid number
                {
                    employeesBox.Text = "";                     //reset the box if not
                    employeesBox.PlaceholderText = "Please enter a valid number!";  //request valid number
                }
            }
            else
            {
                employeesBox.PlaceholderText = "Please enter a valid number!"; //if empty request valid number
            }
            if (orgWebBox.Text != "" && orgSectorBox.Text != "" && orgNameBox.Text != "") //check for emtpy bo
            {
                if (incRegBox.IsChecked == null) { regBoxChecked = false; } else if (incRegBox.IsChecked == true) { regBoxChecked = true; }   //Assume nulls to be false
                if (incMarBox.IsChecked == null) { marBoxChecked = false; } else if (incMarBox.IsChecked == true) { marBoxChecked = true; } //Assume nulls to be false
                POC = ((App)Application.Current).globalPerson; invPOC = ((App)Application.Current).globalInvoicePerson;
                newOrg = new Object.Organisation(orgNameBox.Text, orgSectorBox.Text, orgWebBox.Text, regBoxChecked, marBoxChecked, noOfEmps, POC, invPOC);
                ((App)Application.Current).globalOrganisation = newOrg;
                MainPage.setTrackerStatus(3);
            }
            else            //request entries for all fields
            {
                string eb = "This field is required.";
                orgWebBox.PlaceholderText = eb;
                orgNameBox.PlaceholderText = eb;
                orgSectorBox.PlaceholderText = eb;
            }
        }
    }
}
