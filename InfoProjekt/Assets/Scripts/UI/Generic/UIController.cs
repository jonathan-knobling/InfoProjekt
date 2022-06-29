using System.Collections.Generic;
using Tech;
using UnityEngine;
using UnityEngine.UIElements;
using Util.EventArgs;

namespace UI.Generic
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private EventChannelSO eventChannel;

        private Camera cam;
        
        private VisualElement root;

        private VisualElement screen;
        private VisualElement promptContainer;
        
        private Dictionary<VisualElement, Transform> followUIElements;

        private void Start()
        {
            cam = GameObject.Find("Main Camera").GetComponent<Camera>();

            root = GetComponent<UIDocument>().rootVisualElement;
            screen = root.Q<VisualElement>("screen");
            promptContainer = root.Q<VisualElement>("prompt");
            
            followUIElements = new Dictionary<VisualElement, Transform>();

            eventChannel.UIChannel.OnRequestAddUIVisualElement += AddUIElement;
            eventChannel.UIChannel.OnRequestRemoveUIVisualElement += RemoveUIElement;
        }

        private void Update()
        {
            foreach (var (visualElement, parentTransform) in followUIElements)
            {
                visualElement.transform.position = cam.WorldToScreenPoint(parentTransform.position);
            }
        }

        private void AddUIElement(UIEventArgs args)
        {
            switch (args.Type)
            {
                case UIType.Default:
                {
                    screen.Add(args.Element);
                } break;
                
                case UIType.Prompt:
                {
                    if (promptContainer.childCount > 0)
                    {
                        break;
                    }
                    promptContainer.Add(args.Element);   
                } break;
                
                case UIType.FollowGameObject:
                {
                    followUIElements.TryAdd(args.Element, args.Parent);
                    screen.Add(args.Element);
                } break;
            }
        }

        private void RemoveUIElement(VisualElement element)
        {
            if (promptContainer.Contains(element))
            {
                promptContainer.Remove(element);
            } 
            else if (screen.Contains(element))
            {
                screen.Remove(element);
            }
        }
    }
}
