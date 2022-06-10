using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Equipment4 : MonoBehaviour,IPointerClickHandler
{
    public bool isInEquipment;
    public MouseInteraction mi;
    public ThisEquiptmentCard card;

    void Start()
    {
        mi = GetComponent<MouseInteraction>();
        isInEquipment = mi.isInEquipment;
        card = GetComponent<ThisEquiptmentCard>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (isInEquipment && eventData.button == PointerEventData.InputButton.Left)
        {
            transform.DOScale(1 / mi.clickSize, 0.1f);
            if (card.summonTimes > 0)
            {
                PlayerData.Instance.isAttackBesides = true;
                card.summonTimes--;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
