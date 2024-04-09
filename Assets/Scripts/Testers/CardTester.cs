using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTester : MonoBehaviour
{
    public Card Card;


    [ContextMenu("Draw")]
    public void DrawCard()
    {
        StartCoroutine(CardsController.Instance.DrawCard());
    }

    [ContextMenu("Discard")]
    public void RemoveCard()
    {
        CardsController.Instance.Discard(Card);
    }

    [ContextMenu("ShuffleDiscard")]
    public void ShuffleDiscard()
    {
        StartCoroutine(CardsController.Instance.ShuffleDiscardIntoDeck());
    }

}
