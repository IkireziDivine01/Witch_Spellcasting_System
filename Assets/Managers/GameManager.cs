using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [SerializeField] private WitchController[] witches;
    private int activeWitchIndex = 0;
    
    public event Action<int> OnWitchChanged;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Start()
    {
        if (witches.Length > 0)
        {
            witches[0].Activate();
        }
    }
    
    public void SelectWitch(int index)
    {
        if (index == activeWitchIndex) return;
        if (index < 0 || index >= witches.Length) return;
        
        witches[activeWitchIndex].Deactivate();
        activeWitchIndex = index;
        witches[activeWitchIndex].Activate();
        
        OnWitchChanged?.Invoke(index);
    }
    
    public WitchController GetActiveWitch()
    {
        return witches[activeWitchIndex];
    }
    
    public int GetActiveWitchIndex()
    {
        return activeWitchIndex;
    }
}