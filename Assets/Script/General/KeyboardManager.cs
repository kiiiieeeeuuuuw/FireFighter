using UnityEngine;

namespace Assets.Script.General
{
    public static class KeyboardManager
    {
        private enum KeyboardLayout
        {
            Azerty = 0,
            Qwerty = 1
        }

        public enum Key
        {
            Left,
            Right, 
            Up,
            Down,
            Attack
        }

        public static KeyCode[] LeftCode   = new KeyCode[2] { KeyCode.Q, KeyCode.A };
        public static KeyCode[] RightCode  = new KeyCode[2] { KeyCode.D, KeyCode.D };
        public static KeyCode[] UpCode     = new KeyCode[2] { KeyCode.Z, KeyCode.W };
        public static KeyCode[] DownCode   = new KeyCode[2] { KeyCode.S, KeyCode.S };
        public static KeyCode[] AttackCode = new KeyCode[2] { KeyCode.J, KeyCode.J };

        public static KeyCode GetKey(Key k)
        {
            int i = PlayerPrefs.GetString(Constants.KeyboardLayout) == Constants.Azerty ? (int)KeyboardLayout.Azerty : (int)KeyboardLayout.Qwerty;
            switch (k)
            {
                case Key.Left:
                    return LeftCode[i];
                case Key.Right:
                    return RightCode[i];
                case Key.Up:
                    return UpCode[i];
                case Key.Down:
                    return DownCode[i];
                case Key.Attack:
                    return AttackCode[i];
                default:
                    throw new System.Exception("No playerpref detected");
            }            
        }
    }
}
