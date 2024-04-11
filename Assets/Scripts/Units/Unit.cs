using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public delegate void OnUnit(Unit unit);

public class Unit : MonoBehaviour, IPointerClickHandler
{

    [SerializeField]
    List<Stat> _stats;

    public OnUnit onUnitClicked = delegate{};
    public OnUnit onUnitTakeTurn = delegate{};

    public TagModifier[] Modify = new TagModifier[(int)ModifierTags.GainBlock+1];

    public virtual IEnumerator Recover()
    {
        SetStatValue(StatTypes.Block, 0);
        onUnitTakeTurn(this);
        yield return null;
    }

    [ContextMenu("Generate Stats")]
    void GenerateStats()
    {
        _stats = new List<Stat>();
        for (int i = 0; i < (int)StatTypes.Dextery + 1; i++)
        {
            Stat stat = new Stat();
            stat.Type = (StatTypes)i;
            stat.Value = Random.Range(0, 100);
            _stats.Add(stat);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        onUnitClicked(this);
    }

    public int GetStatValue(StatTypes type)
    {
        //modifier
        return _stats[(int)type].Value;
    }

    public void SetStatValue(StatTypes type, int value)
    {
        //modifier
        _stats[(int)type].Value = value;
    }
}
