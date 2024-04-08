using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : MonoBehaviour, ICardEffect
{
   public int Amount;

   public void Apply(List<object> targets)
   {
      foreach(object o in targets)
      {
         Unit unit = o as Unit;
         //unit.takeDamage(Amount);
        Debug.LogFormat("Unit {0} took {1} Damage", unit, Amount);
      }
   }
}
