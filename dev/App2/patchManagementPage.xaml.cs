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
    public sealed partial class patchManagementPage : Page
    {
        public patchManagementPage()
        {
            this.InitializeComponent();
            if (((App)Application.Current).globalQR.SevenPointOne)
            {
                answerSevenPointOne.IsChecked = true;
                answerSevenPointTwo.IsChecked = true;
                answerSevenPointThree.IsChecked = true;
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if(checkBoxToBool.Convert(answerSevenPointOne) && checkBoxToBool.Convert(answerSevenPointTwo) && checkBoxToBool.Convert(answerSevenPointThree))
            {
                ((App)Application.Current).globalQR.SevenPointOne = true;
                ((App)Application.Current).globalQR.SevenPointTwo = true;
                ((App)Application.Current).globalQR.SevenPointThree = true;
            }
            else
            {
                string eb = "This is required to continue.";
                answerSevenPointOne.Content = eb;
                answerSevenPointTwo.Content = eb;
                answerSevenPointThree.Content = eb;
            }
        }
    }
}
