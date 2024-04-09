using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayCardsState : State
{
    public const string PlayedGameObject = "Effects/Played";

    public const string AfterPlayedGameObject = "Effects/AfterPlayed";

    Button endTurnButtton;

    Coroutine cardSequencer;

    public override IEnumerator Enter()
    {
        yield return null;
        EndTurnButton(true);
        cardSequencer = StartCoroutine(CardSequencer());
    }

    public override IEnumerator Exit()
    {
        yield return null;
        EndTurnButton(false);  
        StopCoroutine(cardSequencer);  
    }

    IEnumerator CardSequencer()
    {
        while(true)
        {
            if(machine.CardsPlaying.Count > 0)
            {
                Card card = machine.CardsPlaying.Dequeue();
                Debug.Log("Playing card "+card.name);
                yield return StartCoroutine(PlayCardEffect(card, card.transform.Find(PlayedGameObject)));
                yield return StartCoroutine(PlayCardEffect(card, card.transform.Find(AfterPlayedGameObject)));
            }
            yield return null;
        }
    }

    IEnumerator PlayCardEffect(Card card, Transform playTransform)
    {
        for(int i=0; i<playTransform.childCount; i++)
        {
            ITarget targeter = playTransform.GetChild(i).GetComponent<ITarget>();
            if(targeter == null)
            {
                yield break;
            }
            List<object> targets = new List<object>();
            yield return StartCoroutine(targeter.GetTargets(targets));
            ICardEffect effect = playTransform.GetChild(i).GetComponent<ICardEffect>();
            if(effect == null)
            {
                yield break;
            }
            yield return StartCoroutine(effect.Apply(targets));
        }
    }

    void EndTurnButton(bool interactability)
    {
        if(endTurnButtton == null)
        {
            endTurnButtton = GameObject.Find("Canvas/EndTurnButton").GetComponent<Button>();
        }
        endTurnButtton.interactable = interactability;
    }
}
