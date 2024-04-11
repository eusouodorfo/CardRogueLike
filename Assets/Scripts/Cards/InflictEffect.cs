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
         StatusEffect instantiated = Instantiate(StatusEffectPrefab, Vector3.zero, Quaternion.identity, unit.transform); 
         instantiated.name = StatusEffectPrefab.name;

         yield return null;
      }
   }
}
