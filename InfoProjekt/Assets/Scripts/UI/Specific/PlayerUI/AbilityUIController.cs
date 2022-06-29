using System.Collections.Generic;
using Gameplay.Abilities;
using UnityEngine.UIElements;

namespace UI.Specific.PlayerUI
{
    public class AbilityUIController
    {
        private readonly List<ActiveAbilityIcon> abilityIcons;
        
        public AbilityUIController(VisualElement root, AbilityManager abilityManager)
        {
            abilityIcons = new List<ActiveAbilityIcon>();
            
            var abilityContainer = root.Q<VisualElement>("ability_container");

            foreach (var ability in abilityManager.ActiveAbilities)
            {
                var iconContainer = new VisualElement();
                var icon = new VisualElement();
                var timerVE = new VisualElement();
                
                abilityIcons.Add(new ActiveAbilityIcon(ability, iconContainer, icon, timerVE));

                iconContainer.Add(icon);
                abilityContainer.Add(iconContainer);
            }
        }

        public void Update()
        {
            foreach (var abilityIcon in abilityIcons)
            {
                abilityIcon.Update();
            }   
        }
    }
}