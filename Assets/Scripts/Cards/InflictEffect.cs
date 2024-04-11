using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InflictEffect : MonoBehaviour, ICardEffect
{
   public StatusEffect StatusEffectPrefab;

   public IEnumerator Apply(List<object> targets)
   {
      foreach (object o in targets)
      {
         Unit unit = o as Unit;

         yield return null;
      }
   }
}
