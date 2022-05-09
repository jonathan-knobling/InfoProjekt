using System;
using UnityEngine;
using Util;

namespace Tech.IO.PlayerInput
{
    public struct InputState: ICloneable
    {
        public Optional<bool> CanOperate;
        public Optional<bool> DontCapVelocity;
        public Optional<Vector2> InputDirection;
        public Optional<float> LinearDrag;
     
        public InputState(Vector2 inputDirection)
        {
            CanOperate = new Optional<bool>()
            {
                enabled = false
            };
            DontCapVelocity = new Optional<bool>()
            {
                enabled = false
            };
            InputDirection = new Optional<Vector2>()
            {
                enabled = true,
                value = inputDirection
            };
            LinearDrag = new Optional<float>()
            {
                enabled = false
            };
        }

        public InputState(Vector2 inputDirection, bool canOperate)
        {
            CanOperate = new Optional<bool>()
            {
                enabled = true,
                value = canOperate
            };
            DontCapVelocity = new Optional<bool>()
            {
                enabled = false
            };
            InputDirection = new Optional<Vector2>()
            {
                enabled = true,
                value = inputDirection
            };
            LinearDrag = new Optional<float>()
            {
                enabled = false
            };
        }

        public InputState(bool canOperate)
        {
            CanOperate = new Optional<bool>()
            {
                enabled = true,
                value = canOperate
            };
            DontCapVelocity = new Optional<bool>()
            {
                enabled = false
            };
            InputDirection = new Optional<Vector2>()
            {
                enabled = false
            };
            LinearDrag = new Optional<float>()
            {
                enabled = false
            };
        }
        
        public InputState(Vector2 inputDirection, bool canOperate, bool dontCapVelocity)
        {
            CanOperate = new Optional<bool>()
            {
                enabled = true,
                value = canOperate
            };
            DontCapVelocity = new Optional<bool>()
            {
                enabled = true,
                value = dontCapVelocity
            };
            InputDirection = new Optional<Vector2>()
            {
                enabled = true,
                value = inputDirection
            };
            LinearDrag = new Optional<float>()
            {
                enabled = false
            };
        }
        
        public InputState(Vector2 inputDirection, bool canOperate, bool dontCapVelocity, float linearDrag)
        {
            CanOperate = new Optional<bool>()
            {
                enabled = true,
                value = canOperate
            };
            DontCapVelocity = new Optional<bool>()
            {
                enabled = true,
                value = dontCapVelocity
            };
            InputDirection = new Optional<Vector2>()
            {
                enabled = true,
                value = inputDirection
            };
            LinearDrag = new Optional<float>()
            {
                enabled = true,
                value = linearDrag
            };
        }

        public object Clone()
        {
            InputState inputState = new InputState()
            {
                CanOperate = new Optional<bool> {enabled = false},
                DontCapVelocity = new Optional<bool> {enabled = false},
                InputDirection = new Optional<Vector2> {enabled = false},
                LinearDrag = new Optional<float> { enabled = false }
            };

            if (CanOperate.enabled) inputState.CanOperate = CanOperate;
            if (DontCapVelocity.enabled) inputState.DontCapVelocity = DontCapVelocity;
            if (InputDirection.enabled) inputState.InputDirection = InputDirection;
            if (LinearDrag.enabled) inputState.LinearDrag = LinearDrag;

            return inputState;
        }
    }
}