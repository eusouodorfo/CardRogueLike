using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : CardEffect
{
   public int Amount;

   public override IEnumerator Apply(List<object> targets)
   {
      foreach (object o in targets)
      {
         Unit unit = o as Unit;

         ModifiedValues modifiedValues = new ModifiedValues(Amount);
         ApplyModifier(modifiedValues, ModifierTags.DoAttackDamage, StateMachine.Instance.CurrentUnit);
         ApplyModifier(modifiedValues, ModifierTags.TakeAttackDamage, unit);

         int block = unit.GetStatValue(StatTypes.Block);
         int leftoverBlock = Mathf.Max(0, block - modifiedValues.FinalValue);
         unit.SetStatValue(StatTypes.Block, leftoverBlock);

         int currentHP = unit.GetStatValue(StatTypes.HP);
         int leftoverDamage = Mathf.Max(0, modifiedValues.FinalValue - block);
         unit.SetStatValue(StatTypes.HP, Mathf.Max(currentHP - leftoverDamage, 0));

         Debug.LogFormat("Unit {0} block went from {1} to {2}; HP from {3} to {4}",
         unit, block, leftoverBlock, currentHP, unit.GetStatValue(StatTypes.HP));
         yield return null;
      }
   }

   void ApplyModifier(ModifiedValues modifiedValues, ModifierTags tag, Unit unit)
   {
      TagModifier modify = unit.Modify[(int)tag];
      if(modify != null)
      {
         modify(modifiedValues);
      }
   }
}
