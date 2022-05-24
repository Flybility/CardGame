using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using DG.Tweening;

public class Equipment18 : MonoBehaviour, IPointerClickHandler
{
    public bool isInEquipment;
    public int recoverValue;
    public MouseInteraction mi;
    public ThisEquiptmentCard card;


    public void OnPointerClick(PointerEventData eventData)
    {
        if (isInEquipment && eventData.button == PointerEventData.InputButton.Left)
        {
            transform.DOScale(1 / mi.clickSize, 0.1f);
            if (card.summonTimes > 0)
            {
                RecoverHealth(recoverValue);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        mi = GetComponent<MouseInteraction>();
        isInEquipment = mi.isInEquipment;
        card = GetComponent<ThisEquiptmentCard>();
    }
    public void RecoverHealth(int value)
    {
        //主动触发装备
        Skills.Instance.RecoverHealth(value);
        card.summonTimes--;

    }
    // Update is called once per frame
    void Update()
    {

    }
}
