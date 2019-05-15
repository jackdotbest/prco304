using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2
{
    public class checkBoxToBool
    {
        public static bool Convert(Windows.UI.Xaml.Controls.CheckBox e)
        {
            Boolean x = false;

            if(e.IsChecked == false || e.IsChecked == null)
            {
                x = false;
            }
            else if(e.IsChecked == true)
            {
                x = true;
            }

            return x;
        }
    }
}
