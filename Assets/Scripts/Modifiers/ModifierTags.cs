using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void TagModifier(ModifiedValues modifiedValues);

public enum ModifierTags 
{
    DoAttackDamage,
    TakeAttackDamage,
    GainBlock //sempre manter por ultimo para nao quebrar o script 
}
