using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Union_of_Volunteers.Models
{
    public class BackgroundColor
    {
        private static readonly string _greenBackgroundColor = "#4D9E93";   
        private static readonly string _redBackgroundColor = "#F45952";

        public static bool greenColor = true;

        public static string GetColor 
        {
            get
            {
                if (greenColor)
                {
                    greenColor = false;
                    return _greenBackgroundColor;
                }
                else
                {
                    greenColor = true;
                    return _redBackgroundColor;
                }
                
            }
        }
    }
}
