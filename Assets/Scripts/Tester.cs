using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public Card Card;
    public CardsController CardsController;

    [ContextMenu("Draw")]
    public void DrawCard()
    {
        CardsController.DrawCard();
    }

    [ContextMenu("Discard")]
    public void RemoveCard()
    {
        CardsController.Discard(Card);
    }

     [ContextMenu("ShuffleDiscard")]
    public void ShuffleDiscard()
    {
        CardsController.ShuffleDiscardIntoDeck();
    }
}
