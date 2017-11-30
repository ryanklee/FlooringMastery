using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.UI.IO
{
    public class UIElements
    {
        public string BorderBottom { get; set; }
        public string BorderTop { get; set; }
        public string RowPrefix { get; set; }

        public UIElements()
        {
            BorderTop = "***********************************";
            BorderBottom = BorderTop + "\n";
            RowPrefix = "* ";
        }
    }
}
