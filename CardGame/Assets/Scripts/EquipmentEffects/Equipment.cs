using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using DG.Tweening;

public class Equipment : MonoBehaviour,IPointerClickHandler
{
    public bool isInEquipment;
    public int damage;
    public MouseInteraction mi;
    public ThisEquiptmentCard card;

    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (isInEquipment && eventData.button == PointerEventData.InputButton.Left)
        {
            transform.DOScale(1 / mi.clickSize, 0.1f);
            UseEquipmentRequest(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        mi = GetComponent<MouseInteraction>();
        isInEquipment = mi.isInEquipment;
        card = GetComponent<ThisEquiptmentCard>();
        
        BattleField.Instance.useEquipmentEvent.AddListener(ToMonster);
    }
    //可主动选择怪物触发型
    public void UseEquipmentRequest(GameObject equipment)
    {
        if (equipment.GetComponent<ThisEquiptmentCard>())
        {
            ThisEquiptmentCard card = equipment.GetComponent<ThisEquiptmentCard>();
            if (card.summonTimes > 0)
            {             
               BattleField.Instance.CreateArrow(equipment.transform, BattleField.Instance.ArrowPrefab);
               BattleField.Instance.usingEquipment = equipment;
               BattleField.Instance.OpenHighlightWithinMonster();               
            }
        }
    }
    public void ToMonster(GameObject monster)
    {
        if (card.id == BattleField.Instance.usingEquipment.GetComponent<ThisEquiptmentCard>().id)
        {
            Skills.Instance.StartExchangePosition(monster,0);
            BattleField.Instance.usingEquipment = null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }


}
