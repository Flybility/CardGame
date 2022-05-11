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
        if (eventData.button == PointerEventData.InputButton.Left && BattleField.Instance.SelectingMonster==1&& BattleField.Instance.usingEquipment==null)
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
        if (health <= 0)
        {
            BattleField.Instance.MonsterDead(this.gameObject,monsterCard);
            monsterCard.GetComponent<ThisMonsterCard>().card.summonTimes--;
            Destroy(gameObject);
        }
    }

    public void HealthDecrease(int damage)
    {
        health -= damage;
        slider.value = (float)health / maxHealth;
    }
}
