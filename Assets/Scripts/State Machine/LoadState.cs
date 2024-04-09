using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadState : State
{
    public override IEnumerator Enter()
    {
        Debug.Log("Here");
        yield return null;
    }
}
