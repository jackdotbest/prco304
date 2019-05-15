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
    public sealed partial class secureConfigPage : Page
    {
        public secureConfigPage()
        {
            this.InitializeComponent();
            if (((App)Application.Current).globalQR.FourPointOne)
            {
                answerFourPointOne.IsChecked = true;
                answerFourPointTwo.IsChecked = true;
                answerFourPointThree.IsChecked = true;
                answerFourPointFour.IsChecked = true;
                answerFourPointFive.Text = ((App)Application.Current).globalQR.FourPointFive;
                answerFourPointSix.Text = ((App)Application.Current).globalQR.FourPointSix;
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string eb = "This must be implemented, please first do so, then continue.", ec = "This field is required.";

            if (!checkBoxToBool.Convert(answerFourPointOne))
            {
                answerFourPointOne.Content = eb;
            }
            else if (!checkBoxToBool.Convert(answerFourPointTwo))
            {
                answerFourPointTwo.Content = eb;
            }
            else if (!checkBoxToBool.Convert(answerFourPointThree))
            {
                answerFourPointThree.Content = eb;
            }
            else if (!checkBoxToBool.Convert(answerFourPointFour))
            {
                answerFourPointFour.Content = eb;
            }
            else if (answerFourPointFive.Text == "" || answerFourPointSix.Text == "")
            {
                answerFourPointFive.PlaceholderText = ec;
                answerFourPointSix.PlaceholderText = ec;
            }
            else
            {
                ((App)Application.Current).globalQR.FourPointOne = checkBoxToBool.Convert(answerFourPointOne);
                ((App)Application.Current).globalQR.FourPointTwo = checkBoxToBool.Convert(answerFourPointTwo);
                ((App)Application.Current).globalQR.FourPointThree = checkBoxToBool.Convert(answerFourPointThree);
                ((App)Application.Current).globalQR.FourPointFour = checkBoxToBool.Convert(answerFourPointFour);
                ((App)Application.Current).globalQR.FourPointFive = answerFourPointFive.Text;
                ((App)Application.Current).globalQR.FourPointSix = answerFourPointSix.Text;
            }
        }
    }
}
