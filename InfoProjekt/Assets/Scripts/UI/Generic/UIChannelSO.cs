using System;
using UnityEngine;
using UnityEngine.UIElements;
using Util.EventArgs;

namespace UI.Generic
{
    [CreateAssetMenu(menuName = "Channels/UI Channel")]
    public class UIChannelSO: ScriptableObject
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