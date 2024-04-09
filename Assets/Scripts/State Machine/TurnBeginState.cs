using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBeginState : State
{
    public override IEnumerator Enter()
    {
        machine.CurrentUnit = machine.Units.Dequeue();
        machine.Units.Enqueue(machine.CurrentUnit);

        yield return new WaitForSeconds(0.1f);
        StartCoroutine(WaitThenChangeState<RecoveryState>());
    }
}
