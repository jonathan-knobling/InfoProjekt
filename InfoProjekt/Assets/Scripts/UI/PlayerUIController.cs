using UnityEngine.UIElements;
using UnityEngine;

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

        levelUpButton.clicked += levelUpButtonPressed;
        statusUpdateButton.clicked += statusUpdateButtonPressed;
    }

    private void Update()
    {
        levelText.text = "LEVEL: " + stats.getLevel() + " (" + stats.getLevelXP() + ")";

        strengthStatText.text = "STRENGTH: " + stats.getCurrentStats()[0] + " | " + stats.getHiddenStats()[0] + " | " + stats.getTotalStats()[0];
        enduranceStatText.text = "ENDURANCE: " + stats.getCurrentStats()[1] + " | " + stats.getHiddenStats()[1] + " | " + stats.getTotalStats()[1];
        dexterityStatText.text = "DEXTERITY: " + stats.getCurrentStats()[2] + " | " + stats.getHiddenStats()[2] + " | " + stats.getTotalStats()[2];
        agilityStatText.text = "AGILITY: " + stats.getCurrentStats()[3] + " | " + stats.getHiddenStats()[3] + " | " + stats.getTotalStats()[3];
        magicStatText.text = "MAGIC: " + stats.getCurrentStats()[4] + " | " + stats.getHiddenStats()[4] + " | " + stats.getTotalStats()[4];

        strengthXPText.text = "STRENGTH XP: " + stats.getCurrentXP()[0];
        enduranceXPText.text = "ENDURANCE XP: " + stats.getCurrentXP()[1];
        dexterityXPText.text = "DEXTERITY XP: " + stats.getCurrentXP()[2];
        agilityXPText.text = "AGILITY XP: " + stats.getCurrentXP()[3];
        magicXPText.text = "MAGIC XP: " + stats.getCurrentXP()[4];


        if (stats.getLevelUpPossible()) 
        {
            levelUpButton.style.display = DisplayStyle.Flex;
        } else
        {
            levelUpButton.style.display = DisplayStyle.None;
        }

        if(stats.getStatusUpdatePossible())
        {
            statusUpdateButton.style.display = DisplayStyle.Flex;
        } else
        {
            statusUpdateButton.style.display = DisplayStyle.None;
        }
    }

    void levelUpButtonPressed()
    {
        stats.LevelUp();
    }

    void statusUpdateButtonPressed()
    {
        stats.statusUpdate();
    }
}
