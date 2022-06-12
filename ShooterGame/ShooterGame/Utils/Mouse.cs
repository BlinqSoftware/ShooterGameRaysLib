using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ShooterGame.Utils
{
    public static class Mouse
    {
        public static Vector2 position;

        public static void Init()
        {
            position = new Vector2();
        }

        public static void Update(Vector2 screenSize, Vector2 renderSize, float scale)
        {
            var mouse = Raylib.GetMousePosition();
            var vm = new Vector2()
            {
                X = (mouse.X - (screenSize.X - (renderSize.X * scale)) * 0.5f) / scale,
                Y = (mouse.Y - (screenSize.Y - (renderSize.Y * scale)) * 0.5f) / scale
            };
            position = ClampValueRounded(vm, Vector2.Zero, renderSize);
        }

        private static Vector2 ClampValueRounded(Vector2 value, Vector2 min, Vector2 max)
        {
            Vector2 result = value;
            result.X = (result.X > max.X) ? max.X : result.X;
            result.X = (result.X < min.X) ? min.X : result.X;
            result.Y = (result.Y > max.Y) ? max.Y : result.Y;
            result.Y = (result.Y < min.Y) ? min.Y : result.Y;
            result.X = MathF.Round(result.X);
            result.Y = MathF.Round(result.Y);
            return result;
        }
    }
}
