﻿using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;

namespace FutureNNAimbot
{
    [DataContract]
    public class Settings
    {
        [DataMember]
        public int SizeX { get; set; }
        [DataMember]
        public int SizeY { get; set; }
        [DataMember]
        public string Game { get; set; }
        [DataMember]
        public bool SimpleRCS { get; set; }
        [DataMember]
        public Keys ShootKey { get; set; }
        [DataMember]
        public Keys TrainModeKey { get; set; }
        [DataMember]
        public Keys ScreenshotKey { get; set; }
        [DataMember]
        public Keys ScreenshotModeKey { get; set; }
        [DataMember]
        public float SmoothAim { get; set; }
        [DataMember]
        public bool Information { get; set; }
        [DataMember]
        public bool Head { get; set; }
        [DataMember]
        public bool DrawAreaRectangle { get; set; }
        [DataMember]
        public bool DrawText { get; set; }


        static public Settings ReadSettings()
        {
            // Read settings
            DataContractJsonSerializer Settings = new DataContractJsonSerializer(typeof(Settings[]));
            Settings[] settings = null;
            Settings auto_config = new Settings()
            {
                SizeX = 320,
                SizeY = 320,
                Game = "game",
                SimpleRCS = true,
                ShootKey = Keys.MButton,
                TrainModeKey = Keys.Insert,
                ScreenshotKey = Keys.Home,
                ScreenshotModeKey = Keys.NumPad9,
                SmoothAim = 0.1f,
                Information = true,
                Head = false
            };
            using (var fs = new System.IO.FileStream("config.json", System.IO.FileMode.OpenOrCreate))
            {
                if (fs.Length == 0)
                {
                    Settings.WriteObject(fs, new Settings[1] { auto_config });
                    MessageBox.Show($"Created auto-config, change whatever settings you want and restart.");
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                    return null;
                }
                else settings = (Settings[])Settings.ReadObject(fs);
                return settings?[0];
            }
        }
    }
}
