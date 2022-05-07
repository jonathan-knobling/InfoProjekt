using UnityEngine;
using Util;

namespace Tech.IO.PlayerInput
{
    public struct InputState
    {
        public Optional<bool> CanOperate;
        public Optional<Vector2> InputDirection;
    }
}