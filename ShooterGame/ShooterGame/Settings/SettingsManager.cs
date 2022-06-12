using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AnySerializer;

namespace ShooterGame.Settings
{
    public struct SettingsHolder
    {
        public int screenHeight;
        public int screenWidth;
        public bool isFullscreen;
        public ushort languageID;
    }

    public static class SettingsManager
    {
        public static string settingsPath;
        public static SettingsHolder _holder;

        public static void Init()
        {
            settingsPath = Path.Combine(Environment.CurrentDirectory, "settings.file");
            Load();
        }

        public static void deInit()
        {
            Save();
        }

        public static void Load()
        {
            try
            {
                if (File.Exists(settingsPath))
                {
                    byte[] data = File.ReadAllBytes(settingsPath);
                    _holder = Serializer.Deserialize<SettingsHolder>(data, SerializerOptions.None);
                }
                else
                {
                    buildSettings();
                }
            }
            catch
            {
                Console.WriteLine("Error: Settings file failed to load!");
                buildSettings();
            }
        }

        private static void buildSettings()
        {
            _holder = new SettingsHolder
            {
                screenHeight = 720,
                screenWidth = 1280,
                isFullscreen = false,
                languageID = 0,
            };

            Save();
        }

        public static void Save()
        {
            if (File.Exists(settingsPath))
                File.Delete(settingsPath);

            var data = Serializer.Serialize<SettingsHolder>(_holder);
            File.WriteAllBytes(settingsPath, data);
        }
    }
}
