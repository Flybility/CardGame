using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;


public class PlayerData : MonoSingleton<PlayerData>
{
    public CardDatabase cardData;
    public BattleField battleField;
    public GameObject floatPrefab;
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI healthText;
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
    public int attacks;//攻击力
    public int monsterCardMaxCount;//初始最大怪物手牌数
    public int perRoundExtractCount;//每回合抽牌数
    public int awardMonsterCardAmount;
    public int awardEquipCardAmount;


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


        attackText.text = attacks.ToString();

        BattleField.Instance.PlayerRoundEnd.AddListener(PerRoundChange);
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
        HealthBarChange();
    }
    public void PerRoundChange()
    {
        HealthDecrease(perRoundHealthDecrease);
        if (armorCount >0)          armorCount--;
        if (scareCount > 0)         scareCount--;
        if (counterattackCount > 0) counterattackCount--;
        if (burnsCount > 0)         burnsCount--;
        if (bondageCount > 0)       bondageCount--;
        return;
    }
    public void HealthDecrease(int damage)
    {
        currentHealth -= damage;
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
    }
    public void AttackChange(int value)
    {
        attacks += value;
        attackText.text = attacks.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        healthText.text = currentHealth + "/" + maxHealth;
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
