using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using System.Numerics;

namespace ShooterGame.Utils
{
    public static class ExtensionMethods
    {
        public static Rectangle GetRectangle(this Texture2D texture)
        {
            return new Rectangle(0, 0, texture.width, texture.height);
        }

        public static Rectangle GetDrawPos(this Texture2D texture, Vector2 position)
        {
            return new Rectangle(position.X, position.Y, texture.width, texture.height);    
        }

        public static Vector2 GetCenter(this Texture2D texture)
        {
            return new Vector2(texture.width / 2, texture.height / 2); 
        }
    }
}
