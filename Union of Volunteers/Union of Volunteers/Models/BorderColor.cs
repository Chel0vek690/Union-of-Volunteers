namespace Union_of_Volunteers.Models
{
    public class BorderColor
    {
        private static readonly string _greenBorderColor = "#165C53";

        private static readonly string _redBorderColor = "#64110E";

        public static bool greenColor = true;

        public static string GetColor
        {
            get
            {
                if (greenColor)
                {
                    greenColor = false;
                    return _greenBorderColor;
                }
                else
                {
                    greenColor = true;
                    return _redBorderColor;
                }

            }
        }
    }
}
