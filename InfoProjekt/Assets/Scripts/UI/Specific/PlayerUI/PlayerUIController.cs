using Actors.Player.Stats;
using Gameplay.Abilities;
using Gameplay.Inventory;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Specific.PlayerUI
{
    public class PlayerUIController : MonoBehaviour
    {
        [SerializeField] private InventoryManager inventory;
        [SerializeField] private PlayerStats stats;
        [SerializeField] private UIDocument playerUI;
        [SerializeField] private AbilityManager abilityManager;

        private StatsMenuUIController statsMenuUI;
        private HotbarUIController hotbarUI;
        private HealthbarUIController healthbarUI;
        private MPBarUIController mpBarUI;
        private AbilityUIController abilityUI;

        private VisualElement root;
        
        private void Start()
        {
            root = playerUI.rootVisualElement;

            var statsRoot = root.Q<VisualElement>("stats_screen");
            var hotbarRoot = root.Q<VisualElement>("hotbar");
            //var abilitiesRoot = root.Q<VisualElement>("abilities");

            statsMenuUI = new StatsMenuUIController(statsRoot, stats);
            hotbarUI = new HotbarUIController(hotbarRoot, inventory);
            healthbarUI = new HealthbarUIController(root, stats);
            mpBarUI = new MPBarUIController(stats, root);
            //abilityUI = new AbilityUIController(abilitiesRoot, abilityManager);
        }

        private void Update()
        {
            statsMenuUI.Update();
            healthbarUI.Update();
            mpBarUI.Update();
            //abilityUI.Update();
        }
    }
}
