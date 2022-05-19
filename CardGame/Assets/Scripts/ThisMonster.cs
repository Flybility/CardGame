using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using DG.Tweening;
using TMPro;
using System;

public class ThisMonster : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
{
    public GameObject monsterCard;
    public Transform block;
    public Component effect;
    private int id;
    public int summonTime;
    public  int health;
    private int maxHealth;
    public int awardHealth;
    public int damage;
    public int dizzyCount;//眩晕层数
    public int burnsCount;//灼伤层数
    private Slider slider;
    private TextMeshProUGUI healthValue; 
    private Transform stateBlock;
    private GameObject dizzy;
    public GameObject leftMonster, rightMonster;


    void Start()
    {
        OnStart();
       
    }

    // Update is called once per frame
    void Update()
    {
        //leftMonster=transform.parent.parent.
        OnUpdate();

    }

    public void PerRoundChange()
    {
        if (dizzyCount > 0) DecreaseDizzy(1);
        if (burnsCount > 0) burnsCount--;
    }
    public void OnStart()
    {
        stateBlock = transform.GetChild(2);
        awardHealth = monsterCard.GetComponent<ThisMonsterCard>().card.award;
        damage = monsterCard.GetComponent<ThisMonsterCard>().card.damage;
        slider = transform.GetChild(0).GetComponent<Slider>();
        healthValue = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        monsterCard = GetComponentInParent<Blocks>().card;
        id = monsterCard.GetComponent<ThisMonsterCard>().id;
        maxHealth = monsterCard.GetComponent<ThisMonsterCard>().card.health;
        summonTime = monsterCard.GetComponent<ThisMonsterCard>().summonTimes;
        health = maxHealth;
        slider.value = (float)health / maxHealth;
        block = transform.parent;
        //effect = gameObject.GetComponent(Type.GetType("Monster" + id));
        BattleField.Instance.MonsterRoundEnd.AddListener(PerRoundChange);
    }
    public void OnUpdate()
    {
        healthValue.text = health + "/" + maxHealth;
    }
    public void AddDizzy(int Counts,GameObject dizzyPrefab)
    {
        dizzyCount += Counts;
        if (dizzy == null&&dizzyCount!=0)
        {
            dizzy= Instantiate(dizzyPrefab, stateBlock);
            dizzy.transform.GetChild(0).GetComponent<Text>().text = dizzyCount.ToString();
        }
        else if(dizzy != null && dizzyCount !=0)
        {
            dizzy.transform.GetChild(0).GetComponent<Text>().text = dizzyCount.ToString();
        }
        else { return; }
       
    }
    public void DecreaseDizzy(int count)
    {
        dizzyCount -= count;
         if (dizzy != null && dizzyCount <= 0)
        {
            Destroy(dizzy);
        }
        if (dizzy != null && dizzyCount > 0)
        {
            dizzy.transform.GetChild(0).GetComponent<Text>().text = dizzyCount.ToString();
        }
        else { dizzyCount = 0; }
    }

    public void HealthDecrease(int damage)
    {
        health -= damage;
        slider.value = (float)health / maxHealth;
        GameObject floatValue = Instantiate(PlayerData.Instance.floatPrefab, this.transform.parent);
        floatValue.GetComponent<Text>().text ="-"+ damage.ToString();
        if (health <= 0)
        {
            monsterCard.GetComponent<ThisMonsterCard>().summonTimes--;
            BattleField.Instance.StartMonsterDead(this.gameObject, monsterCard);
        }
        else
        {
            return;
        }

    }
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
            //BattleField.Instance.usingEquipment = null;
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


}
