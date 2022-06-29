using System;
using UnityEngine.UIElements;
using Util.EventArgs;

namespace UI.Generic
{
    public class UIChannel
    {
        public event Action<UIEventArgs> OnRequestAddUIVisualElement;
        public event Action<VisualElement> OnRequestRemoveUIVisualElement;

        public void RequestAddUIVisualElement(UIEventArgs args)
        {
            OnRequestAddUIVisualElement?.Invoke(args);
        }

        public void RequestRemoveUIVisualElement(VisualElement element)
        {
            OnRequestRemoveUIVisualElement?.Invoke(element);
        }
    }
}