using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public static class _0xfaef8027
{
    public static class _0xc501cde9
    {
        public static readonly int SCENE_0 = 0;
        public static readonly int SCENE_1 = 1;
    }

    public static class _0x250cf309
    {
        public static readonly int PAUSE = 6;
        public static readonly int WIN = 7;
        public static readonly int LOSE = 8;
    }

    public static class _0xec2ae8dc
    {
        public static readonly int SPLASH = 0;
        public static readonly int DEFAULT = 1;
        public static readonly int EMPTY = 2;
        public static readonly int TUTORIAL0 = 13;
        public static readonly int TUTORIAL1 = 14;
        public static readonly int TUTORIAL2 = 15;
        public static readonly int TUTORIAL3 = 16;
        public static readonly int TUTORIAL4 = 17;
        public static readonly int TUTORIAL5 = 18;
        public static readonly int TUTORIAL6 = 19;
    }

    public static class _0x6b1ba0f2
    {
        public static int _0x53608a6a
        {
            get
            {
                if (!PlayerPrefs.HasKey(_0xfabd40ca._0x41479d09(new byte[5] { 123, 87, 81, 86, 75 }, 56)))
                    PlayerPrefs.SetInt(_0xfabd40ca._0x41479d09(new byte[5] { 119, 91, 93, 90, 71 }, 52), 0);
                return PlayerPrefs.GetInt(_0xfabd40ca._0x41479d09(new byte[5] { 160, 140, 138, 141, 144 }, 227));
            }

            set
            {
                PlayerPrefs.SetInt(_0xfabd40ca._0x41479d09(new byte[5] { 202, 230, 224, 231, 250 }, 137), value);
                _0xeb787fb1.Instance._0x2bac048d();
            }
        }
    }

    public class _0xdedf6d46
    {
        private static readonly _0xdedf6d46 _0x3ed40f19 = new();
        public static readonly _0xdedf6d46[] ALL_SCENES_SETTING_SINGLETONS =
        {
            _0x3ed40f19,
            _0x3ed40f19,
            _0x3ed40f19,
        };
        private int _0x82aa5cf8 => 0;
        private int _0x881c0fa8 => 10;
        private string _0xb4c982c5 => _0xfabd40ca._0x41479d09(new byte[4] { 152, 176, 187, 160 }, 213);
        private string _0xd02d1b3e => _0xfabd40ca._0x41479d09(new byte[8] { 139, 130, 145, 130, 139, 188, 247, 186 }, 199);

        private int _0xc64c5205
        {
            get
            {
                if (!PlayerPrefs.HasKey(_0xfabd40ca._0x41479d09(new byte[25] { 111, 89, 94, 94, 73, 66, 88, 107, 64, 67, 78, 77, 64, 111, 68, 77, 92, 88, 73, 94, 101, 66, 72, 73, 84 }, 44)))
                    PlayerPrefs.SetInt(_0xfabd40ca._0x41479d09(new byte[25] { 27, 45, 42, 42, 61, 54, 44, 31, 52, 55, 58, 57, 52, 27, 48, 57, 40, 44, 61, 42, 17, 54, 60, 61, 32 }, 88), 0);
                return PlayerPrefs.GetInt(_0xfabd40ca._0x41479d09(new byte[25] { 189, 139, 140, 140, 155, 144, 138, 185, 146, 145, 156, 159, 146, 189, 150, 159, 142, 138, 155, 140, 183, 144, 154, 155, 134 }, 254));
            }

            set => PlayerPrefs.SetInt(_0xfabd40ca._0x41479d09(new byte[25] { 81, 103, 96, 96, 119, 124, 102, 85, 126, 125, 112, 115, 126, 81, 122, 115, 98, 102, 119, 96, 91, 124, 118, 119, 106 }, 18), value);
        }

        public int _0x8238ecef
        {
            get
            {
                if (!PlayerPrefs.HasKey($"{this._0xb4c982c5}CurrentLevelIndex"))
                    PlayerPrefs.SetInt($"{this._0xb4c982c5}CurrentLevelIndex", 0);
                return PlayerPrefs.GetInt($"{this._0xb4c982c5}CurrentLevelIndex");
            }

            set => PlayerPrefs.SetInt($"{this._0xb4c982c5}CurrentLevelIndex", value);
        }

        public int _0x37de77c0
        {
            get
            {
                if (!PlayerPrefs.HasKey($"{this._0xb4c982c5}BestScore"))
                    this._0x37de77c0 = 0;
                return PlayerPrefs.GetInt($"{this._0xb4c982c5}BestScore");
            }

            set => PlayerPrefs.SetInt($"{this._0xb4c982c5}BestScore", value);
        }

        public bool _0x0f5f3b07
        {
            get
            {
                if (!PlayerPrefs.HasKey($"{this._0xb4c982c5}IsGameTutorPassed"))
                    PlayerPrefs.SetInt($"{this._0xb4c982c5}IsGameTutorPassed", Convert.ToInt32(false));
                return PlayerPrefs.GetInt($"{this._0xb4c982c5}IsGameTutorPassed") == 1;
            }

            set => PlayerPrefs.SetInt($"{this._0xb4c982c5}IsGameTutorPassed", Convert.ToInt32(value));
        }
    }
}

internal static class _0xfabd40ca
{
    internal static string _0x41479d09(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}