using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
    public void DrawCard()
    {
        if(Deck.Cards.Count == 0)
        {
            Debug.Log("No Cards Left");
            return;
        }
        Card card = Deck.Cards[Deck.Cards.Count-1];
        Deck.RemoveCard(card);
        Hand.AddCard(card);
    }

    public void Discard(Card card)
    {
        Hand.RemoveCard(card);
        Deck.RemoveCard(card);
        DiscardPile.AddCard(card);
    }

    public void ShuffleDiscardIntoDeck()
    {
       List<Card> cards = DiscardPile.Cards;
       System.Random rand = new System.Random();
       List<Card> shuffled = new List<Card>(cards.OrderBy (x => rand.Next()).ToList());

       foreach(Card card in shuffled)
       {
        DiscardPile.RemoveCard(card);
        Deck.AddCard(card); 
       }
    }
    #endregion

    #region Cards Events
    public void Play(Card card)
    {
        Transform scriptsHolder = card.transform.Find("Effects/Played");
        foreach(ICardEffect effect in scriptsHolder.GetComponentsInChildren<ICardEffect>())
        {
            effect.Apply();
        }
    }

    public void AfterPlay(Card card)
    {
        Transform scriptsHolder = card.transform.Find("Effects/AfterPlayed");
        foreach(ICardEffect effect in scriptsHolder.GetComponentsInChildren<ICardEffect>())
        {
            effect.Apply();
        }
    }
    #endregion
}