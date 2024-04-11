using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatChangeEffect : StatusEffect
{
    public StatTypes Type;

    protected override void OnInflicted()
    {
        int currentvalue = _host.GetStatValue(Type);
        _host.SetStatValue(Type, currentvalue + Amount);
    }

    protected override void OnRemoved()
    {
        int currentvalue = _host.GetStatValue(Type);
        _host.SetStatValue(Type, currentvalue - Amount);
    }
}
