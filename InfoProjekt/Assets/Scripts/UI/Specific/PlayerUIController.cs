using Actors.Player.Stats;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Specific
{
    public class PlayerUIController : MonoBehaviour
    {
        [SerializeField] private PlayerStats stats;

        private Label levelText;

        private Label strengthStatText;
        private Label enduranceStatText;
        private Label dexterityStatText;
        private Label agilityStatText;
        private Label magicStatText;

        private Label strengthXPText;
        private Label enduranceXPText;
        private Label dexterityXPText;
        private Label agilityXPText;
        private Label magicXPText;

        private Button levelUpButton;
        private Button statusUpdateButton;

        void Start()
        {
            var root = GetComponent<UIDocument>().rootVisualElement;

            levelText = root.Q<Label>("level");

            strengthStatText = root.Q<Label>("strength_stat");
            enduranceStatText = root.Q<Label>("endurance_stat");
            dexterityStatText = root.Q<Label>("dexterity_stat");
            agilityStatText = root.Q<Label>("agility_stat");
            magicStatText = root.Q<Label>("magic_stat");

            strengthXPText = root.Q<Label>("strength_experience");
            enduranceXPText = root.Q<Label>("endurance_experience");
            dexterityXPText = root.Q<Label>("dexterity_experience");
            agilityXPText = root.Q<Label>("agility_experience");
            magicXPText = root.Q<Label>("magic_experience");

            levelUpButton = root.Q<Button>("levelup");
            statusUpdateButton = root.Q<Button>("status_update");

            levelUpButton.clicked += LevelUpButtonPressed;
            statusUpdateButton.clicked += StatusUpdateButtonPressed;
        }

        private void Update()
        {
            levelText.text = "LEVEL: " + stats.Level + " (" + stats.levelXP + ")";

            strengthStatText.text = "STRENGTH: " + stats.CurrentStatus[StatusAbility.Strength] + " | " + stats.HiddenStatus[StatusAbility.Strength] + " | " + stats.TotalStatus[StatusAbility.Strength];
            enduranceStatText.text = "ENDURANCE: " + stats.CurrentStatus[StatusAbility.Endurance] + " | " + stats.HiddenStatus[StatusAbility.Endurance] + " | " + stats.TotalStatus[StatusAbility.Endurance];
            dexterityStatText.text = "DEXTERITY: " + stats.CurrentStatus[StatusAbility.Dexterity] + " | " + stats.HiddenStatus[StatusAbility.Dexterity] + " | " + stats.TotalStatus[StatusAbility.Dexterity];
            agilityStatText.text = "AGILITY: " + stats.CurrentStatus[StatusAbility.Agility] + " | " + stats.HiddenStatus[StatusAbility.Agility] + " | " + stats.TotalStatus[StatusAbility.Agility];
            magicStatText.text = "MAGIC: " + stats.CurrentStatus[StatusAbility.Magic] + " | " + stats.HiddenStatus[StatusAbility.Magic] + " | " + stats.TotalStatus[StatusAbility.Magic];

            strengthXPText.text = "STRENGTH XP: " + stats.currentXP[StatusAbility.Strength];
            enduranceXPText.text = "ENDURANCE XP: " + stats.currentXP[StatusAbility.Endurance];
            dexterityXPText.text = "DEXTERITY XP: " + stats.currentXP[StatusAbility.Dexterity];
            agilityXPText.text = "AGILITY XP: " + stats.currentXP[StatusAbility.Agility];
            magicXPText.text = "MAGIC XP: " + stats.currentXP[StatusAbility.Magic];


            if (stats.LevelUpPossible) 
            {
                levelUpButton.style.display = DisplayStyle.Flex;
            } else
            {
                levelUpButton.style.display = DisplayStyle.None;
            }

            if(stats.StatusUpdatePossible)
            {
                statusUpdateButton.style.display = DisplayStyle.Flex;
            } else
            {
                statusUpdateButton.style.display = DisplayStyle.None;
            }
        }

        void LevelUpButtonPressed()
        {
            stats.LevelUp();
        }

        void StatusUpdateButtonPressed()
        {
            stats.StatusUpdate();
        }
    }
}
