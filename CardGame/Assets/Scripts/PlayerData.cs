using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;



public class PlayerData : MonoSingleton<PlayerData>
{
    public CardDatabase cardData;
    public BattleField battleField;
    public GameObject floatPrefab;
    public Transform playerStatesBar;//玩家属性条
    public Text attackText;
    public Text healthText;
    public List<EquipmentCard> playerEquipmentCards = new List<EquipmentCard>();
    public List<MonsterCard> playerMonsterCards = new List<MonsterCard>();

    public Slider slider;
    //基础状态
    public int maxHealth;
    public int currentHealth;//当前生命值
    public int perRoundHealthDecrease;//每回合降低生命值

    //Buff状态
    public int attackTimes;//攻击次数
    public int armorCount;//护甲层数
    public int scareCount;//恐惧层数
    public int counterattackCount;//反击层数
    public int burnsCount;//灼伤层数
    public int bondageCount;//束缚层数
    public int attackTimesCount;//攻击次数增加层数
    public int initialAttacks;//初始攻击力
    public int currentAttacks;//目前攻击力
    public int monsterCardMaxCount;//初始最大怪物手牌数
    public int perRoundExtractCount;//每回合抽牌数
    public int awardMonsterCardAmount;
    public int awardEquipCardAmount;
    public bool isCounterattackOpen;
    public int counterThreshold;

    private GameObject attackTimeBar;//攻击次数增加栏
    private GameObject counterattackBar;

    // Start is called before the first frame update
    void Awake()
    {
        attackTimes = 1;
        slider =transform.GetChild(0).GetComponent<Slider>();
        currentHealth = maxHealth;
        HealthBarChange();

        playerMonsterCards.Add(cardData.CopyMonsterCard(0));
        playerMonsterCards.Add(cardData.CopyMonsterCard(1));
        playerMonsterCards.Add(cardData.CopyMonsterCard(2));
        playerMonsterCards.Add(cardData.CopyMonsterCard(3));
        playerMonsterCards.Add(cardData.CopyMonsterCard(4));
        playerMonsterCards.Add(cardData.CopyMonsterCard(5));
        playerMonsterCards.Add(cardData.CopyMonsterCard(6));
        playerMonsterCards.Add(cardData.CopyMonsterCard(7));
        playerMonsterCards.Add(cardData.CopyMonsterCard(8));
        playerMonsterCards.Add(cardData.CopyMonsterCard(9));

        playerEquipmentCards.Add(cardData.CopyEquipmentCard(0));
        playerEquipmentCards.Add(cardData.CopyEquipmentCard(1));
        playerEquipmentCards.Add(cardData.CopyEquipmentCard(2));
        playerEquipmentCards.Add(cardData.CopyEquipmentCard(3));
        playerEquipmentCards.Add(cardData.CopyEquipmentCard(4));
        playerEquipmentCards.Add(cardData.CopyEquipmentCard(5));
        playerEquipmentCards.Add(cardData.CopyEquipmentCard(6));
        playerEquipmentCards.Add(cardData.CopyEquipmentCard(7));

        currentAttacks = initialAttacks;
        attackText.text = currentAttacks.ToString();

        //BattleField.Instance.PlayerRoundEnd.AddListener(PerRoundChange);
    }
    //public MonsterCard PlayerRandomMonsterCard()
    //{
    //    MonsterCard card = playerMonsterCards[Random.Range(0, playerMonsterCards.Count)];
    //    return card;
    //}
    //public EquipmentCard PlayerRandomEquipmentCard()
    //{
    //    EquipmentCard card = playerEquipmentCards[Random.Range(0, playerEquipmentCards.Count)];
    //    return card;
    //}
    public void PerBattleRecover()
    {
        currentHealth = maxHealth;
        DecreaseCounterattackCount(counterattackCount);
        DecreaseAttackTimeCount(attackTimesCount);
        HealthBarChange();
    }
    public void ChangeRound()
    {
        StartCoroutine(PerRoundChange());
    }
    IEnumerator PerRoundChange()
    {
        
        
        if (armorCount >0)          armorCount--;
        if (scareCount > 0)         scareCount--;
        if (counterattackCount > 0) DecreaseCounterattackCount(1);
        if (burnsCount > 0)         burnsCount--;
        if (bondageCount > 0)       bondageCount--;
        if (attackTimesCount > 0)   DecreaseAttackTimeCount(1);
        yield return new WaitForSeconds(0.5f);
        HealthDecrease(perRoundHealthDecrease);
        AttackTimeEffect();
    }
    public void AddAttackTimeCount(int counts, GameObject prefab)
    {
        attackTimesCount += counts;
        if (attackTimeBar == null && attackTimesCount != 0)
        {
            attackTimeBar = Instantiate(prefab, playerStatesBar);
            attackTimeBar.transform.GetChild(0).GetComponent<Text>().text = attackTimesCount.ToString();
        }
        else if (attackTimeBar != null && attackTimesCount != 0)
        {
            attackTimeBar.transform.GetChild(0).GetComponent<Text>().text = attackTimesCount.ToString();
        }
        else { return; }

    }
    public void DecreaseAttackTimeCount(int counts)
    {
        attackTimesCount -= counts;
        if (attackTimeBar != null && attackTimesCount <= 0)
        {
            Destroy(attackTimeBar);
        }
        if (attackTimeBar != null && attackTimesCount > 0)
        {
            attackTimeBar.transform.GetChild(0).GetComponent<Text>().text = attackTimesCount.ToString();
        }
        else { attackTimesCount = 0; }
    }
    public void AttackTimeEffect()
    {
        //决定每次攻击几次
        if (attackTimesCount > 0) attackTimes = 2;
        else { attackTimes = 1; }
    }

    public void AddCounterattackCount(int counts,GameObject prefab)
    {
        counterattackCount += counts;
        if (counterattackBar == null && counterattackCount != 0)
        {
            counterattackBar = Instantiate(prefab, playerStatesBar);
            counterattackBar.transform.GetChild(0).GetComponent<Text>().text = counterattackCount.ToString();
        }
        else if (counterattackBar != null && counterattackCount != 0)
        {
            counterattackBar.transform.GetChild(0).GetComponent<Text>().text = counterattackCount.ToString();
        }
        else { return; }
    }
    public void DecreaseCounterattackCount(int counts)
    {

        counterattackCount -= counts;
        if (counterattackBar != null && counterattackCount <= 0)
        {
            Destroy(counterattackBar);
        }
        if (counterattackBar != null && counterattackCount > 0)
        {
            counterattackBar.transform.GetChild(0).GetComponent<Text>().text = counterattackCount.ToString();
        }
        else { counterattackCount = 0; }
    }
    public void CounterattackEffect(int threshold)
    {
        isCounterattackOpen = true;
        counterThreshold = threshold;
    }
    public void HealthDecrease(int damage)
    {
        currentHealth -= damage;
        if (isCounterattackOpen && damage > counterThreshold)
        {
            AddCounterattackCount(1,Skills.Instance.counterattackCounter);
            CheckCounterattacks();
        }
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
        GameObject floatValue= Instantiate(floatPrefab, this.transform);
        floatValue.GetComponent<Text>().text = "-" + damage.ToString();
        floatValue.GetComponent<Text>().color = Color.red;
        HealthBarChange();
    }
    public void HealthRecover(int value)
    {
        currentHealth += value;
        if (currentHealth >= 100)
        {
            currentHealth = 100;
        }
        GameObject floatValue = Instantiate(floatPrefab, this.transform);
        floatValue.GetComponent<Text>().text = "+" + value.ToString();
        floatValue.GetComponent<Text>().color = Color.green;
        HealthBarChange();
    }
    public void HealthBarChange()
    {
        Debug.Log("生命值改变");
        slider.value = (float)currentHealth / maxHealth;
        healthText.text = currentHealth + "/" + maxHealth;
    }
    public void AttackChange(int value)
    {
        currentAttacks =initialAttacks+value;
        attackText.text = currentAttacks.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
        CheckCounterattacks();
    }
    public void CheckCounterattacks()
    {
        AttackChange(counterattackCount);
    }

    //public void loadPlayerData()
    //{
    //    //每行为dataRow数组的一个元素
    //    string[] dataRow = playerData.text.Split('\n');
    //    //对每行元素取逗号隔开部分形成一个rowArray数组
    //    foreach(var row in dataRow)
    //    {
    //        //匹配CardDatabase中数组长度
    //        playerEquipmentCards = new int[CardDatabase.cardList.Count];
    //        playerMonsterCards=new int[CardDatabase.monsterCardList.Count];
    //        string[] rowArray = row.Split(',');
    //        //若第一行为“#”
    //        if (rowArray[0] == "#")
    //        {
    //            continue;
    //        }
    //        //若第一行为“coins”
    //        if (rowArray[0] == "coins")
    //        {
    //            coins= int.Parse(rowArray[1]);
    //        }
    //        //若第一行为“health”
    //        if (rowArray[0] == "health")
    //        {
    //            playerHealth = int.Parse(rowArray[1]);
    //        }
    //        if (rowArray[0] == "san")
    //        {
    //            sanValue = int.Parse(rowArray[1]);
    //        }
    //        if (rowArray[0] == "EquipmentCard")
    //        {
    //            int id = int.Parse(rowArray[1]);
    //            int num = int.Parse(rowArray[2]);
    //            playerEquipmentCards[id] = num;
    //        }
    //        if(rowArray[0] == "MonsterCard")
    //        {
    //            int id = int.Parse(rowArray[1]);
    //            int num = int.Parse(rowArray[2]);
    //            playerMonsterCards[id] = num;
    //        }
    //    }
    //
    //}
    //public void SavePlayerData()
    //{
    //    string path = Application.dataPath + "/Datas/playerData.csv";
    //
    //    List<string> datas = new List<string>();
    //    datas.Add("coins," + coins);
    //    datas.Add("health," + playerHealth);
    //    datas.Add("san," + sanValue);
    //    //保存卡组
    //    for(int i=0; i < playerEquipmentCards.Length; i++)
    //    {
    //        if (playerEquipmentCards[i] != 0)
    //        {
    //            datas.Add("EquiptmentCard," + i + "," + playerEquipmentCards[i]);
    //        }
    //    }
    //    for (int i = 0; i < playerMonsterCards.Length; i++)
    //    {
    //        if (playerMonsterCards[i] != 0)
    //        {
    //            datas.Add("MonsterCard," + i + "," + playerMonsterCards[i]);
    //        }
    //    }
    //    //保存数据
    //    File.WriteAllLines(path, datas);
    //}
}
