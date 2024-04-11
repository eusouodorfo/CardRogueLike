using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusEffect : MonoBehaviour
{
    public int Duration;
    public int Amount;
    public Unit _host;
    public int _currentDuration;

    void OnEnable()
    {
        _host = GetComponentInParent<Unit>();
        OnInflicted();
    }

    protected abstract void OnInflicted();
    
}
