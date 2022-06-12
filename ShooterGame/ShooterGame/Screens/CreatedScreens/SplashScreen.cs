using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using ShooterGame.Utils;
using ShooterGame.GameObjects.MyObjects.SplshScreen;

namespace ShooterGame.Screens.CreatedScreens
{
    public class SplashScreen : Screen
    {
        public override void Create()
        {
            base.Create();
            var _splash = new Obj_splashScreen();
            _gameobjectManager.AddObject(_splash);
        }
        public override void Deinit()
        {
            base.Deinit();
        }
        public override void Update()
        {
            _gameobjectManager.Update();
        }
        public override void Draw()
        {
            Raylib.BeginTextureMode(Main._singlton._renderTexture);
            Raylib.ClearBackground(Color.WHITE);
            _gameobjectManager.Draw();

            _gameobjectManager.DrawGUI();
            Raylib.EndTextureMode();
        }
    }
}
