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
         int currentHP = unit.GetStatValue(StatTypes.HP);
         unit.SetStatValue(StatTypes.HP, Mathf.Max(currentHP - Amount, 0));
         Debug.LogFormat("Unit {0} took {1} Damage", unit, Amount);
         yield return null;
      }
   }
}
