using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    
    RectTransform _rect;
    Transform _back;
    Transform _front;

    void Awake()
    {
        _rect = GetComponent<RectTransform>();
        _back = transform.Find("Back"); 
        _front = transform.Find("Front");  
    }

    void Update()
    {
        if(_rect.rotation.eulerAngles.y > 90 && _rect.rotation.eulerAngles.y < 270)
        {
            _back.SetAsLastSibling();
        } else {
            _front.SetAsLastSibling();
        }
    }

}
