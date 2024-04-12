using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void TagModifier(ModifiedValues modifiedValues);

public enum ModifierTags 
{
    DoAttackDamage,
    TakeAttackDamage,
    GainBlock,
    WhenUnitDies,
    None
}
