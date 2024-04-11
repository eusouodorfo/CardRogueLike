using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockEffect : CardEffect
{
   public int Amount;

   public override IEnumerator Apply(List<object> targets)
   {
      foreach (object o in targets)
      {
         Unit unit = o as Unit;

         ModifiedValues modifiedValues = new ModifiedValues(Amount);
         ApplyModifier(modifiedValues, ModifierTags.GainBlock, StateMachine.Instance.CurrentUnit);

         Debug.LogFormat("Unit {0} gain {1} Block", unit, modifiedValues.FinalValue);
         int currentBlock = unit.GetStatValue(StatTypes.Block);
         unit.SetStatValue(StatTypes.Block, currentBlock + modifiedValues.FinalValue);
         
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
