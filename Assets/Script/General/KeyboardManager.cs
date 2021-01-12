using UnityEngine;

namespace Assets.Script.General
{
    public class KeyboardManager
    {
        private enum Layout
        {
            Azerty = 0,
            Qwerty = 1
        }

        public KeyCode[] LeftCode   = new KeyCode[2] { KeyCode.Q, KeyCode.A };
        public KeyCode[] RightCode  = new KeyCode[2] { KeyCode.D, KeyCode.D };
        public KeyCode[] UpCode     = new KeyCode[2] { KeyCode.Z, KeyCode.W };
        public KeyCode[] DownCode   = new KeyCode[2] { KeyCode.S, KeyCode.S };
        public KeyCode[] AttackCode = new KeyCode[2] { KeyCode.J, KeyCode.J };
    }
}
