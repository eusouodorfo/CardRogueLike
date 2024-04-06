using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardHolder : MonoBehaviour
{
    
    public List<Card> Cards;
    public TextMeshProUGUI CardAmount;
    public RectTransform Holder;
    public int InRotation;

    void Awake()
    {
        Cards = new List<Card>(GetComponentsInChildren<Card>());
        CardAmount.text = ""+Cards.Count;
    }

    public void AddCard(Card card)
    {
        RectTransform rect = card.transform as RectTransform;
        rect.anchorMax = Holder.anchorMax;
        rect.anchorMin = Holder.anchorMin;
        rect.pivot = Holder.pivot;
        rect.SetParent(this.transform);
        UnityEngine.Vector3 targetPosition = Holder.anchoredPosition3D;

        rect.LeanRotateAroundLocal(UnityEngine.Vector3.up, -InRotation, 0.2f);

        rect.LeanMove(targetPosition, 0.5f).setOnComplete(()=>
        {
            Cards.Add(card);
            card.transform.SetParent(Holder);
            CardAmount.text = ""+Cards.Count;
        });
    }

    public void RemoveCard(Card card)
    {
        Cards.Remove(card);
        CardAmount.text = ""+Cards.Count;
    }
}
