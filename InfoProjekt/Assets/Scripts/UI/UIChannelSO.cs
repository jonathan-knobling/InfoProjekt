using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    [CreateAssetMenu(menuName = "Channels/UI Channel")]
    public class UIChannelSO: ScriptableObject
    {
        public event Action<VisualElement> OnRequestAddUIVisualElement;
        public event Action<VisualElement> OnRequestRemoveUIVisualElement;

        public void RequestAddUIVisualElement(VisualElement element)
        {
            OnRequestAddUIVisualElement?.Invoke(element);
        }

        public void RequestRemoveUIVisualElement(VisualElement element)
        {
            OnRequestRemoveUIVisualElement?.Invoke(element);
        }
    }
}