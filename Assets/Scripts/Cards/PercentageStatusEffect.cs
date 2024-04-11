using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PercentageStatusEffect : StatusEffect
{
    public ModifierTags Tag;

    protected override void OnInflicted()
    {
        _host.Modify[(int)Tag] += PercentageEffect;
    }

    protected override void OnRemoved()
    {
        _host.Modify[(int)Tag] -= PercentageEffect;
    }

    void PercentageEffect(ModifiedValues modifiedValues)
    {
        float amount = Amount;
        float baseValue = modifiedValues.BaseValue;
        modifiedValues.FinalValue += Mathf.FloorToInt(baseValue*(amount/100));
    }
}
