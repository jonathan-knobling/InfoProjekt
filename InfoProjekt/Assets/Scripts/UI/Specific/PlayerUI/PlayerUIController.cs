using Actors.Player.Stats;
using Gameplay.Inventory;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Specific.PlayerUI
{
    public class PlayerUIController : MonoBehaviour
    {
        [SerializeField] private PlayerStats stats;
        [SerializeField] private UIDocument playerUI;
        [SerializeField] private InventoryManager inventory;

        private StatsMenuUIController statsMenuUI;
        private HotbarUIController hotbarUI;

        private VisualElement root;
        
        private void Start()
        {
            root = playerUI.rootVisualElement;

            var statsRoot = root.Q<VisualElement>("stats_screen");
            var hotbarRoot = root.Q<VisualElement>("hotbar");

            statsMenuUI = new StatsMenuUIController(statsRoot, stats);
            hotbarUI = new HotbarUIController(hotbarRoot, inventory);
        }

        private void Update()
        {
            statsMenuUI.Update();
        }
    }
}
