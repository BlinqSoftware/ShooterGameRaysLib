using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterGame.Utils
{
    public struct AlarmHolder
    {
        public Action<float> FuncToCall;
        public float Time;
    }

    public class Alarms
    {
        public Dictionary<int, AlarmHolder> alarms = new Dictionary<int, AlarmHolder>();
        public int _Frames;
        public float _FramesTime;
        public Alarms(int framesPerSecond = 30)
        {
            _Frames = framesPerSecond;
            _FramesTime = 1f / (float)framesPerSecond;
        }
        public void SetAlarm(int id, int frames, Action<float> call)
        {
            if (alarms.ContainsKey(id))
            {
                alarms[id] = new AlarmHolder()
                {
                    FuncToCall = call,
                    Time = frames * _FramesTime
                };
            }
            else
            {
                alarms.Add(id, new AlarmHolder()
                {
                    FuncToCall = call,
                    Time = frames * _FramesTime
                });
            }
        }

        public void Update()
        {
            for (int i = 0; i < alarms.Count; i++)
            {
                var a = alarms.ElementAt(i).Value;
                a.Time -= Raylib_cs.Raylib.GetFrameTime();
                if (a.Time <= 0)
                {
                    alarms.Remove(alarms.ElementAt(i).Key);
                    a.FuncToCall.Invoke(Raylib_cs.Raylib.GetFrameTime());
                }
                else
                {
                    alarms[alarms.ElementAt(i).Key] = a;
                }
            }
        }
    }
}
