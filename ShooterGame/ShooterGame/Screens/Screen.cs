using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShooterGame.GameObjects;

namespace ShooterGame.Screens
{
    public class Screen
    {
        public GameObjectManager _gameobjectManager;

        public virtual void Create()
        {
            _gameobjectManager = new GameObjectManager();
        }

        public virtual void Deinit()
        {
            _gameobjectManager.Deinit();
        }

        public virtual void Update()
        {
        }

        public virtual void Draw()
        {
        }
    }
}
