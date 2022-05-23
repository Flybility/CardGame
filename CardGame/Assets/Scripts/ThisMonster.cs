using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using DG.Tweening;
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

    public int currentAwards;
    public float multipleAwards;

    public int attacks;
    public int currentAttacks;
    public int afterMultipleAttacks;
    public float multipleAttacks;//攻击力倍数
    public int attackAttachedScare;
    public int dizzyCount;//眩晕层数
    public int burnsCount;//灼伤层数
    public int absorbCount;//吸收回合数
    public int absorbDamages;//吸收总伤害数
    public int attackCount;//增加伤害回合数

    private Slider slider;
    private Text healthValue;
    private Text attackText;
    private Transform stateBlock;
    private GameObject dizzy, absorb,attack;
    private bool isAddAttack;
    public bool isAddAward;
    public bool isAddScareCount;//附加恐惧是否随怪物数增长
    public bool isIntangible;//是否无形（可直接攻击）
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
        if (absorbCount > 0) DecreaseAbsorb(1);
        if (isAddAttack) AddAttackPerRound(1);
    }
    public void OnStart()
    {
        multipleAttacks = 1;
        multipleAwards = 1;
        awardHealth = monsterCard.GetComponent<ThisMonsterCard>().card.award;
        attacks = monsterCard.GetComponent<ThisMonsterCard>().card.damage;
        currentAttacks = attacks;
        slider = transform.GetChild(0).GetComponent<Slider>();
        healthValue = transform.GetChild(1).GetComponent<Text>();
        stateBlock = transform.GetChild(2);
        attackText = transform.GetChild(3).GetComponent<Text>();
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
        afterMultipleAttacks = (int)(currentAttacks * multipleAttacks*(attackCount+1));
        if (isAddAward)
        {
            currentAwards = (int)((awardHealth*(BattleField.Instance.perRoundDead+1))* multipleAwards);
        }
        else
        {
            currentAwards = (int)((awardHealth) * multipleAwards);
        }

        attackText.text = ((int)(afterMultipleAttacks*(1+ PlayerData.Instance.extraHurt))).ToString();
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
            dizzy.transform.GetChild(0).transform.DOPunchScale(new Vector3(0.4f, 0.4f, 0.4f), 0.3f);
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
            dizzy.transform.GetChild(0).transform.DOPunchScale(new Vector3(0.4f, 0.4f, 0.4f), 0.3f);
        }
        else { dizzyCount = 0; }
    }
    public void AddAbsorb(int Counts, GameObject absorbPrefab)
    {
        absorbCount += Counts;
        if (absorb == null && absorbCount != 0)
        {
            absorb = Instantiate(absorbPrefab, stateBlock);
            absorb.transform.GetChild(0).GetComponent<Text>().text = absorbCount.ToString();
        }
        else if (absorb != null && absorbCount != 0)
        {
            absorb.transform.GetChild(0).GetComponent<Text>().text = absorbCount.ToString();
            absorb.transform.GetChild(0).transform.DOPunchScale(new Vector3(0.4f, 0.4f, 0.4f), 0.3f);
        }
        else { return; }

    }
    public void DecreaseAbsorb(int count)
    {
        absorbCount -= count;
        if (absorb != null && absorbCount <= 0)
        {
            Skills.Instance.StartBoom(block, absorbDamages);
            absorbDamages = 0;
            Destroy(absorb);
        }
        if (absorb != null && absorbCount > 0)
        {
            absorb.transform.GetChild(0).GetComponent<Text>().text = absorbCount.ToString();
            absorb.transform.GetChild(0).transform.DOPunchScale(new Vector3(0.4f, 0.4f, 0.4f), 0.3f);
        }
        else { absorbCount = 0; }
    }
    public void AddAttack(int count,GameObject prefab)
    {
        isAddAttack = true;
        attackCount = count;
        attack = Instantiate(prefab, stateBlock);
        attack.transform.GetChild(0).GetComponent<Text>().text = attackCount.ToString();

    }
    public void AddAttackPerRound(int n)
    {
        if (attack != null&& isAddAttack)
        {
            attackCount += n;
            attack.transform.GetChild(0).GetComponent<Text>().text = attackCount.ToString();
            attack.transform.GetChild(0).transform.DOPunchScale(new Vector3(0.4f, 0.4f, 0.4f), 0.3f);
        }
        else return;
    }
    public void HealthDecrease(int damage,bool isStraight)
    {
        if (absorbCount > 0)
        {
            absorbDamages += damage;
            damage = 0;
        }
        if (isIntangible && isStraight)
        {
            damage = 0;
        }
        health -= damage;
        //Debug.Log("伤害=" + damage);
        slider.value = (float)health / maxHealth;
        GameObject floatValue = Instantiate(PlayerData.Instance.floatPrefab, this.transform.parent);
        floatValue.GetComponent<Text>().text = "-" + damage.ToString();
       
        if (health <= 0)
        {
            monsterCard.GetComponent<ThisMonsterCard>().summonTimes--;
            //击杀怪物回复生命值
            PlayerData.Instance.HealthRecover(currentAwards);
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
        Invoke("ShowDescription", 0.1f);
        CursorFollow.Instance.description.SetActive(true);
        Color color = CursorFollow.Instance.description.GetComponent<Image>().color;
        CursorFollow.Instance.description.GetComponent<Image>().DOColor(new Color(color.r, color.g, color.b, 1), 0.4f);
    }
    public void ShowDescription()
    {
        CursorFollow.Instance.description.transform.GetChild(0).GetComponent<Text>().text = monsterCard.GetComponent<ThisMonsterCard>().cardName + ":" + "\n" + monsterCard.GetComponent<ThisMonsterCard>().card.description + "\n\n" + "击杀获得情绪量:" + "<b>" + "<color=blue>" + currentAwards + "</color>" + "</b>";
        if (absorbCount > 0)
        {
            CursorFollow.Instance.description.transform.GetChild(0).GetComponent<Text>().text = monsterCard.GetComponent<ThisMonsterCard>().cardName + ":"+ "\n" + monsterCard.GetComponent<ThisMonsterCard>().card.description + "\n" + "击杀获得情绪量:" + "<b>"+"<color=blue>"+currentAwards+ "</color>" +"</b>" + "\n"
                + "已储蓄爆炸伤害:" + "<b>" + "<color=red>" + absorbDamages + "</color>" + "</b>";
        }
        else if (isAddAttack)
        {
            CursorFollow.Instance.description.transform.GetChild(0).GetComponent<Text>().text = monsterCard.GetComponent<ThisMonsterCard>().cardName + ":" + "\n" + monsterCard.GetComponent<ThisMonsterCard>().card.description + "\n" + "击杀获得情绪量:" + "<b>" + "<color=blue>" + currentAwards + "</color>" + "</b>" + "\n"
               + "伤害增加:" + "<b>" + "<color=red>" + attackCount + "</color>" + "</b>"+"倍";
        }
        else if (isAddAward)
        {
            CursorFollow.Instance.description.transform.GetChild(0).GetComponent<Text>().text = monsterCard.GetComponent<ThisMonsterCard>().cardName + ":" + "\n" + monsterCard.GetComponent<ThisMonsterCard>().card.description + "\n" + "击杀获得情绪量:" + "<b>" + "<color=blue>" + currentAwards + "</color>" + "</b>" + 
              "*本回合击杀怪物数("+"<b>" + "<color=red>" + BattleField.Instance.perRoundDead + "</color>" + "</b>"+")";
        }
        
           
 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(1, 0.1f);
        CursorFollow.Instance.description.transform.GetChild(0).GetComponent<Text>().text = null;
        CursorFollow.Instance.description.SetActive(false);
    }

    // Start is called before the first frame update


}
