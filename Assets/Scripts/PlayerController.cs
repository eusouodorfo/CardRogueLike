using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public void wasdAlgo(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Debug.Log("Botao pressionado");
        }
    }
}
