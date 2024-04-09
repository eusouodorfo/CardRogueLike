using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public static StateMachine Instance;
    public State Current{get{return _current;}}
    State _current;
    bool _busy;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ChangeTo<LoadState>();
    }

    #region State Control

    public void ChangeTo<T> () where T:State
    {
        State state = GetState<T>();
        if(_current != state)
        {
            StartCoroutine(ChangeState(state));
        }
    }

    State GetState<T>() where T:State{
        T target = GetComponent<T>();
        if(target == null)
        {
            target = gameObject.AddComponent<T>();
        }
        return target;
    }

    IEnumerator ChangeState(State state)
    {
        if(_busy)
        {
            yield break;
        }

        _busy = true;

        if(_current != null)
        {
            yield return StartCoroutine(_current.Exit());
        }

        _current = state;
        if(_current != null)
        {
            yield return StartCoroutine(_current.Enter());
        }

        _busy = false;
    }

    #endregion
}
