using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ShooterGame.GameObjects
{
    public class Gameobject
    {
        public GameObjectManager _objManager;
        public bool isEnabled;
        public Vector2 _position;
        public Guid _guid;

        public virtual void OnEnable()
        {
            isEnabled = true;
        }

        public virtual void OnDisable()
        {
            isEnabled = false;
        }

        public virtual void Update()
        {
        }

        public virtual void Draw()
        {
        }

        public virtual void DrawGUI()
        {
        }
    }
}
