using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBeginState : State
{
    PlayerUnit _playerUnit;

    public override IEnumerator Enter()
    {
        machine.CurrentUnit = null;

        while (machine.CurrentUnit == null && machine.Units.Count > 0)
        {
            machine.CurrentUnit = machine.Units.Dequeue();
            if (machine.CurrentUnit.GetStatValue(StatTypes.HP) <= 0)
            {
                Debug.LogFormat("{0} tried to play, but was dead", machine.CurrentUnit);
                machine.CurrentUnit = null;
            }else{
                machine.Units.Enqueue(machine.CurrentUnit);
            }
        }
        if (_playerUnit == null)
        {
            _playerUnit = machine.CurrentUnit as PlayerUnit;
        }

        yield return new WaitForSeconds(0.1f);

        if (machine.Units.Count == 1 || _playerUnit.GetStatValue(StatTypes.HP) <= 0)
        {
            StartCoroutine(WaitThenChangeState<EndBattleState>());
        }
        else
        {
            StartCoroutine(WaitThenChangeState<RecoveryState>());
        }
    }
}
