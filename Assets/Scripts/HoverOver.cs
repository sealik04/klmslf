using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject border;
    public AudioSource hover;
    
    public void Start()
    {
        border.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        border.SetActive(true);
        hover.Play(0);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        border.SetActive(false);
    }
}
