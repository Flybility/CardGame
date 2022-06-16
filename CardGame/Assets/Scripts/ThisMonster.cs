using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using DG.Tweening;
using System;

public class ThisMonster : MonoBehaviour
{
    public GameObject monsterCard;
    public Transform block;
    public Vector3 initialStateBlock;
    public Component effect;
    public Image image;
    private int id;
    public int summonTime;
    public int health;
    public int maxHealth;
    public int awardHealth;

    public int currentAwards;
    public float multipleAwards;

    public int attacks;
    public int currentAttacks;
    public int afterMultipleAttacks;
    public float multipleAttacks;//攻击力倍数
    public int attackAttachedScare;//攻击附加恐惧层数
    public int attackAttachedBurns;//攻击附加灼伤层数
    public int attackAttachedBondages;//攻击附加束缚层数

    public int dizzyCount;//眩晕层数
    public int burnsCount;//灼伤层数
    public int burnsDamage;//灼伤伤害
    public int absorbCount;//吸收回合数
    public bool isAbsorbBoom;
    public int absorbDamages;//吸收总伤害数
    public int attackCount;//增加伤害回合数
    public int armorCount;//护甲层数

    public Slider slider;
    public Text healthValue;
    public Text attackText;
    public Transform stateBlock;
    public GameObject dizzy, absorb, attack, burns, armor, alcohol, explodeDizzy;
    public bool isAddAttack;
    public bool isAddAward;
    public bool isAddScareCount;//附加恐惧是否随怪物数增长
    public bool isAddBurnsCount;//附加灼伤是否随怪物数增长
    public bool isBoom;//自身是否爆炸
    public bool isAddAlcohol;//是
    public bool isAddExplodeDizzy;
    public bool isIntangible;//是否无形（可直接攻击）
    public bool isNeighbourAwardMultiple;
    public bool isNeiboursAttackMultiple;
    public bool isIntervalAttackMultiple;

    public bool isSwallowed;
    public GameObject leftMonster, rightMonster;

    public List<GameObject> neighbours;
    public List<GameObject> intervals;
    public List<GameObject> besides;

    public bool isBesideAward;
    public bool isIntervalAttack;
    public bool isBesideAttack;
    public bool isBesideRecover;
    public bool isSelfArmored;
    public int selfArmoredValue;
    public bool isBesideArmored;
    public bool isRoundExchangeBeside;
    public bool isRoundExchangeInterval;
    public bool isRoundSwallowBeside;
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
    public void StartPerRoundChange()
    {
        StartCoroutine(PerRoundChange());
    }
    IEnumerator PerRoundChange()
    {
        BurnsEffect();
        yield return new WaitForSeconds(0.1f);

        if (burnsCount > 0) DecreaseBurns(1);
        if (absorbCount > 0) DecreaseAbsorb(1);
        if (armorCount > 0) DecreaseArmor(armorCount);
        if (isAddAttack) AddAttackPerRound(1);
        if (alcohol != null) { Destroy(alcohol.gameObject);alcohol = null;isAddAlcohol = false; }
        

        


        //if (isRoundExchangeBeside) Skills.Instance.StartExchangeBesidePosition(this.gameObject);
        //yield return new WaitForSeconds(0.22f);
        //if (isRoundExchangeInterval) Skills.Instance.StartExchangeIntervalPosition(this.gameObject);
    }
    public void OnStart()
    {
        multipleAttacks = 1;
        multipleAwards = 1;
        awardHealth = monsterCard.GetComponent<ThisMonsterCard>().award;
        attacks = monsterCard.GetComponent<ThisMonsterCard>().damage;
        currentAttacks = attacks;
        //slider = transform.GetChild(0).GetComponent<Slider>();
        //healthValue = transform.GetChild(1).GetComponent<Text>();
        //stateBlock = transform.GetChild(2);
        initialStateBlock = stateBlock.localPosition;
        //attackText = transform.GetChild(3).GetComponent<Text>();

        //stateBlock.transform.SetParent(transform.parent);
        monsterCard = GetComponentInParent<Blocks>().card;
        id = monsterCard.GetComponent<ThisMonsterCard>().id;
        maxHealth = monsterCard.GetComponent<ThisMonsterCard>().health;
        summonTime = monsterCard.GetComponent<ThisMonsterCard>().summonTimes;
        image.sprite = monsterCard.GetComponent<ThisMonsterCard>().thisSprite;
        health = maxHealth;
        slider.value = (float)health / maxHealth;
        block = transform.parent;
        //effect = gameObject.GetComponent(Type.GetType("Monster" + id));
        BattleField.Instance.MonsterRoundEnd.AddListener(StartPerRoundChange);
    }

    public bool CheckNeighbourAward()
    {
        foreach (var monster in neighbours)
        {
            if (monster.GetComponent<ThisMonster>().isNeighbourAwardMultiple)
            {return true;}
        }
        return false;
    }
    public bool CheckNeighbourAttack()
    {
        foreach (var monster in neighbours)
        {
            if (monster.GetComponent<ThisMonster>().isNeiboursAttackMultiple)
            { return true; }
        }
        return false;
    }
    public bool CheckIntervalAttack()
    {
        foreach (var monster in intervals)
        {
            if (monster.GetComponent<ThisMonster>().isIntervalAttackMultiple)
            { return true; }
        }
        return false;
    }
    public void OnUpdate()
    {
        neighbours = BlocksManager.Instance.GetNeighbours(block.transform);
        intervals = BlocksManager.Instance.GetInterval(block.transform);


        isBesideAward = CheckNeighbourAward();
        isBesideAttack = CheckNeighbourAttack();
        isIntervalAttack = CheckIntervalAttack();

        if ((isBesideAttack && isIntervalAttack))
        {
            multipleAttacks = 1;
        }
        if (isBesideAttack == false && isIntervalAttack == false)
        {
            multipleAttacks = 1;
        }
        if (isBesideAttack && isIntervalAttack == false)
        {
            multipleAttacks = 2;
        }
        if (isBesideAttack == false && isIntervalAttack)
        {
            multipleAttacks = 0.5f;
        }
        if (isBesideAward==false)
        {
            multipleAwards = 1;
        }
        if (isBesideAward)
        {
            multipleAwards = 2;
        }
       
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
            dizzy.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = dizzyCount.ToString();
        }
        else if(dizzy != null && dizzyCount !=0)
        {
            dizzy.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = dizzyCount.ToString();
            dizzy.transform.DOPunchScale(new Vector3(0.4f, 0.4f, 0.4f), 0.3f);
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
            dizzy.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = dizzyCount.ToString();
            dizzy.transform.DOPunchScale(new Vector3(0.4f, 0.4f, 0.4f), 0.3f);
        }
        else { dizzyCount = 0; }
    }
    public void AddAbsorb(int Counts, GameObject absorbPrefab)
    {
        absorbCount += Counts;
        if (absorb == null && absorbCount != 0)
        {
            absorb = Instantiate(absorbPrefab, stateBlock);
            absorb.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = absorbCount.ToString();
        }
        else if (absorb != null && absorbCount != 0)
        {
            absorb.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = absorbCount.ToString();
            absorb.transform.DOPunchScale(new Vector3(0.4f, 0.4f, 0.4f), 0.3f);
        }
        else { return; }

    }
    public void DecreaseAbsorb(int count)
    {
        absorbCount -= count;
        if (absorb != null && absorbCount <= 0)
        {
            if (isAbsorbBoom)
            {
                Skills.Instance.StartBoom(this, absorbDamages);
                HealthDecrease(absorbDamages, false, false);
                absorbDamages = 0;
            }
            else
            {
                Destroy(absorb);
            }

        }
        if (absorb != null && absorbCount > 0)
        {
            absorb.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = absorbCount.ToString();
            absorb.transform.DOPunchScale(new Vector3(0.4f, 0.4f, 0.4f), 0.3f);
        }
        else { absorbCount = 0; }
    }
    public void AddBurns(int Counts, GameObject burnsPrefab)
    {
        burnsCount += Counts;
        if (burns == null && burnsCount != 0)
        {
            burns = Instantiate(burnsPrefab, stateBlock);
            burns.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = burnsCount.ToString();
        }
        else if (burns != null && burnsCount != 0)
        {
            burns.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = burnsCount.ToString();
            burns.transform.DOPunchScale(new Vector3(0.4f, 0.4f, 0.4f), 0.3f);
        }
        else { return; }

    }
    public void DecreaseBurns(int count)
    {
        burnsCount -= count;
        if (burns != null && burnsCount <= 0)
        {
            Destroy(burns);
        }
        if (burns != null && burnsCount > 0)
        {
            burns.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = burnsCount.ToString();
            burns.transform.DOPunchScale(new Vector3(0.4f, 0.4f, 0.4f), 0.3f);
        }
        else { burnsCount = 0; }
    }
    public void BurnsEffect()
    {
        if (burnsCount > 0) { HealthDecrease(burnsDamage,false,true); }

    }
    public void AddArmor(int Counts, GameObject armorPrefab)
    {
        armorCount += Counts;
        if (armor == null && armorCount != 0)
        {
            armor = Instantiate(armorPrefab, stateBlock);
            armor.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = armorCount.ToString();
        }
        else if (armor != null && armorCount != 0)
        {
            armor.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = armorCount.ToString();
            armor.transform.DOPunchScale(new Vector3(0.4f, 0.4f, 0.4f), 0.3f);
        }
        else { return; }

    }
    public void DecreaseArmor(int count)
    {
        armorCount -= count;
        if (armor != null && armorCount <= 0)
        {
            Destroy(armor);
        }
        if (armor != null && armorCount > 0)
        {
            armor.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = armorCount.ToString();
            armor.transform.DOPunchScale(new Vector3(0.4f, 0.4f, 0.4f), 0.3f);
        }
        else { armorCount = 0; }
    }
    public void AddAttack(int count,GameObject prefab)
    {
        isAddAttack = true;
        attackCount = count;
        attack = Instantiate(prefab, stateBlock);
        attack.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = attackCount.ToString();

    }
    public void AddAttackPerRound(int n)
    {
        if (attack != null&& isAddAttack)
        {
            attackCount += n;
            attack.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = attackCount.ToString();
            attack.transform.DOPunchScale(new Vector3(0.4f, 0.4f, 0.4f), 0.3f);
        }
        else return;
    }
    public void HealthDecrease(int damage,bool isStraight,bool isReal)
    {
        if (isIntangible && isStraight)
        {
            damage = 0;
        }
        if (absorbCount > 0)
        {
            absorbDamages += damage;
            damage = 0;
        }
        
        if (armorCount >= damage)
        {
            DecreaseArmor(damage);
            GameObject floatValue = Instantiate(PlayerData.Instance.floatPrefab, this.transform.parent);
            floatValue.GetComponent<Text>().text = "-" + damage.ToString();
        }
        if(armorCount < damage||isReal)
        {
            int realDamage;
            if (isReal) { realDamage = damage; }
            else 
            {
                realDamage = damage - armorCount;
                DecreaseArmor(armorCount);
            } 
            health -= realDamage;
            //Debug.Log("伤害=" + damage);
            slider.value = (float)health / maxHealth;
            GameObject floatValue = Instantiate(PlayerData.Instance.floatPrefab, this.transform.parent);
            floatValue.GetComponent<Text>().text = "-" + damage.ToString();

            if (health <= 0)
            {
                health = 0;
                monsterCard.GetComponent<ThisMonsterCard>().summonTimes--;
                //Destroy(stateBlock.gameObject);
                //击杀怪物回复生命值
                PlayerData.Instance.HealthRecover(currentAwards);
                BattleField.Instance.StartMonsterDead(this.gameObject, monsterCard);
            }
            else{ return;}
        }
    }
    public void HealthRecover(int value)
    {
        health += value;
        if (health > maxHealth)
        {health = maxHealth;}
        slider.value = (float)health / maxHealth;
        GameObject floatValue = Instantiate(PlayerData.Instance.floatHealth, this.transform.parent);
        floatValue.GetComponent<Text>().text = "+" + value.ToString();
    }
   

    // private void OnDestroy()
    // {
    //     Destroy(stateBlock.gameObject);
    // }
    // Start is called before the first frame update


}
