using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonInteraction : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler,IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        transform.DOScale(0.9f, 0.1f);
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(1.15f, 0.1f); 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(1, 0.1f); 
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.DOScale(1, 0.1f);
    }
}
