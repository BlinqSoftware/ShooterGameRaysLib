using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterGame.GameObjects
{
    public class GameObjectManager
    {
        public Dictionary<Guid, Gameobject> _gameObjects;
        public List<Guid> _objectUpdate;
        public List<Guid> _objectDraw;
        public List<Guid> _objectGui;

        public GameObjectManager()
        {
            _gameObjects = new Dictionary<Guid, Gameobject>();
            _objectUpdate = new List<Guid>();
            _objectDraw = new List<Guid>();
            _objectGui = new List<Guid>();
        }

        ~GameObjectManager()
        {
            _gameObjects.Clear();
            _objectUpdate.Clear();
            _objectDraw.Clear();
            _objectGui.Clear();
        }

        public Guid AddObject(Gameobject go, bool update = true, bool draw = true, bool gui = true)
        {
            Guid id = Guid.NewGuid();
            go._guid = id;
            go._objManager = this;
            _gameObjects.Add(id, go);

            if (update)
            {
                _objectUpdate.Add(id);
            }
            if (draw)
            {
                _objectDraw.Add(id);
            }
            if (gui)
            {
                _objectGui.Add(id);
            }

            return id;
        }

        public Gameobject removeObject(Guid guid)
        {
            if (_gameObjects.ContainsKey(guid))
            {
                Gameobject obj = _gameObjects[guid];
                _gameObjects.Remove(guid);

                if (_objectUpdate.Contains(guid))
                {
                    _objectUpdate.Remove(guid);
                }
                if (_objectDraw.Contains(guid))
                {
                    _objectDraw.Remove(guid);
                }
                if (_objectGui.Contains(guid))
                {
                    _objectGui.Remove(guid);
                }

                return obj;
            }
            return null;
        }

        public void Update()
        {
            for (int i = 0; i < _objectUpdate.Count; i++)
            {
                _gameObjects[_objectUpdate[i]].Update();
            }
        }

        public void Draw()
        {
            for (int i = 0; i < _objectDraw.Count; i++)
            {
                _gameObjects[_objectDraw[i]].Draw();
            }
        }

        public void DrawGUI()
        {
            for (int i = 0; i < _objectGui.Count; i++)
            {
                _gameObjects[_objectGui[i]].DrawGUI();
            }
        }
    }
}
