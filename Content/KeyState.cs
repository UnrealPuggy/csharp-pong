namespace Content
{
    class KeyState
    {
        private Dictionary<Keys, bool> keys = [];
        public bool this[Keys key]
        {
            get => keys.TryGetValue(key, out bool val) && val;
            set => keys[key] = value;
        }
    }
}