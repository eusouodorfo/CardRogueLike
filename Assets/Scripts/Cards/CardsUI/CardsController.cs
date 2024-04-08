using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor.SearchService;

public class CardsController : MonoBehaviour
{
    #region Fields/Properties

    public static CardsController Instance;

    public CardHolder Hand;
    public CardHolder Deck;
    public CardHolder DiscardPile;

    #endregion

    void Awake()
    {
        Instance = this;
    }

    #region Card Control

    public IEnumerator DrawCard(int amount = 1)
    {
        while (amount > 0)
        {
            if (Deck.Cards.Count == 0)
            {
                yield return StartCoroutine(ShuffleDiscardIntoDeck());
                yield return new WaitForSeconds(CardHolder.CardMoveDuration);
                if (Deck.Cards.Count == 0)
                {
                    Debug.Log("No Cards Left");
                    yield break;
                }
            }
            Card card = Deck.Cards[Deck.Cards.Count - 1];
            Deck.RemoveCard(card);
            Hand.AddCard(card);
            amount--;
            yield return new WaitForSeconds(0.25f);
        }

    }

    public void Discard(Card card)
    {
        Hand.RemoveCard(card);
        Deck.RemoveCard(card);
        DiscardPile.AddCard(card);
    }

    public IEnumerator ShuffleDiscardIntoDeck()
    {
        List<Card> cards = DiscardPile.Cards;
        System.Random rand = new System.Random();
        List<Card> shuffled = new List<Card>(cards.OrderBy(x => rand.Next()).ToList());

        foreach (Card card in shuffled)
        {
            DiscardPile.RemoveCard(card);
            Deck.AddCard(card);
            yield return new WaitForSeconds(0.1f);
        }
    }
    #endregion

    #region Cards Events
    public void Play(Card card)
    {
        Transform scriptsHolder = card.transform.Find("Effects/Played");
        //
        List<object> targets = new List<object>();
        targets.Add(CombatTester.instance.Defender);
        //
        foreach (ICardEffect effect in scriptsHolder.GetComponentsInChildren<ICardEffect>())
        {
            effect.Apply(targets);
        }
    }

    public void AfterPlay(Card card)
    {
        Transform scriptsHolder = card.transform.Find("Effects/AfterPlayed");
        ICardEffect effect = scriptsHolder.GetComponentInChildren<ICardEffect>();
        ITarget target = scriptsHolder.GetComponentInChildren<ITarget>();
        effect.Apply(target.GetTargets());
    }
    #endregion
}