using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] spellSounds;
    
    private GameManager gameManager;
    
    private void Start()
    {
        gameManager = GameManager.Instance;
    }
    
    private void Update()
    {
        HandleKeyboardInput();
    }
    
    private void HandleKeyboardInput()
    {
        WitchController activeWitch = gameManager.GetActiveWitch();
        
        if (Input.GetKeyDown(KeyCode.E))
            CastSpell(1, 0);
        else if (Input.GetKeyDown(KeyCode.R))
            CastSpell(2, 1);
        else if (Input.GetKeyDown(KeyCode.T))
            CastSpell(3, 2);
        else if (Input.GetKeyDown(KeyCode.Space))
            CastUltimate();
    }
    
    public void CastSpell(int spellType, int soundIndex)
    {
        WitchController activeWitch = gameManager.GetActiveWitch();
        activeWitch.CastSpell(spellType);
        
        if (soundIndex >= 0 && soundIndex < spellSounds.Length)
        {
            activeWitch.PlaySound(spellSounds[soundIndex]);
        }
    }
    
    public void CastUltimate()
    {
        WitchController activeWitch = gameManager.GetActiveWitch();
        activeWitch.CastUltimate();
        
        if (spellSounds.Length > 0)
        {
            activeWitch.PlaySound(spellSounds[0]);
        }
    }
}