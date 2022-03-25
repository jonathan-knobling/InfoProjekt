using System;
using System.Collections.Generic;
using Flow;
using NPCs.Dialogue.Nodes;
using UnityEngine;
using UnityEngine.UIElements;
using Util.EventArgs;

namespace NPCs.Dialogue.UI
{
    public class DialogueUIController : MonoBehaviour, IDialogueNodeVisitor
    {
        [SerializeField] private DialogueChannelSO dialogueChannel;
        [SerializeField] private FlowChannelSO flowChannel;
        
        private Button[] buttons;

        private List<DialogueChoiceNodeUI> choiceNodeUIs;
        private VisualElement root;

        private VisualElement screen;

        private DialogueSequencer sequencer;
        private Label text;

        private void Start()
        {
            root = GetComponent<UIDocument>().rootVisualElement;

            screen = root.Q<VisualElement>("screen");
            buttons = new Button[3];
            buttons[0] = root.Q<Button>("button1");
            buttons[1] = root.Q<Button>("button2");
            buttons[2] = root.Q<Button>("button3");
            text = root.Q<Label>("text");

            choiceNodeUIs = new List<DialogueChoiceNodeUI>(3);

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

            //alle buttons unsichtbar
            foreach (var button in buttons)
            {
                button.style.display = DisplayStyle.None;
                Debug.Log("dadasdasdasd");
            }

            //einen button zum confirmen wieder sichtbar machen und text setzen
            buttons[0].style.display = DisplayStyle.Flex;
            buttons[0].text = node.nextButtonText;

            //alle choicenodeuis aus der liste entfernen
            choiceNodeUIs.Clear();
            
            //choicenode ui erstellen und die onbuttonclicked funktion dem button hinzufügen und alle anderen gecleared
            choiceNodeUIs.Add(new DialogueChoiceNodeUI(sequencer, node));
            Debug.Log("onbuttonclickedhinzufügen");
            buttons[0].clicked += choiceNodeUIs[0].OnButtonClicked;

            //text und speaker auf das label anwenden
            text.text = node.line.speaker.characterName + ": " + node.line.line;
        }

        public void Visit(DialogeChoiceNode node)
        {
            //wenn es ein dialog event gibt dieses ausführen
            if (node.dialogueEvent != null) node.dialogueEvent.Invoke();
            
            //fehlermeldung wenn zu viele choices gibt
            if (node.choices.Count > 3) throw new Exception("too many choice nodes (max 3)");
            
            //alle choicenodeuis aus der liste entfernen
            choiceNodeUIs.Clear();
            
            //für jede option die man anklicken kann (max 3)
            for (var i = 0; i < node.choices.Count; i++)
            {
                //button auf sichtbar setzen und text des buttons setzen
                buttons[i].style.display = DisplayStyle.Flex;
                buttons[i].text = node.choices[i].choiceNodeButtonText;

                //choicenode uis erstellen und onbuttonclicked funktion dem button hinzufügen und alle anderen gecleared
                choiceNodeUIs[i] = new DialogueChoiceNodeUI(sequencer, node.choices[i]);
                buttons[i].clicked += choiceNodeUIs[i].OnButtonClicked;
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
            dialogueNode.Visit(this);
        }
    }
}