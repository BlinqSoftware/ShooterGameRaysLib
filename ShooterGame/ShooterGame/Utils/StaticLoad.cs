using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using System.IO;

namespace ShooterGame.Utils
{
    public enum ImageIDs : int
    {
        SplashScreen_Eye_0 = 1,
        SplashScreen_Eye_1,
        SplashScreen_Eye_2,
        SplashScreen_Eye_3,
        SplashScreen_Eye_4,
        SplashScreen_Eye_5,
        SplashScreen_Eye_6,
        SplashScreen_Eye_7,
        SplashScreen_Eye_8,
        SplashScreen_Eye_9,
        SplashScreen_Eye_10,
        Max
    }

    public static class StaticLoad
    {
        public static Texture2D[] imageTextures;
        private static string currentWorkingDir;

        public static void InitAndLoad()
        {
            currentWorkingDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            imageTextures = new Texture2D[(int)ImageIDs.Max];
            imageTextures[(int)ImageIDs.SplashScreen_Eye_0] = Raylib.LoadTexture(Path.Combine(currentWorkingDir,"Content/SplashScreen/Eye/Eye_0.png"));
            imageTextures[(int)ImageIDs.SplashScreen_Eye_1] = Raylib.LoadTexture(Path.Combine(currentWorkingDir, "Content/SplashScreen/Eye/Eye_1.png"));
            imageTextures[(int)ImageIDs.SplashScreen_Eye_2] = Raylib.LoadTexture(Path.Combine(currentWorkingDir, "Content/SplashScreen/Eye/Eye_2.png"));
            imageTextures[(int)ImageIDs.SplashScreen_Eye_3] = Raylib.LoadTexture(Path.Combine(currentWorkingDir, "Content/SplashScreen/Eye/Eye_3.png"));
            imageTextures[(int)ImageIDs.SplashScreen_Eye_4] = Raylib.LoadTexture(Path.Combine(currentWorkingDir, "Content/SplashScreen/Eye/Eye_4.png"));
            imageTextures[(int)ImageIDs.SplashScreen_Eye_5] = Raylib.LoadTexture(Path.Combine(currentWorkingDir, "Content/SplashScreen/Eye/Eye_5.png"));
            imageTextures[(int)ImageIDs.SplashScreen_Eye_6] = Raylib.LoadTexture(Path.Combine(currentWorkingDir, "Content/SplashScreen/Eye/Eye_6.png"));
            imageTextures[(int)ImageIDs.SplashScreen_Eye_7] = Raylib.LoadTexture(Path.Combine(currentWorkingDir, "Content/SplashScreen/Eye/Eye_7.png"));
            imageTextures[(int)ImageIDs.SplashScreen_Eye_8] = Raylib.LoadTexture(Path.Combine(currentWorkingDir, "Content/SplashScreen/Eye/Eye_8.png"));
            imageTextures[(int)ImageIDs.SplashScreen_Eye_9] = Raylib.LoadTexture(Path.Combine(currentWorkingDir, "Content/SplashScreen/Eye/Eye_9.png"));
            imageTextures[(int)ImageIDs.SplashScreen_Eye_10] = Raylib.LoadTexture(Path.Combine(currentWorkingDir, "Content/SplashScreen/Eye/Eye_10.png"));
        }

        public static void Deinit()
        {
            for(int i = 0; i < imageTextures.Length; i++)
            {
                Raylib.UnloadTexture(imageTextures[i]);
            }
            imageTextures = null;
        }
    }
}
