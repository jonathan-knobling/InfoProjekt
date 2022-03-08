using System;
using NPCs.Dialogue.Nodes;
using UnityEngine;
using UnityEngine.UIElements;
using Util;
using Util.EventArgs;
using Button = UnityEngine.UIElements.Button;

namespace NPCs.Dialogue
{
    public class DialogueUIController: MonoBehaviour, IDialogueNodeVisitor
    {
        private VisualElement root;

        private VisualElement screen;
        private Button[] buttons;
        private Label text;

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

            sequencer = new DialogueSequencer();
            dialogueChannel.OnRequestDialogue += OnDialogueRequested;
            sequencer.OnStartDialogue += OnStartDialogue;
            sequencer.OnEndDialogue += OnEndDialogue;
            sequencer.OnStartDialogueNode += OnStartDialogueNode;
        }

        public void Visit(DialogueLinearNode node)
        {
            //alle buttons unsichtbar
            Array.ForEach(buttons, button => button.style.display = DisplayStyle.None);
            text.text =  node.line.speaker.characterName + ": " + node.line.line;
        }

        public void Visit(DialogeChoiceNode node)
        {
            //für jede option die man anklicken kann (max 3)
            for (int i = 0; i < node.choices.Count; i++)
            {
                //button auf sichtbar setzen und text des buttons setzen
                buttons[i].style.display = DisplayStyle.Flex;
                buttons[i].text = node.choices[i].choiceNodeButtonText;
            }
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