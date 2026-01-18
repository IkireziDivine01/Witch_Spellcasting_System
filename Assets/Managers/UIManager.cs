using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup[] screens;
    [SerializeField] private Button[] witchSelectButtons;
    [SerializeField] private Button[] spellButtons;
    [SerializeField] private Button backButton;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Toggle muteToggle;
    
    private int activeScreenIndex = 0;
    private GameManager gameManager;
    private InteractionManager interactionManager;
    
    private void Start()
    {
        gameManager = GameManager.Instance;
        interactionManager = GetComponent<InteractionManager>();
        
        SetupButtons();
        ShowScreen(0);
    }
    
    private void SetupButtons()
    {
        // Witch selection buttons
        for (int i = 0; i < witchSelectButtons.Length; i++)
        {
            int index = i;
            witchSelectButtons[i].onClick.AddListener(() => SelectWitch(index));
        }
        
        // Spell buttons
        for (int i = 0; i < spellButtons.Length; i++)
        {
            int spellType = i + 1;
            spellButtons[i].onClick.AddListener(() => 
                interactionManager.CastSpell(spellType, i));
        }
        
        // Back button
        backButton.onClick.AddListener(() => ShowScreen(0));
        
        // Volume controls
        if (volumeSlider != null)
            volumeSlider.onValueChanged.AddListener(SetVolume);
        if (muteToggle != null)
            muteToggle.onValueChanged.AddListener(SetMute);
    }
    
    public void SelectWitch(int index)
    {
        gameManager.SelectWitch(index);
        ShowScreen(1);
    }
    
    public void ShowScreen(int screenIndex)
    {
        if (screenIndex == activeScreenIndex) return;
        
        // Fade out current
        screens[activeScreenIndex].alpha = 0;
        screens[activeScreenIndex].gameObject.SetActive(false);
        
        // Fade in new
        screens[screenIndex].gameObject.SetActive(true);
        screens[screenIndex].alpha = 1;
        
        activeScreenIndex = screenIndex;
    }
    
    private void SetVolume(float value)
    {
        AudioListener.volume = value;
    }
    
    private void SetMute(bool isMuted)
    {
        AudioListener.volume = isMuted ? 0 : volumeSlider.value;
    }
}