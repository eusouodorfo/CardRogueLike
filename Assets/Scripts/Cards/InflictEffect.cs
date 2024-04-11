using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InflictEffect : CardEffect
{
   public StatusEffect StatusEffectPrefab;

   public override IEnumerator Apply(List<object> targets)
   {
      foreach (object o in targets)
      {
         Unit unit = o as Unit;

         yield return null;
      }
   }
}
