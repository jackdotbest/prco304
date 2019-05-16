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
    public sealed partial class POCDetailsPage : Page
    {
        public POCDetailsPage()
        {
            this.InitializeComponent();
            if (((App)Application.Current).globalPerson.getForename() != null)
            {
                fnameBox.Text = ((App)Application.Current).globalPerson.getForename();
                snameBox.Text = ((App)Application.Current).globalPerson.getSurname();
                jroleBox.Text = ((App)Application.Current).globalPerson.getJobTitle();
                emailBox.Text = ((App)Application.Current).globalPerson.getEmailAddress();
                cbTitle.SelectedValue = ((App)Application.Current).globalPerson.getTitle();
                if(((App)Application.Current).globalInvoicePerson.getForename() != null)
                {
                    sameInvoiceBox.IsChecked = false;
                    fnameBox2.Text = ((App)Application.Current).globalInvoicePerson.getForename();
                    snameBox2.Text = ((App)Application.Current).globalInvoicePerson.getSurname();
                    jroleBox2.Text = ((App)Application.Current).globalInvoicePerson.getJobTitle();
                    emailBox2.Text = ((App)Application.Current).globalInvoicePerson.getEmailAddress();
                    cbTitle2.SelectedValue = ((App)Application.Current).globalInvoicePerson.getTitle();
                }
                else
                {
                    sameInvoiceBox.IsChecked = true;
                    fnameBox2.Text = "";
                    snameBox2.Text = "";
                    jroleBox2.Text = "";
                    emailBox2.Text = "";
                    cbTitle2.Text = "";
                }
            }
        }

        private Person newPOC, newInvPOC;

        private void CbTitle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
                        
            if (sameInvoiceBox.IsChecked == true)
            {
                if (fnameBox.Text != "" || snameBox.Text != "" || jroleBox.Text != "" || emailBox.Text != "" || cbTitle.SelectedValue != null)
                {
                    try
                    {
                        newPOC = new Person(fnameBox.Text, snameBox.Text, jroleBox.Text, emailBox.Text, cbTitle.SelectedValue.ToString());
                        ((App)Application.Current).globalPerson = newPOC;
                        ((App)Application.Current).globalInvoicePerson = new Person();
                        MainPage.setTrackerStatus(2);
                    }
                    catch (NullReferenceException)
                    {
                        cbTitle.PlaceholderText = "Requires valid selectiion";
                        cbTitle2.PlaceholderText = "Requires valid selectiion";
                    }
                }
                else
                {
                    string eb = "This field is required";
                    fnameBox.PlaceholderText = eb;
                    snameBox.PlaceholderText = eb;
                    emailBox.PlaceholderText = eb;
                    cbTitle.PlaceholderText = eb;
                    jroleBox.PlaceholderText = eb;
                }
            }
            else if (sameInvoiceBox.IsChecked == false || sameInvoiceBox.IsChecked == null)
            {
                if (fnameBox2.Text != "" || snameBox2.Text != "" || jroleBox2.Text != "" || emailBox2.Text != "" || cbTitle2.SelectedValue != null || fnameBox.Text != "" || snameBox.Text != "" || jroleBox.Text != "" || emailBox.Text != "" || cbTitle.SelectedValue != null)
                {
                    try
                    {
                        newPOC = new Person(fnameBox.Text, snameBox.Text, jroleBox.Text, emailBox.Text, cbTitle.SelectedValue.ToString());
                        newInvPOC = new Person(fnameBox2.Text, snameBox2.Text, jroleBox2.Text, emailBox2.Text, cbTitle2.SelectedValue.ToString());
                        ((App)Application.Current).globalPerson = newPOC;
                        ((App)Application.Current).globalInvoicePerson = newInvPOC;
                        MainPage.setTrackerStatus(2);
                    }
                    catch (NullReferenceException)
                    {
                        cbTitle.PlaceholderText = "Requires valid selectiion";
                        cbTitle2.PlaceholderText = "Requires valid selectiion";
                    }
                }
                else
                {
                    string eb = "This field is required";
                    fnameBox.PlaceholderText = eb;
                    snameBox.PlaceholderText = eb;
                    emailBox.PlaceholderText = eb;
                    cbTitle.PlaceholderText = eb;
                    jroleBox.PlaceholderText = eb;
                    fnameBox2.PlaceholderText = eb;
                    snameBox2.PlaceholderText = eb;
                    emailBox2.PlaceholderText = eb;
                    cbTitle2.PlaceholderText = eb;
                    jroleBox2.PlaceholderText = eb;
                }

            }
        }

        private void SameInvoiceBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ToggleInvoiceView(true);
        }

        private void SameInvoiceBox_Checked(object sender, RoutedEventArgs e)
        {
            ToggleInvoiceView(false);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ToggleInvoiceView(bool x) // this handles the collapsing of the Invoice Point of Contact are when the checkbox is selected
        {
            if (!x)
            {
                fnameBox2.Visibility = Visibility.Collapsed;
                snameBox2.Visibility = Visibility.Collapsed;
                jroleBox2.Visibility = Visibility.Collapsed;
                emailBox2.Visibility = Visibility.Collapsed;
                cbTitle2.Visibility = Visibility.Collapsed;
                personIcon2.Visibility = Visibility.Collapsed;
                InvoicePOCTextBlock.Visibility = Visibility.Collapsed;

                personIcon.Margin = new Thickness(0, 48, 0, 0);
                POCTextBlock.Margin = new Thickness(0, 250, 0, 0);
                cbTitle.Margin = new Thickness(0, 290, 0, 0);
                fnameBox.Margin = new Thickness(0, 362, 0, 0);
                snameBox.Margin = new Thickness(0, 430, 0, 0);
                jroleBox.Margin = new Thickness(0, 496, 0, 0);
                emailBox.Margin = new Thickness(0, 554, 0, 0);
                sameInvoiceBox.Margin = new Thickness(0, 586, 0, 0);
                

            } 
            else if (x)
            {
                fnameBox2.Visibility = Visibility.Visible;
                snameBox2.Visibility = Visibility.Visible;
                jroleBox2.Visibility = Visibility.Visible;
                emailBox2.Visibility = Visibility.Visible;
                cbTitle2.Visibility = Visibility.Visible;
                personIcon2.Visibility = Visibility.Visible;
                InvoicePOCTextBlock.Visibility = Visibility.Visible;

                personIcon.Margin = new Thickness(0, 48, 300, 0);
                POCTextBlock.Margin = new Thickness(0, 250, 300, 0);
                cbTitle.Margin = new Thickness(0, 290, 300, 0);
                fnameBox.Margin = new Thickness(0, 362, 300, 0);
                snameBox.Margin = new Thickness(0, 430, 300, 0);
                jroleBox.Margin = new Thickness(0, 496, 300, 0);
                emailBox.Margin = new Thickness(0, 554, 300, 0);
                sameInvoiceBox.Margin = new Thickness(0, 586, 300, 0);
                
            }
            
        }
    }
}
