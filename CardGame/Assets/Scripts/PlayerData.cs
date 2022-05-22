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
    public GameObject floatHealth;
    public GameObject floatAttack;
    public Transform playerStatesBar;//玩家属性条
    public Text attackText;
    public Text healthText;
    public List<EquipmentCard> playerEquipmentCards = new List<EquipmentCard>();
    public List<MonsterCard> playerMonsterCards = new List<MonsterCard>();

    public Slider slider;
    //基础状态
    public int maxHealth;
    public int currentHealth;//当前生命值
    public int perRoundHealthDecrease;//每回合固定降低生命值
    public int extraPerRoundHealthDecrease;//额外每回合降低生命值
    public int extraHurt;//额外受到伤害

    //Buff状态
    public int attackTimes;//攻击次数
    public int armorCount;//护甲层数
    public int scareCount;//恐惧层数
    public int angerCount;//反击层数
    public int burnsCount;//灼伤层数
    public int bondageCount;//束缚层数
    public int attackTimesCount;//攻击次数增加层数
    public int initialAttacks;//初始攻击力
    public int currentAttacks;//目前攻击力
    public int tempAttaks;//临时攻击力
    public int monsterCardMaxCount;//初始最大怪物手牌数
    public int perRoundExtractCount;//每回合抽牌数
    public int tempExtraCardMax;//临时增加最大抽牌数
    public int awardMonsterCardAmount;
    public int awardEquipCardAmount;
    public bool isAngerCountOpen;
    public int counterThreshold;

    public int perRoundHurt;

    private GameObject attackTimeBar;//攻击次数增加栏
    private GameObject angerBar;
    private GameObject scareBar;


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
        playerMonsterCards.Add(cardData.CopyMonsterCard(10));
        playerMonsterCards.Add(cardData.CopyMonsterCard(11));
        playerMonsterCards.Add(cardData.CopyMonsterCard(12));
        playerMonsterCards.Add(cardData.CopyMonsterCard(13));
        playerMonsterCards.Add(cardData.CopyMonsterCard(14));
        playerMonsterCards.Add(cardData.CopyMonsterCard(15));

        playerEquipmentCards.Add(cardData.CopyEquipmentCard(0));
        playerEquipmentCards.Add(cardData.CopyEquipmentCard(1));
        playerEquipmentCards.Add(cardData.CopyEquipmentCard(2));
        playerEquipmentCards.Add(cardData.CopyEquipmentCard(3));
        playerEquipmentCards.Add(cardData.CopyEquipmentCard(4));
        //playerEquipmentCards.Add(cardData.CopyEquipmentCard(5));
        //playerEquipmentCards.Add(cardData.CopyEquipmentCard(6));
        //playerEquipmentCards.Add(cardData.CopyEquipmentCard(7));

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
        tempAttaks = 0;
        tempExtraCardMax = 0;
        isAngerCountOpen = false;
        DecreaseCounterattackCount(angerCount);
        DecreaseAttackTimeCount(attackTimesCount);
        DecreaseScareCount(scareCount);
        HealthBarChange();
    }
    public void ChangeRound()
    {
        StartCoroutine(PerRoundChange());
    }
    IEnumerator PerRoundChange()
    {

        if (armorCount >0)          armorCount--;
        if (scareCount > 0)         DecreaseScareCount(1);
        if (angerCount > 0)         DecreaseCounterattackCount(angerCount/2);
        if (burnsCount > 0)         burnsCount--;
        if (bondageCount > 0)       bondageCount--;
        if (attackTimesCount > 0)   DecreaseAttackTimeCount(1);
        //确保在玩家抽入手牌之后
        yield return new WaitForSeconds(0.3f);
        HealthDecrease(perRoundHealthDecrease+ extraPerRoundHealthDecrease);
        AttackTimeEffect();
        ScareEffect();
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
    public void AddScareCount(int counts, GameObject prefab)
    {
        scareCount += counts;
        if (scareBar == null && scareCount != 0)
        {
            scareBar = Instantiate(prefab, playerStatesBar);
            scareBar.transform.GetChild(0).GetComponent<Text>().text = scareCount.ToString();
        }
        else if (scareBar != null && scareCount != 0)
        {
            scareBar.transform.GetChild(0).GetComponent<Text>().text = scareCount.ToString();
        }
        else { return; }

    }
    public void DecreaseScareCount(int counts)
    {
        scareCount -= counts;
        if (scareBar != null && scareCount <= 0)
        {
            Destroy(scareBar);
        }
        if (scareBar != null && scareCount > 0)
        {
            scareBar.transform.GetChild(0).GetComponent<Text>().text = scareCount.ToString();
        }
        else { scareCount = 0; }
    }
    public void ScareEffect()
    {
        if (scareCount > 0) { extraHurt = scareCount; }
        else { extraHurt = 0; }
    }

    public void AddCounterattackCount(int counts,GameObject prefab)
    {
        angerCount += counts;
        if (angerBar == null && angerCount != 0)
        {
            angerBar = Instantiate(prefab, playerStatesBar);
            angerBar.transform.GetChild(0).GetComponent<Text>().text = angerCount.ToString();
        }
        else if (angerBar != null && angerCount != 0)
        {
            angerBar.transform.GetChild(0).GetComponent<Text>().text = angerCount.ToString();
        }
        else { return; }
    }
    public void DecreaseCounterattackCount(int counts)
    {

        angerCount -= counts;
        if (angerBar != null && angerCount <= 0)
        {
            Destroy(angerBar);
        }
        if (angerBar != null && angerCount > 0)
        {
            angerBar.transform.GetChild(0).GetComponent<Text>().text = angerCount.ToString();
        }
        else { angerCount = 0; }
    }
    public void AngerEffect(int threshold)
    {
        isAngerCountOpen = true;
        counterThreshold = threshold;
    }



    public void HealthDecrease(int damage)
    {
        int plus= damage + extraHurt;
        currentHealth -= plus;
        perRoundHurt += plus;
        if (isAngerCountOpen && plus > counterThreshold)
        {
            AddCounterattackCount(1,Skills.Instance.counterattackCounter);
            CheckAttacks();
        }
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
        if (damage > 0)
        {
            GameObject floatValue = Instantiate(floatPrefab, this.transform);
            floatValue.GetComponent<Text>().text = "-" + plus.ToString();
            HealthBarChange();
        }    
    }
    public void HealthRecover(int value)
    {
        currentHealth += value;
        if (currentHealth >= 100)
        {
            currentHealth = 100;
        }
        if (value > 0)
        {
            GameObject floatValue = Instantiate(floatHealth, this.transform);
            floatValue.GetComponent<Text>().text = "+" + value.ToString();
            HealthBarChange();
        }       
    }
    public void HealthBarChange()
    {
        Debug.Log("生命值改变");
        slider.value = (float)currentHealth / maxHealth;
        healthText.text = currentHealth + "/" + maxHealth;
    }
    public void StartAddTempAttacks(int value)
    {
        tempAttaks += value;
        GameObject floatAttacks = Instantiate(floatAttack, transform.position+Vector3.up*20,Quaternion.identity);
        floatAttacks.GetComponent<Text>().text = "+" + value.ToString();
    }
    public void AttackChange()
    {
        int n= perRoundHurt * angerCount * 3 / 10;
        if (n < 1) n = 0;       
        currentAttacks = initialAttacks + n+tempAttaks;
        attackText.text = currentAttacks.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
        CheckAttacks();
    }
    public void CheckAttacks()
    {
        AttackChange();
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
