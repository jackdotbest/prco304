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
    public sealed partial class userAccessControlPage : Page
    {
        public userAccessControlPage()
        {
            this.InitializeComponent();
            if(((App)Application.Current).globalQR.FivePointOne)
            {
                answerFivePointOne.IsChecked = true;
                answerFivePointTwo.IsChecked = true;
                answerFivePointThree.IsChecked = true;
                answerFivePointFour.IsChecked = true;
                answerFivePointSix.IsChecked = true;
                answerFivePointSeven.IsChecked = true;
                answerFivePointFive.Text = ((App)Application.Current).globalQR.FivePointFive;
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string eb = "This is a requirement, please implement, then continue.", ec = "This field is required";

            if (!checkBoxToBool.Convert(answerFivePointOne))
            {
                answerFivePointOne.Content = eb;
            }
            else if (!checkBoxToBool.Convert(answerFivePointTwo))
            {
                answerFivePointTwo.Content = eb;
            }
            if (!checkBoxToBool.Convert(answerFivePointThree))
            {
                answerFivePointThree.Content = eb;
            }
            if (!checkBoxToBool.Convert(answerFivePointFour))
            {
                answerFivePointFour.Content = eb;
            }
            if (!checkBoxToBool.Convert(answerFivePointSix))
            {
                answerFivePointSix.Content = eb;
            }
            if (!checkBoxToBool.Convert(answerFivePointSeven))
            {
                answerFivePointSeven.Content = eb;
            }
            if(answerFivePointFive.Text == "")
            {
                answerFivePointFive.PlaceholderText = ec;
            }
            else
            {
                ((App)Application.Current).globalQR.FivePointOne = checkBoxToBool.Convert(answerFivePointOne);
                ((App)Application.Current).globalQR.FivePointTwo = checkBoxToBool.Convert(answerFivePointTwo);
                ((App)Application.Current).globalQR.FivePointThree = checkBoxToBool.Convert(answerFivePointThree);
                ((App)Application.Current).globalQR.FivePointFour = checkBoxToBool.Convert(answerFivePointFour);
                ((App)Application.Current).globalQR.FivePointFive = answerFivePointFive.Text;
                ((App)Application.Current).globalQR.FivePointSix = checkBoxToBool.Convert(answerFivePointSix);
                ((App)Application.Current).globalQR.FivepointSeven = checkBoxToBool.Convert(answerFivePointSeven);
            }
        }
    }
}
