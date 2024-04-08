using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardHolder : MonoBehaviour
{
    
    public List<Card> Cards;
    public TextMeshProUGUI CardAmount;
    public RectTransform Holder;
    public int CardRotation;

    void Awake()
    {
        Cards = new List<Card>(GetComponentsInChildren<Card>());
        CardAmount.text = ""+Cards.Count;
        SetInitialRotation();
    }

    public void AddCard(Card card)
    {
        RectTransform rect = card.transform as RectTransform;
        rect.anchorMax = Holder.anchorMax;
        rect.anchorMin = Holder.anchorMin;
        rect.pivot = Holder.pivot;
        CardHolder oldHolder = rect.GetComponentInParent<CardHolder>();
        rect.SetParent(this.transform);
        Vector3 targetPosition = Holder.anchoredPosition3D;

        rect.LeanRotateAroundLocal(Vector3.up, oldHolder.CardRotation-CardRotation, 0.2f);
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

    void SetInitialRotation()
    {
        foreach(Card card in Cards)
        {
            RectTransform rect = card.transform as RectTransform;
            rect.localRotation = Quaternion.Euler(0, CardRotation, 0);
        }
    }
}
