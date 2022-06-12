using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

using ShooterGame.Languages;
using ShooterGame.Settings;
using ShooterGame.Utils;
using ShooterGame.Screens;

using Raylib_cs;

namespace ShooterGame
{
    public class Main
    {
        public static Main _singlton;
        public RenderTexture2D _renderTexture;
        public LanguageManager _languageManager;
        public ScreenManager _screenManager;
        public readonly Vector2 renderSize = new Vector2()
        {
            X = 1280,
            Y = 720
        };

        public float _renderScale = 0f;

        public Main()
        {
            if (_singlton == null)
                _singlton = this;
            else
                throw new Exception("Something went painfully wrong we have 2 games");

            Setup();

            Init();

            while(!Raylib.WindowShouldClose())
            {
                Update();

                Draw();
            }

            Deinit();
        }

        private void Setup()
        {
            SettingsManager.Init();
            _languageManager = new LanguageManager(SettingsManager._holder.languageID);

            Raylib.SetConfigFlags(ConfigFlags.FLAG_WINDOW_RESIZABLE | ConfigFlags.FLAG_VSYNC_HINT);
            Raylib.InitWindow(SettingsManager._holder.screenWidth, SettingsManager._holder.screenHeight, _languageManager.words[(int)Pharse.title]);
            Raylib.SetWindowMinSize(640, 480);
            Raylib.SetTargetFPS(60);
        }

        private void Init()
        {
            StaticLoad.InitAndLoad();
            Mouse.Init();
            _renderTexture = Raylib.LoadRenderTexture((int)renderSize.X, (int)renderSize.Y);
            Raylib.SetTextureFilter(_renderTexture.texture, TextureFilter.TEXTURE_FILTER_POINT);
            _screenManager = new ScreenManager();
        }

        private void Update()
        {
            SettingsManager._holder.screenWidth = Raylib.GetScreenWidth();
            SettingsManager._holder.screenHeight = Raylib.GetScreenHeight();

            _renderScale = MathF.Min((float)SettingsManager._holder.screenWidth / renderSize.X, (float)SettingsManager._holder.screenHeight / renderSize.Y);
            Mouse.Update(new Vector2() { X = SettingsManager._holder.screenWidth, Y = SettingsManager._holder.screenHeight }, renderSize, _renderScale);

            _screenManager.Update();
        }

        private void Draw()
        {
            _screenManager.Draw();

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLACK);
            Raylib.DrawTexturePro(_renderTexture.texture
                , new Rectangle(0, 0, _renderTexture.texture.width, -_renderTexture.texture.height)
                , new Rectangle(((float)SettingsManager._holder.screenWidth - (renderSize.X * _renderScale)) * 0.5f, ((float)SettingsManager._holder.screenHeight - (renderSize.Y * _renderScale)) * 0.5f, renderSize.X * _renderScale, renderSize.Y * _renderScale)
                , Vector2.Zero
                , 0f
                , Color.WHITE
                );
            Raylib.EndDrawing();
        }

        private void Deinit()
        {
            _singlton = null;
            StaticLoad.Deinit();
            Raylib.UnloadRenderTexture(_renderTexture);
            SettingsManager.deInit();
            Raylib.CloseWindow();
        }
    }
}
