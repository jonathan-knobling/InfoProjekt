using System.Net.Http.Headers;
using Actors.Player.Stats;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Specific.PlayerUI
{
    public class MPBarUIController
    {
        private readonly PlayerStats stats;

        private readonly VisualElement mpBar;

        public MPBarUIController(PlayerStats stats, VisualElement root)
        {
            this.stats = stats;
            mpBar = root.Q<VisualElement>("mpbar");
        }

        public void Update()
        {
            mpBar.style.width = new StyleLength(stats.MPPercentage * Screen.width);
        }
    }
}