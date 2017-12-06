using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.UI.IO
{
    public static class UI
    {
        public static string BorderTop
        {
            get { return "***********************************"; }
        }

        public static string BorderBottom
        {
            get { return BorderTop + "\n"; }
        }

        public static string HR
        {
            get { return BorderTop; }
        }

        public static string RowPrefix
        {
            get { return "* "; }
        }
    }
}
