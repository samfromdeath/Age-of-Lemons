using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgeOfLemons
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            using(AOLTest aa = new AOLTest())
            {
                Application.Run(aa);
            }
        }
    }
}
