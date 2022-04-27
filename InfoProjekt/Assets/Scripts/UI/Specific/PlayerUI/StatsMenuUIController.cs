using Actors.Player.Stats;
using UnityEngine.UIElements;

namespace UI.Specific.PlayerUI
{
    public class StatsMenuUIController
    {
        private readonly PlayerStats stats;
        
        private readonly Label levelText;

        private readonly Label strengthStatText;
        private readonly Label enduranceStatText;
        private readonly Label dexterityStatText;
        private readonly Label agilityStatText;
        private readonly Label magicStatText;

        private readonly Button levelUpButton;
        private readonly Button statusUpdateButton;

        public StatsMenuUIController(VisualElement root, PlayerStats stats)
        {
            levelText = root.Q<Label>("level");

            strengthStatText = root.Q<Label>("strength_stat");
            enduranceStatText = root.Q<Label>("endurance_stat");
            dexterityStatText = root.Q<Label>("dexterity_stat");
            agilityStatText = root.Q<Label>("agility_stat");
            magicStatText = root.Q<Label>("magic_stat");

            levelUpButton = root.Q<Button>("levelup");
            statusUpdateButton = root.Q<Button>("status_update");

            levelUpButton.clicked += LevelUpButtonPressed;
            statusUpdateButton.clicked += StatusUpdateButtonPressed;

            this.stats = stats;
        }

        public void Update()
        {
            levelText.text = "LEVEL: " + stats.Level;

            strengthStatText.text = "STRENGTH: " + stats.CurrentStatus[StatusAbility.Strength];
            enduranceStatText.text = "ENDURANCE: " + stats.CurrentStatus[StatusAbility.Endurance];
            dexterityStatText.text = "DEXTERITY: " + stats.CurrentStatus[StatusAbility.Dexterity];
            agilityStatText.text = "AGILITY: " + stats.CurrentStatus[StatusAbility.Agility];
            magicStatText.text = "MAGIC: " + stats.CurrentStatus[StatusAbility.Magic];


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