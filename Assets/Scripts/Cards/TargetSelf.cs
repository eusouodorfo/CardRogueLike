using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSelf : MonoBehaviour, ITarget
{
    public IEnumerator GetTargets(List<object> targets)
    {
        Card card = GetComponentInParent<Card>();
        targets.Add(card);
        yield return null;
    }
}
