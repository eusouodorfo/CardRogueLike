using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discard : MonoBehaviour, ICardEffect
{
    public IEnumerator Apply(List<object> targets)
    {
        foreach(object o in targets)
        {
            Card card = o as Card;
            CardsController.Instance.Discard(card);
            yield return new WaitForSeconds(0.1f);
        }
        
    }
}
