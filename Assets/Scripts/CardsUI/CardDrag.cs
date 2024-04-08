using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;


public class CardDrag : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
   
    Card _card;
    bool _dragging;
    Transform _objectToDrag;
    Vector2 _offset;
    Vector3 _savedPosition;

    void Awake()
    {
        _card = GetComponentInParent<Card>();
        _objectToDrag = this.transform.parent.parent;
    }

    void Update()
    {
        if(_dragging)
        {
            _objectToDrag.position = Mouse.current.position.ReadValue() - _offset;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _dragging = true;
        _offset = eventData.position - new Vector2(_objectToDrag.position.x, _objectToDrag.position.y);
        _savedPosition = _card.Rect.anchoredPosition3D;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _dragging = false;
        EventSystem.current.SetSelectedGameObject(null);
        Debug.Log(Mouse.current.position.ReadValue().y);
        if(Mouse.current.position.ReadValue().y > 200)
        {
            Debug.Log("Tentou usar a carta");
        } else {
            _card.Move(_savedPosition, 0.2f, ()=>{});
        }
    }

}
