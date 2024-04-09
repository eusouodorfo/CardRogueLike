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

    [ContextMenu("Play Card")]
    public void Play()
    {
        CardsController.Instance.Play(Card);
    }

    [ContextMenu("After Play Card")]
    public void AfterPlay()
    {
        CardsController.Instance.AfterPlay(Card);
    }
}
