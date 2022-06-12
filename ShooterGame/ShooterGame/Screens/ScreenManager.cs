using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ShooterGame.Screens.CreatedScreens;
using Raylib_cs;

namespace ShooterGame.Screens
{
    public enum ScreenIDs : int
    {
        SplashScreen = 0,
    }
    public class ScreenManager
    {
        public static ScreenManager _singleton;
        public static Dictionary<int, Type> screenRegistry = new Dictionary<int, Type>()
        {
            {(int)ScreenIDs.SplashScreen,typeof(SplashScreen) },
        };

        public Screen CurrentScreen = null;
        private int ScreenDelayID = -1;
        public ScreenManager()
        {
            if (_singleton == null)
                _singleton = this;
            else
                throw new Exception("Why have 2 managers do the same job, screenManager issue");

            LoadScreen((int)ScreenIDs.SplashScreen);
        }

        public void LoadScreen(int id)
        {
            Screen newScreen = (Screen)Activator.CreateInstance(screenRegistry[id]);
            newScreen.Create();
            CurrentScreen?.Deinit();
            CurrentScreen = newScreen;
        }

        public void LoadScreenDelayed(int id)
        {
            ScreenDelayID = id;
        }

        public void Update()
        {
            CurrentScreen?.Update();

            if (ScreenDelayID != -1)
            {
                LoadScreen(ScreenDelayID);
                ScreenDelayID = -1;
            }
        }

        public void Draw()
        {
            CurrentScreen.Draw();
        }
    }
}
