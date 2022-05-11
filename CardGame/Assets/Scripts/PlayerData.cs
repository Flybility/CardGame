using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;


public class PlayerData : MonoSingleton<PlayerData>
{
    public CardDatabase cardData;
    public BattleField battleField;
    public TextMeshProUGUI attackText;
    public List<EquipmentCard> playerEquipmentCards = new List<EquipmentCard>();
    public List<MonsterCard> playerMonsterCards = new List<MonsterCard>();
    public int actionCost;//行动力
    public int maxHealth;
    public int currentHealth;
    public int maxSanValue;
    public int currentSanValue;//san值
    public int attacks;
    public int monsterCardMaxCount;//初始最大怪物手牌数
    public int perRoundExtractCount;//每回合抽牌数

    public UnityEvent healthChange = new UnityEvent();
    // Start is called before the first frame update
    void Start()
    {
        playerMonsterCards.Add(cardData.CopyMonsterCard(0));
        playerMonsterCards.Add(cardData.CopyMonsterCard(1));
        playerMonsterCards.Add(cardData.CopyMonsterCard(2));
        playerMonsterCards.Add(cardData.CopyMonsterCard(3));
        playerMonsterCards.Add(cardData.CopyMonsterCard(3));

        playerEquipmentCards.Add(cardData.CopyEquipmentCard(0));
        playerEquipmentCards.Add(cardData.CopyEquipmentCard(1));
        playerEquipmentCards.Add(cardData.CopyEquipmentCard(2));
        playerEquipmentCards.Add(cardData.CopyEquipmentCard(3));
        playerEquipmentCards.Add(cardData.CopyEquipmentCard(0));
        playerEquipmentCards.Add(cardData.CopyEquipmentCard(1));
        playerEquipmentCards.Add(cardData.CopyEquipmentCard(2));
        playerEquipmentCards.Add(cardData.CopyEquipmentCard(3));


        attackText.text = attacks.ToString();
        currentHealth = maxHealth;
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
        actionCost=6;//行动力
        currentHealth=maxHealth;
        currentSanValue=maxSanValue;//san值
        healthChange.Invoke();
    }
    public void HealthDecrease(int damage)
    {
        currentHealth -= damage;
        healthChange.Invoke();
    }
    public void AttackChange(int value)
    {
        attacks += value;
        attackText.text = attacks.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
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
