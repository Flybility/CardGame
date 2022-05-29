using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Equipment23 : MonoBehaviour, IPointerClickHandler
{
    public bool isInEquipment;
    public int armorValue;
    public MouseInteraction mi;
    public ThisEquiptmentCard card;


    public void OnPointerClick(PointerEventData eventData)
    {
        if (isInEquipment && eventData.button == PointerEventData.InputButton.Left)
        {
            transform.DOScale(1 / mi.clickSize, 0.1f);
            if (card.summonTimes > 0)
            {

                AddArmor(armorValue);
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
    public void AddArmor(int value)
    {
        //主动触发装备
        Skills.Instance.AddArmorToPlayer(value);
        card.summonTimes--;

    }
    // Update is called once per frame
    void Update()
    {

    }
}
