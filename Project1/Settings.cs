using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public struct Settings
    {
        Vector2u ScreenResolution;

        public void SetSettingsToSet(string[] args)
        {
            if (args.Length < 2) return;

            switch (args[0])
            {
                case "SCREEE_hEIGHT":
                   // uint.TryParse(args[1],out int newValue) 
                    break;
            }
        }
    }
}
