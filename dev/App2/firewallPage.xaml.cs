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
    public sealed partial class firewallPage : Page
    {
        public firewallPage()
        {
            this.InitializeComponent();
            if (((App)Application.Current).globalQR.ThreePointTwo)
            {
                answerThreePointOne.Text = ((App)Application.Current).globalQR.ThreePointOne;
                answerThreePointFour.Text = ((App)Application.Current).globalQR.ThreePointFour;
                answerThreePointTwo.IsChecked = true;
                answerThreePointThree.IsChecked = true;
                answerThreePointFive.IsChecked = true;
                answerThreePointSix.IsChecked = true;
                answerThreePointSeven.IsChecked = true;
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if(answerThreePointOne.Text == "")
            {
                answerThreePointOne.PlaceholderText = "This field is required";
            } else if(answerThreePointFour.Text == "")
            {
                answerThreePointFour.PlaceholderText = "This field is required";
            } else if(answerThreePointTwo.IsChecked != true)
            {
                answerThreePointTwo.Content = "This is required to be implmented";
            } else if(answerThreePointThree.IsChecked != true)
            {
                answerThreePointThree.Content = "This is required to be implmented";
            }
            else if (answerThreePointFive.IsChecked != true)
            {
                answerThreePointFive.Content = "This is required to be implmented";
            }
            else if (answerThreePointSix.IsChecked != true)
            {
                answerThreePointSix.Content = "This is required to be implmented";
            }
            else if (answerThreePointSeven.IsChecked != true)
            {
                answerThreePointSeven.Content = "This is required to be implmented";
            }
            else
            {
                ((App)Application.Current).globalQR.ThreePointOne = answerThreePointOne.Text;
                ((App)Application.Current).globalQR.ThreePointFour = answerThreePointFour.Text;
                ((App)Application.Current).globalQR.ThreePointTwo = checkBoxToBool.Convert(answerThreePointTwo);
                ((App)Application.Current).globalQR.ThreePointThree = checkBoxToBool.Convert(answerThreePointThree);
                ((App)Application.Current).globalQR.ThreePointFive = checkBoxToBool.Convert(answerThreePointFive);
                ((App)Application.Current).globalQR.ThreePointSix = checkBoxToBool.Convert(answerThreePointSix);
                ((App)Application.Current).globalQR.ThreePointSeven = checkBoxToBool.Convert(answerThreePointSeven);
                
            }
        }
    }
}
