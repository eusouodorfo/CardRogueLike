using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discard : MonoBehaviour, ICardEffect
{
    public void Apply()
    {
        ITarget target = GetComponent<ITarget>();
        List<object> targets = target.GetTargets();

        foreach(object o in targets)
        {
            Card card = o as Card;
            CardsController.Instance.Discard(card);
        }
    }
}
