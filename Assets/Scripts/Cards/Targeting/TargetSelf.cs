using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSelf : MonoBehaviour, ITarget
{
    public List<object> GetTargets()
    {
        List<object> targets = new List<object>();
        Card card = GetComponentInParent<Card>();
        targets.Add(card);
        return targets;
    }
}
