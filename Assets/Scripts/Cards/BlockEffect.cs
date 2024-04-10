using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockEffect : MonoBehaviour, ICardEffect
{
   public int Amount;

   public IEnumerator Apply(List<object> targets)
   {
      foreach (object o in targets)
      {
         Unit unit = o as Unit;
         Debug.LogFormat("Unit {0} gain {1} Block", unit, Amount);
         int currentBlock = unit.GetStatValue(StatTypes.Block);
         unit.SetStatValue(StatTypes.Block, currentBlock + Amount);
         
         yield return null;
      }
   }
}
