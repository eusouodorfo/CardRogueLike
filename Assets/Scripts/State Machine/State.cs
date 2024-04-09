using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public virtual IEnumerator Enter()
    {
        yield return null;
    }

    public virtual IEnumerator Exit()
    {
        yield return null;
    }
}
