using System;
using NPCs.Dialogue.Nodes;
using UnityEngine;
using UnityEngine.UIElements;
using Util;
using Util.EventArgs;
using Button = UnityEngine.UIElements.Button;

namespace NPCs.Dialogue.UI
{
    public class DialogueUIController: MonoBehaviour, IDialogueNodeVisitor
    {
        private VisualElement root;

        private VisualElement screen;
        private Button[] buttons;
        private Label text;

        private DialogueChoiceNodeUI[] buttonUIs;

        private DialogueSequencer sequencer;
        [SerializeField] private DialogueChannelSO dialogueChannel;

        //TEST
        private Timer timer;
        private void Update()
        {
            timer.Update();
            if (timer.elapsed) timer.OnElapsed -= dialogueChannel.Test;
        }

        private void Start()
        {
            //TEST
            timer = new Timer(2.5f);
            timer.OnElapsed += dialogueChannel.Test;
            
            root = GetComponent<UIDocument>().rootVisualElement;
            
            screen = root.Q<VisualElement>("screen");
            buttons = new Button[3];
            buttons[0] = root.Q<Button>("button1");
            buttons[1] = root.Q<Button>("button2");
            buttons[2] = root.Q<Button>("button3");
            text = root.Q<Label>("text");

            buttonUIs = new DialogueChoiceNodeUI[3];
            
            sequencer = new DialogueSequencer();
            dialogueChannel.OnRequestDialogue += OnDialogueRequested;
            sequencer.OnStartDialogue += OnStartDialogue;
            sequencer.OnEndDialogue += OnEndDialogue;
            sequencer.OnStartDialogueNode += OnStartDialogueNode;
        }

        public void Visit(DialogueLinearNode node)
        {
            //wenn es ein dialog event gibt dieses ausführen
            if (node.dialogueEvent != null)
            {
                node.dialogueEvent.Invoke();
            }
            //alle buttons unsichtbar
            Array.ForEach(buttons, button => button.style.display = DisplayStyle.None);
            //einen button zum confirmen wieder sichtbar machen und text setzen
            buttons[0].style.display = DisplayStyle.Flex;
            buttons[0].text = node.confirmButtonText;
            
            //choicenode ui erstellen und die onbuttonclicked funktion dem button hinzufügen und alle anderen gecleared
            buttonUIs[0] = new DialogueChoiceNodeUI(sequencer, node);
            Debug.Log("onbuttonclickedhinzufügen");
            buttons[0].clicked += buttonUIs[0].OnButtonClicked;
            
            //text und speaker auf das label anwenden
            text.text =  node.line.speaker.characterName + ": " + node.line.line;
        }

        public void Visit(DialogeChoiceNode node)
        {
            //wenn es ein dialog event gibt dieses ausführen
            if (node.dialogueEvent != null)
            {
                node.dialogueEvent.Invoke();
            }
            //fehlermeldung wenn zu viele choices gibt
            if (node.choices.Count > 3)
            {
                throw new Exception("too many choice nodes (max 3)");
            }
            //für jede option die man anklicken kann (max 3)
            for (int i = 0; i < node.choices.Count; i++)
            {
                //button auf sichtbar setzen und text des buttons setzen
                buttons[i].style.display = DisplayStyle.Flex;
                buttons[i].text = node.choices[i].choiceNodeButtonText;
                
                //choicenode uis erstellen und onbuttonclicked funktion dem button hinzufügen und alle anderen gecleared
                buttonUIs[i] = new DialogueChoiceNodeUI(sequencer, node.choices[i]);
                buttons[i].clicked += buttonUIs[i].OnButtonClicked;
            }
            //text und speaker auf das label anwenden
            text.text =  node.line.speaker.characterName + ": " + node.line.line;
        }

        public void OnDialogueRequested(object o, DialogueEventArgs e)
        {
            sequencer.StartDialogue(e.dialogue);
        }

        public void OnStartDialogue(Util.Dialogue dialogue)
        {
            screen.style.display = DisplayStyle.Flex;
        }

        public void OnEndDialogue(Util.Dialogue dialogue)
        {
            screen.style.display = DisplayStyle.None;
        }

        public void OnStartDialogueNode(DialogueNode dialogueNode)
        {
            dialogueNode.Visit(this);
        }
    }
}