using UnityEngine;

public class WitchController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private string witchName;
    
    private bool isActive = false;
    
    private void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }
    
    public void Activate()
    {
        isActive = true;
        gameObject.SetActive(true);
    }
    
    public void Deactivate()
    {
        isActive = false;
        gameObject.SetActive(false);
    }
    
    public void CastSpell(int spellType)
    {
        if (!isActive) return;
        animator.SetInteger("spellType", spellType);
    }
    
    public void CastUltimate()
    {
        if (!isActive) return;
        animator.SetTrigger("ultimate");
    }
    
    public void PlaySound(AudioClip clip, float volume = 1f)
    {
        if (!isActive || audioSource == null) return;
        audioSource.PlayOneShot(clip, volume);
    }
    
    public string GetWitchName() => witchName;
    public bool IsActive() => isActive;
}