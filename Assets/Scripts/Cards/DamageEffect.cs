using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : MonoBehaviour, ICardEffect
{
   public int Amount;

   public IEnumerator Apply(List<object> targets)
   {
      foreach (object o in targets)
      {
         Unit unit = o as Unit;

         TagModifier modifier = unit.Modify[(int)ModifierTags.Damage];
         if(modifier != null)
         {
            ModifiedValues modifiedValues = new ModifiedValues(Amount);
            modifier(modifiedValues);
            Debug.LogFormat("Base Value: {0}; Modified value : {1}", modifiedValues.BaseValue, modifiedValues.FinalValue);
         }

         int block = unit.GetStatValue(StatTypes.Block);
         int leftoverBlock = Mathf.Max(0, block - Amount);
         unit.SetStatValue(StatTypes.Block, leftoverBlock);

         int currentHP = unit.GetStatValue(StatTypes.HP);
         int leftoverDamage = Mathf.Max(0, Amount - block);
         unit.SetStatValue(StatTypes.HP, Mathf.Max(currentHP - leftoverDamage, 0));

         Debug.LogFormat("Unit {0} block went from {1} to {2}; HP from {3} to {4}",
         unit, block, leftoverBlock, currentHP, unit.GetStatValue(StatTypes.HP));
         yield return null;
      }
   }
}
