using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ServisVozila
{
    public class Helper
    {
        public static void AllowOnlyIntegers(object sender, KeyEventArgs e)
        {
            // Allow control keys
            if (e.Key == Key.Back || e.Key == Key.Delete || e.Key == Key.Tab ||
                e.Key == Key.Left || e.Key == Key.Right)
            {
                return;
            }

            // Allow digits from top row and numpad
            if ((e.Key < Key.D0 || e.Key > Key.D9) &&
                (e.Key < Key.NumPad0 || e.Key > Key.NumPad9))
            {
                e.Handled = true; // Block other keys
            }
        }

    }
}
