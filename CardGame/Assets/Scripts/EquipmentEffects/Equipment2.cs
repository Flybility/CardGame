using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Equipment2 : MonoBehaviour,IPointerClickHandler
{
    public bool isInEquipment;
    public MouseInteraction mi;
    public ThisEquiptmentCard card;
    // Start is called before the first frame update
    void Start()
    {
        mi = GetComponent<MouseInteraction>();
        isInEquipment = mi.isInEquipment;
        card = GetComponent<ThisEquiptmentCard>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (isInEquipment && eventData.button == PointerEventData.InputButton.Left)
        {
            transform.DOScale(1 / mi.clickSize, 0.1f);
            if (card.summonTimes > 0)
            {
                //加层数
                Skills.Instance.AddAttackTimesCount(1);
                PlayerData.Instance.AttackTimeEffect();
                card.summonTimes--;
            }
        }
    }
}
