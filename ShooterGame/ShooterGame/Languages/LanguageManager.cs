using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterGame.Languages
{
    public enum Languages : ushort
    {
        English = 1,
    }

    public enum Pharse : int
    {
        title = 1,
        max,
    }

    public class LanguageManager
    {
        public static LanguageManager _singleton;

        public string[] words;
        
        public LanguageManager(ushort languageToLoad)
        {
            _singleton = this;

            words = new string[(int)Pharse.max];

            switch(languageToLoad)
            {
                default:
                case (ushort)Languages.English:
                    LoadEnglish();
                    break;
            }
        }

        private void LoadEnglish()
        {
            words = new string[(int)Pharse.max];

            words[(int)Pharse.title] = "Shooter Game Early Alpha";
        }
    }
}
