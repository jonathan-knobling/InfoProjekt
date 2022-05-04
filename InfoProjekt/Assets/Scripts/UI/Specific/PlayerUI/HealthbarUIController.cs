using Actors.Player.Stats;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Specific.PlayerUI
{
    public class HealthbarUIController
    {
        private readonly PlayerStats stats;

        private readonly VisualElement healthBar;
        
        public HealthbarUIController(VisualElement root, PlayerStats stats)
        {
            healthBar = root.Q<VisualElement>("healthbar");
            this.stats = stats;
        }

        public void Update()
        {
            healthBar.style.width = new StyleLength(stats.HealthPercentage * Screen.width);
        }
    }
}