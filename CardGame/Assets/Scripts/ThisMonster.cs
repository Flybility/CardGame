using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using DG.Tweening;
using TMPro;

public class ThisMonster : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
{
    public GameObject monsterCard;
    public  int health;
    private int maxHealth;
    public int damage;
    private Slider slider;

    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left && BattleField.Instance.SelectingMonster!=1&& BattleField.Instance.usingEquipment==null&&BattleField.Instance.AttackSelecting)
        {
            BattleField.Instance.StartPlayerAttack(this.gameObject);
            //BattleField.Instance.CloseHighlightWithinMonster();
        }
        if(eventData.button == PointerEventData.InputButton.Left && BattleField.Instance.usingEquipment!=null)
        {
            BattleField.Instance.UseEquipment(this.gameObject);
            BattleField.Instance.usingEquipment = null;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(1.1f ,0.1f);
        CursorFollow.Instance.description.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = monsterCard.GetComponent<ThisMonsterCard>().card.description;
        CursorFollow.Instance.description.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(1, 0.1f);
        CursorFollow.Instance.description.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        slider = transform.GetChild(0).GetComponent<Slider>();
        monsterCard = GetComponentInParent<Blocks>().card;
        maxHealth = monsterCard.GetComponent<ThisMonsterCard>().card.health;
        health = maxHealth;
        slider.value= (float)health / maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        damage = monsterCard.GetComponent<ThisMonsterCard>().card.damage;
        
    }

    public void HealthDecrease(int damage)
    {
        health -= damage;
        slider.value = (float)health / maxHealth;
        if (health <= 0)
        {
            monsterCard.GetComponent<ThisMonsterCard>().card.summonTimes--;
            int n= monsterCard.GetComponent<ThisMonsterCard>().card.summonTimes;
            if (n == 0)
            {
                Destroy(monsterCard);
            }
            BattleField.Instance.MonsterDead(this.gameObject, monsterCard);
        }

    }
}
