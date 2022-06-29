using System;

namespace Util
{
    [Serializable]
    public struct Optional <T>
    {
        public bool enabled;
        public T value;
    }
}