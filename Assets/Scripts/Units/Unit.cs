using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public delegate void OnUnitClicked(Unit unit);

public class Unit : MonoBehaviour, IPointerClickHandler
{
    public List<Stat> Stats;
    public OnUnitClicked onUnitClicked = delegate{};

    public virtual IEnumerator Recover()
    {
        yield return null;
    }

    [ContextMenu("Generate Stats")]
    void GenerateStats()
    {
        Stats = new List<Stat>();
        for (int i = 0; i < (int)StatTypes.Dextery + 1; i++)
        {
            Stat stat = new Stat();
            stat.Type = (StatTypes)i;
            stat.value = Random.Range(0, 100);
            Stats.Add(stat);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        onUnitClicked(this);
    }
}
