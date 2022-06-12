using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShooterGame.Utils;
using Raylib_cs;

namespace ShooterGame.GameObjects.MyObjects.SplshScreen
{
    public class Obj_splashScreen : Gameobject
    {
        Texture2D[] baseAnimation = new Texture2D[]
        {
            StaticLoad.imageTextures[(int)ImageIDs.SplashScreen_Eye_0],
            StaticLoad.imageTextures[(int)ImageIDs.SplashScreen_Eye_1],
            StaticLoad.imageTextures[(int)ImageIDs.SplashScreen_Eye_2],
            StaticLoad.imageTextures[(int)ImageIDs.SplashScreen_Eye_3],
            StaticLoad.imageTextures[(int)ImageIDs.SplashScreen_Eye_4],
            StaticLoad.imageTextures[(int)ImageIDs.SplashScreen_Eye_5],
            StaticLoad.imageTextures[(int)ImageIDs.SplashScreen_Eye_6],
            StaticLoad.imageTextures[(int)ImageIDs.SplashScreen_Eye_7],
            StaticLoad.imageTextures[(int)ImageIDs.SplashScreen_Eye_8],
            StaticLoad.imageTextures[(int)ImageIDs.SplashScreen_Eye_9],
            StaticLoad.imageTextures[(int)ImageIDs.SplashScreen_Eye_10]
        };
        int animationCounter = 0;

        Alarms _alarmManager = new Alarms();

        public Obj_splashScreen()
        {
            _alarmManager.SetAlarm(0, 30, animationHandler);
            _position = Main._singlton.renderSize / 2;
        }

        private void animationHandler(float delta)
        {
            if (animationCounter == baseAnimation.Length - 1)
            {
                return;
            }

            animationCounter++;
            _alarmManager.SetAlarm(0, 3, animationHandler);
        }

        public override void Update()
        {
            _alarmManager.Update();

            base.Update();
        }

        public override void Draw()
        {
            var frame = baseAnimation[animationCounter];
            Raylib.DrawTexturePro(frame,
                frame.GetRectangle(),
                frame.GetDrawPos(_position),
                frame.GetCenter(),
                0f,
                Color.WHITE);
        }
    }
}
