using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Serialization;


public class UIButtonPress : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    [HideInInspector]
    public bool Pressed = false;

    [FormerlySerializedAs("onClick")]
    public UnityEvent onPressed;

   
  

    private void Start()
    {
        if (onPressed == null)
        {
            onPressed = new UnityEvent();
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Pressed = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Pressed = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
    }

    public void Update()
    {
        if (Pressed)
        {
            onPressed.Invoke();
        }
    }
}

