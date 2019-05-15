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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            this.InitializeComponent();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            MainPage.completionStatus = 0;
            ((App)Application.Current).userSession = null;
            ((App)Application.Current).globalQR = new Object.QuestionnaireResult();
            ((App)Application.Current).globalPerson = new Object.Person();
            ((App)Application.Current).globalInvoicePerson = new Object.Person();
            ((App)Application.Current).globalLocation = new Object.Location();
            ((App)Application.Current).globalOrganisation = new Object.Organisation();
        }
    }
}
