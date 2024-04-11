using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayCardsState : State
{
    public const string PlayedGameObject = "Effects/Played";

    public const string AfterPlayedGameObject = "Effects/AfterPlayed";

    Button _endTurnButtton;

    Coroutine _cardSequencer;

    HorizontalLayoutGroup _handLayout;

    void Awake()
    {
        _handLayout = CardsController.Instance.Hand.Holder.GetComponent<HorizontalLayoutGroup>();
    }

    public override IEnumerator Enter()
    {
        yield return new WaitForSeconds(0.5f);
        EndTurnButton(true);
        _handLayout.enabled = false;
        _cardSequencer = StartCoroutine(CardSequencer());
    }

    public override IEnumerator Exit()
    {
        yield return null;
        EndTurnButton(false);  
        _handLayout.enabled = true;
        StopCoroutine(_cardSequencer);  
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
                yield return new WaitForSeconds(0.5f);
                yield return StartCoroutine(PlayCardEffect(card, card.transform.Find(AfterPlayedGameObject)));
                yield return new WaitForSeconds(0.5f);
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
                continue;
            }
            List<object> targets = new List<object>();
            yield return StartCoroutine(targeter.GetTargets(targets));
            foreach(CardEffect effect in playTransform.GetChild(i).GetComponents<CardEffect>())
            {
                yield return StartCoroutine(effect.Apply(targets));
            }               
        }
    }

    void EndTurnButton(bool interactability)
    {
        if(_endTurnButtton == null)
        {
            _endTurnButtton = GameObject.Find("Canvas/EndTurnButton").GetComponent<Button>();
        }
        _endTurnButtton.interactable = interactability;
    }
}
