using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUnit : Unit
{
    public int MaxEnergy;

    public int CurrentEnergy
    {
        get 
        {
            return _currentEnergy;
        }
        set
        {
            _currentEnergy = value;
            UpdateEnergyMeter();
        }
    }

    [SerializeField]
    int _currentEnergy;

    public int DrawAmount;

    TextMeshProUGUI _energyMeter;

    void Awake()
    {
        _energyMeter = GameObject.Find("Canvas/EnergyMeter").GetComponent<TextMeshProUGUI>();
        _energyMeter.text = string.Format("{0}/{1}", CurrentEnergy, MaxEnergy);
    }

    public override IEnumerator Recover()
    {
        yield return StartCoroutine(base.Recover());
        CurrentEnergy = MaxEnergy;
        yield return StartCoroutine(CardsController.Instance.DrawCard(DrawAmount));
    }

    public void UpdateEnergyMeter()
    {
        _energyMeter.text = string.Format("{0}/{1}", CurrentEnergy, MaxEnergy);
    }
}
