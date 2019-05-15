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
    public sealed partial class pbapage : Page
    {
        public pbapage()
        {
            this.InitializeComponent();
            if (((App)Application.Current).globalQR.TwoPointThree)
            {
                answerTwoPointOne.Text = ((App)Application.Current).globalQR.TwoPointOne;
                answerTwoPointTwo.Text = ((App)Application.Current).globalQR.TwoPointTwo;
                yesButton.IsChecked = true;
            }
        }

        private void Section2SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (answerTwoPointOne.Text != "" || answerTwoPointTwo.Text != "")
            {
                if (yesButton.IsChecked == noButton.IsChecked)
                {
                    radiobuttonText.Text = "Please select one answer:";
                    radiobuttonText.Visibility = Visibility.Visible;

                }
                else
                {
                    ((App)Application.Current).globalQR.TwoPointOne = answerTwoPointOne.Text;
                    ((App)Application.Current).globalQR.TwoPointTwo = answerTwoPointTwo.Text;
                    if (yesButton.IsChecked == true)
                    {
                        ((App)Application.Current).globalQR.TwoPointThree = true;
                        radiobuttonText.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        radiobuttonText.Visibility = Visibility.Visible;
                        radiobuttonText.Text = "You must implement such a policy before a certificate can be granted:";
                    }

                }
            }
            else
            {
                answerTwoPointOne.PlaceholderText = "This field is required.";
                answerTwoPointTwo.PlaceholderText = "This field is required.";
            }
        }

        private void ShowHint(object sender, PointerRoutedEventArgs e)
        {
            hintPanel.Visibility = Visibility.Visible;
        }

        private void HideHint(object sender, PointerRoutedEventArgs e)
        {
            hintPanel.Visibility = Visibility.Collapsed;
        }
    }
}
