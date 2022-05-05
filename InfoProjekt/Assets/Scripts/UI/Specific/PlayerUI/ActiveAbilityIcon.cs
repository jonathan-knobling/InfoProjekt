using Gameplay.Abilities.Active;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Specific.PlayerUI
{
    public class ActiveAbilityIcon
    {
        private readonly ActiveAbility ability;
        private readonly VisualElement icon;
        private readonly VisualElement timerVE;

        public ActiveAbilityIcon(ActiveAbility ability, VisualElement container, VisualElement icon, VisualElement timerVE)
        {
            if (!ability.icon.Equals(null))
            {
                icon.style.backgroundImage = new StyleBackground(ability.icon);
            }

            container.AddToClassList("abilityIconContainer");
            icon.AddToClassList("abilityIcon");
            timerVE.AddToClassList("timerVE");

            timerVE.visible = false;

            this.ability = ability;
            this.icon = icon;
            this.timerVE = timerVE;

            ability.ReadyState.OnEnterState += OnEnterReadyState;
            ability.CooldownState.OnEnterState += OnEnterCooldownState;
            ability.ActiveState.OnEnterState += OnEnterActiveState;
        }

        public void Update()
        {
            if (ability.State == ability.ReadyState) return;
            
            if (ability.State == ability.CooldownState)
            {
                timerVE.style.width = new StyleLength(new Length(ability.CooldownPercentage, LengthUnit.Percent));
            }

            if (ability.State == ability.ActiveState)
            {
                timerVE.style.width = new StyleLength(new Length(ability.ActiveTimePercentage, LengthUnit.Percent));
            }
        }

        private void OnEnterReadyState()
        {
            if (ability.icon.Equals(null)) return;
        
            icon.style.backgroundImage = new StyleBackground(ability.icon);
        }

        private void OnEnterCooldownState()
        {
            timerVE.style.backgroundColor = new StyleColor(Color.black);
            timerVE.style.width = new StyleLength(new Length(100, LengthUnit.Percent));
            timerVE.visible = true;
        }

        private void OnEnterActiveState()
        {
            timerVE.style.backgroundColor = new StyleColor(new Color(1f, 0.82f, 0.26f));
            timerVE.style.width = new StyleLength(new Length(100, LengthUnit.Percent));
            timerVE.visible = true;
        }
    }
}