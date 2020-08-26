using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Windows.Utils { 
    class MyDialog
{

        public static void info(string message)
        {
            MessageBox.Show(message);
        }

    public static Boolean confirm(String message)
    {
        var confirmResult = MessageBox.Show(message, "Confirmation",
                                    MessageBoxButtons.YesNo);
        if (confirmResult == DialogResult.Yes)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
}
