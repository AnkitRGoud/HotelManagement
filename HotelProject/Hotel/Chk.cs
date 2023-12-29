using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hotel
{
    class Chk
    {
        public void checkInt(object sender, KeyPressEventArgs e, TextBox t)
        {
            if (!char.IsNumber(e.KeyChar) && Convert.ToInt32(e.KeyChar) != 8)
            {
                e.Handled = true;
                t.Focus();
            }
        }

        public void checkChar(object sender, KeyPressEventArgs e, TextBox t)
        {
            if (!char.IsLetter(e.KeyChar) && Convert.ToInt32(e.KeyChar) != 8)
            {
                e.Handled = true;
                t.Focus();
            }
        }
    }
}
