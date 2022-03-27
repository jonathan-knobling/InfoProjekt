using System;
using System.Collections.Generic;
using Gameplay.Dialogue.Nodes;
using Tech.Flow;
using UnityEngine;
using UnityEngine.UIElements;
using Util.EventArgs;

namespace Gameplay.Dialogue.UI
{
    public class DialogueUIController : MonoBehaviour, IDialogueNodeVisitor
    {
        [SerializeField] private DialogueChannelSO dialogueChannel;
        [SerializeField] private FlowChannelSO flowChannel;

        private List<DialogueNodeButton> choiceNodeUIs;

        private VisualElement root;
        private VisualElement buttonContainer;
        private VisualElement screen;
        private Label text;

        private DialogueSequencer sequencer;

        private void Start()
        {
            root = GetComponent<UIDocument>().rootVisualElement;

            screen = root.Q<VisualElement>("screen");
            buttonContainer = root.Q<VisualElement>("buttons");
            
            text = root.Q<Label>("text");

            choiceNodeUIs = new List<DialogueNodeButton>(3);

            sequencer = new DialogueSequencer(flowChannel);
            dialogueChannel.OnRequestDialogue += OnDialogueRequested;
            sequencer.OnStartDialogue += OnStartDialogue;
            sequencer.OnEndDialogue += OnEndDialogue;
            sequencer.OnStartDialogueNode += OnStartDialogueNode;
        }

        public void Visit(DialogueLinearNode node)
        {
            //wenn es ein dialog event gibt dieses ausführen
            if (node.dialogueEvent != null) node.dialogueEvent.Invoke();
            
            choiceNodeUIs.Clear();
            buttonContainer.Clear();
            
            //nodebutton erstellen und die onbuttonclicked funktion dem button hinzufügen
            choiceNodeUIs.Add(new DialogueNodeButton(sequencer, node.nextNode));
            Button button = new Button();
            button.clicked += choiceNodeUIs[0].OnButtonClicked;
            button.text = node.choiceNodeButtonText;
            buttonContainer.Add(button);

            //text und speaker auf das label anwenden
            text.text = node.line.speaker.characterName + ": " + node.line.line;
        }

        public void Visit(DialogeChoiceNode node)
        {
            //wenn es ein dialog event gibt dieses ausführen
            if (node.dialogueEvent != null) node.dialogueEvent.Invoke();
            
            //fehlermeldung wenn zu viele choices gibt
            if (node.choices.Count > 3) throw new Exception("too many choice nodes (max 3)");
            
            choiceNodeUIs.Clear();
            buttonContainer.Clear();
            
            //für jede option die man anklicken kann (max 3)
            for (var i = 0; i < node.choices.Count; i++)
            {
                Debug.Log("Add Button");
                choiceNodeUIs.Add(new DialogueNodeButton(sequencer, node.choices[i]));
                Button button = new Button();
                button.clicked += choiceNodeUIs[i].OnButtonClicked;
                button.text = node.choices[i].choiceNodeButtonText;
                buttonContainer.Add(button);
            }

            //text und speaker auf das label anwenden
            text.text = node.line.speaker.characterName + ": " + node.line.line;
        }

        private void OnDialogueRequested(object o, DialogueEventArgs e)
        {
            sequencer.StartDialogue(e.Dialogue);
        }

        private void OnStartDialogue(Util.Dialogue dialogue)
        {
            screen.style.display = DisplayStyle.Flex;
        }

        private void OnEndDialogue(Util.Dialogue dialogue)
        {
            screen.style.display = DisplayStyle.None;
        }

        private void OnStartDialogueNode(DialogueNode dialogueNode)
        {
            Debug.Log("Visit Node");
            dialogueNode.Visit(this);
        }
    }
}