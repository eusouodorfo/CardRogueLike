using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetUnit : MonoBehaviour, ITarget
{
    Unit clickedUnit;

    public IEnumerator GetTargets(List<object> targets)
    {
        clickedUnit = null;

        foreach(Unit unit in StateMachine.Instance.Units)
        {
            unit.onUnitClicked += OnUnitClicked;
        }

        while (clickedUnit == null)
        {
            yield return null;
        }
        targets.Add(clickedUnit);

        foreach(Unit unit in StateMachine.Instance.Units)
        {
            unit.onUnitClicked -= OnUnitClicked;
        }
    }

    void OnUnitClicked(Unit unit)
    {
        clickedUnit = unit;
    }
}
