using UnityEngine;
using System.Collections;

public class WitchController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private string witchName;
    [SerializeField] private float spellDuration = 6f; // Adjust this based on your longest animation
    
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
        StartCoroutine(ReturnToIdleAfter(spellDuration));
    }
    
    public void CastUltimate()
    {
        if (!isActive) return;
        animator.SetTrigger("ultimate");
        StartCoroutine(ReturnToIdleAfter(spellDuration));
    }
    
    private IEnumerator ReturnToIdleAfter(float duration)
    {
        yield return new WaitForSeconds(duration);
        animator.SetInteger("spellType", 0);
    }
    
    public void PlaySound(AudioClip clip, float volume = 1f)
    {
        if (!isActive || audioSource == null) return;
        audioSource.PlayOneShot(clip, volume);
    }
    
    public string GetWitchName() => witchName;
    public bool IsActive() => isActive;
}