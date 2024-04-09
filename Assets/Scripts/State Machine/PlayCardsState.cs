using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCardsState : State
{
    public override IEnumerator Enter()
    {
        yield return null;
        //StartCoroutine(WaitThenChangeState<EndTurnState>());
    }
}
