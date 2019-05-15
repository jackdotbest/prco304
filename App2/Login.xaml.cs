using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
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
    
    public sealed partial class Login : Page
    {
        public Login()
        {
            this.InitializeComponent();
        }



        private void LoginSubmit_Click(object sender, RoutedEventArgs e)
        {
            RestClient rClient = new RestClient("token", HttpVerbs.POST);
            string apiResponse = rClient.makeLoginRequest(usernameField.Text, passwordField.Password);
            string userSess = string.Empty;
            if (apiResponse.Contains("400"))
            {
                passwordField.Password = "";
                responseBlock.Text = "Invalid login details. Please check your details and try again.";
            }
            else
            {
                userSess = apiResponse.Substring(17,491);
                ((App)Application.Current).userSession = userSess;
                MainPage.completionStatus = 1;
                responseBlock.Text = "Login Succesful: Please open the sidebar and click on the next section.";
                
            }

            
            

            //responseBlock.Text = apiResponse;
        }

        private void getUserSession()
        {

        }
    }
}
