using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusEffect : MonoBehaviour
{
    public int Duration;
    public int Amount;
    protected Unit _host;
    int _currentDuration;

    void OnEnable()
    {
        _host = GetComponentInParent<Unit>();
        if(Duration > 0)
        {
            _currentDuration = Duration;
            _host.onUnitTakeTurn += DurationCountdown;
        }
        OnInflicted();
    }

    void OnDisable()
    {
        OnRemoved();
    }

    protected abstract void OnInflicted();

    protected abstract void OnRemoved();

    protected virtual void OnDurationEnded()
    {
        _host.onUnitTakeTurn += DurationCountdown;
        Destroy(this.gameObject);
    }
    
    void DurationCountdown(Unit unit)
    {
        _currentDuration--;
        if(_currentDuration <= 0)
        {
            OnDurationEnded();
        }
    }
}
