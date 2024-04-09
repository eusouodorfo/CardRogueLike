using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadState : State
{
    public override IEnumerator Enter()
    {
        Debug.Log("Here");
        yield return StartCoroutine(InitializeDeck());
        yield return StartCoroutine(InitializeUnits());
        //
        StartCoroutine(CardsController.Instance.DrawCard(5));
        //
    }

    IEnumerator InitializeDeck()
    {
        foreach(Card card in CardsController.Instance.PlayerDeck.Cards)
        {
            Card newCard = Instantiate(card, Vector3.zero, Quaternion.identity, CardsController.Instance.Deck.Holder);
            CardsController.Instance.Deck.AddCard(newCard);
        }
        yield return new WaitForSeconds(CardHolder.CardMoveDuration);
        CardsController.Instance.Deck.SetInitialRotation();
    }

    IEnumerator InitializeUnits()
    {
        machine.Units = new Queue<Unit>();
        foreach(Unit unit in GameObject.Find("Units").GetComponentsInChildren<Unit>())
        {
            machine.Units.Enqueue(unit);
        }
        Debug.Log(machine.Units.Count);
        yield return null;
    }
}
