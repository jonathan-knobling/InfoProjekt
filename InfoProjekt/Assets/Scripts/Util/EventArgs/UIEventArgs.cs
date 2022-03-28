using UI.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Util.EventArgs
{
    public class UIEventArgs: System.EventArgs
    {
        public VisualElement Element { get; }
        public Transform Parent { get; }
        public readonly UIType Type;

        public UIEventArgs(VisualElement element, Transform parent, UIType type)
        {
            Element = element;
            Parent = parent;
            Type = type;
        }
    }
}