using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Content
    {
        private const string contentDir = "..\\Content\\Textures\\";
        private const string settingDir = "..\\Content\\Settings\\";
        public static Texture textureHead;
        public static Texture textureBody;
      
        public static void Load()
        {
            textureHead = new Texture(contentDir + "OrangeSquare.png");
            textureBody = new Texture(contentDir + "Body.png");
        }

        public static Settings GetDefaultSettings() => LoadSettings(new FileStream(settingDir + "Default.txt", FileMode.Open));
        public static Settings LoadSettings(FileStream PathTo)
        {
            StreamReader stream = new StreamReader(PathTo);
            Settings SavedSettigs = new Settings();
            while (!stream.EndOfStream)
            {
                var input = stream.ReadLine().Split(' ');
                SavedSettigs.SetSettingsToSet(input);
                /*if (input.Length < 2) continue;

                var fieldInfo = typeof(Settings).GetField(input[0]);
                if (fieldInfo == null) continue;*/
                
                
            }
            return SavedSettigs;
        }
    }


}
