using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private UIChannelSO uiChannel;
        private VisualElement root;

        private void Start()
        {
            root = GetComponent<UIDocument>().rootVisualElement;
            
            uiChannel.OnRequestAddUIVisualElement += AddUIElement;
            uiChannel.OnRequestRemoveUIVisualElement += RemoveUIElement;
        }

        private void AddUIElement(VisualElement element)
        {
            root.Add(element);
        }

        private void RemoveUIElement(VisualElement element)
        {
            for (int i = 0; i < root.hierarchy.childCount; i++)
            {
                if (root.hierarchy[i].Equals(element))
                {
                    root.RemoveAt(i);
                }
            }
        }
    }
}
