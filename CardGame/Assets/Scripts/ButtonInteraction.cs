using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonInteraction : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(1.15f, 0.1f); ;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(1, 0.1f); 
    }
}
