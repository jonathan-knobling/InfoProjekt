using UnityEngine;
using UnityEngine.UIElements;

namespace Player
{
    public class PlayerUIController : MonoBehaviour
    {

        [SerializeField] private Stats stats;

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
            levelText.text = "LEVEL: " + stats.Level + " (" + stats.LevelXP + ")";

            strengthStatText.text = "STRENGTH: " + stats.CurrentStats[0] + " | " + stats.HiddenStats[0] + " | " + stats.TotalStats[0];
            enduranceStatText.text = "ENDURANCE: " + stats.CurrentStats[1] + " | " + stats.HiddenStats[1] + " | " + stats.TotalStats[1];
            dexterityStatText.text = "DEXTERITY: " + stats.CurrentStats[2] + " | " + stats.HiddenStats[2] + " | " + stats.TotalStats[2];
            agilityStatText.text = "AGILITY: " + stats.CurrentStats[3] + " | " + stats.HiddenStats[3] + " | " + stats.TotalStats[3];
            magicStatText.text = "MAGIC: " + stats.CurrentStats[4] + " | " + stats.HiddenStats[4] + " | " + stats.TotalStats[4];

            strengthXPText.text = "STRENGTH XP: " + stats.CurrentXP[0];
            enduranceXPText.text = "ENDURANCE XP: " + stats.CurrentXP[1];
            dexterityXPText.text = "DEXTERITY XP: " + stats.CurrentXP[2];
            agilityXPText.text = "AGILITY XP: " + stats.CurrentXP[3];
            magicXPText.text = "MAGIC XP: " + stats.CurrentXP[4];


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
