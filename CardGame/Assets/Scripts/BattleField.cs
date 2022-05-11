using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public enum GameState
{
    游戏开始,玩家抽牌,玩家回合,敌方回合
}
public class BattleField : MonoSingleton<BattleField>
{    
    public GameObject eqiupmentCardPrefab;
    public GameObject monsterCardPrefab;
    public GameObject monstersPrefab;
    
    public GameObject PanelMask;      //遮罩图片，开关可以使得进行某些操作（洗牌与选择怪物）的时候鼠标不触发其他事件
    public Transform equipmentArea;   //装备牌区父物体
    public Transform discardArea;     //弃牌堆父物体
    public Transform extractArea;     //抽牌堆父物体
    public Transform monsterArea;     //怪物手牌堆父物体
    public float interval;            //抽取单张手牌动画时间间隔
    public int summonMax;             //最大召唤怪物数量（默认为6），可删除
    public int summonCounter;         //当前空余召唤位数
    public int chosenCardNumber;      //选取的怪物牌在手牌父物体中的子物体序号
    public int currentRound;          //当前回合数
    public GameObject _block;         //所有场上位格父物体
    public GameObject[] blocks;       //所有位格的数组集合
    public GameObject ArrowPrefab;    //箭头预制体
    public int SelectingMonster;      //是否在玩家回合选择召唤怪物卡牌的伪bool类型，由于使用bool出了bug，改为了int，0代表false，1代表true
    public GameObject usingEquipment; //是否在玩家回合选择装备卡牌的bool类型

    public GameState gameState;       //战斗回合状态  

    public CardDatabase cardData;     //卡牌库


    private GameObject waitingMonster;//召唤时选择的等待召唤的怪物牌
    private GameObject arrow;         //生成的箭头物体
    private GameObject player;        //左边的玩家角色（包含了playerdata脚本）

    List<MonsterCard> monsterDeck = new List<MonsterCard>();  //从playerData中的playerMonsterCards复制出来的怪物牌组
    [SerializeField]
    List<GameObject> cardsEquiptment = new List<GameObject>();//装备牌堆中所有装备的list集合
    [SerializeField]
    List<GameObject> monsterInBattle = new List<GameObject>();//存在于战场上的召唤兽的集合

    public UnityEvent stateChangeEvent = new UnityEvent();    //战斗状态切换事件，用于屏幕中央战斗状态文字的切换
    public UnityEvent highlightClear = new UnityEvent();      //战场位格高亮清除事件，用于解除战场上所有位格的高亮状态
    public UnityEvent summonEvent = new UnityEvent();         //召唤完成事件，用于解除场上每个怪物卡牌禁止召唤状态
    public UnityEvent BattleEnd = new UnityEvent();           //战斗结束事件，用于Blocks脚本清除怪兽子物体
    public UnityEvent ChangeParent = new UnityEvent();        //卡牌父物体改变事件，用于检测卡牌父物体是哪个牌堆
    // Start is called before the first frame update

    void Start()
    {
        //PlayerData设置为单例，其所在物体同时也是主角角色物体
        player = PlayerData.Instance.gameObject;    
        //提前为blocks数组申请空间为战场上格子数量的数组空间
        int n = _block.transform.childCount;
        blocks = new GameObject[n];
        for (int i=0; i < n; i++)
        {
            blocks[i] = _block.transform.GetChild(i).gameObject;
        }
    }
    //战斗开始，由面板上战斗开始按钮调用
    public void BattleStart()
    {
        gameState = GameState.游戏开始;
        stateChangeEvent.Invoke();
        currentRound = 1;
        PanelMask.SetActive(false);
        summonCounter = summonMax;
        //读取玩家卡组
        ReadDeck();
        //洗牌打乱顺序
        Debug.Log("洗牌");
        ShuffleMonsterDeck();
        //生成怪物牌堆
        DrawMonsterDeck();
        //生成装备
        StartCoroutine(DrawEquipmentDeck());
        //生成手牌
        DrawHandMonster();
        //切换回合状态
        gameState = GameState.玩家回合;
        stateChangeEvent.Invoke();
        //剩余格子数量等于最大格子数量
        summonCounter = summonMax;
        //玩家数据脚本每回合恢复变量
        PlayerData.Instance.PerBattleRecover();

    }
    //战斗结束时调用，目前由面板上战斗结束按钮调用
    public void OnBattleEnd()
    {
        BattleEnd.Invoke();
        //清空场上所有牌堆
       for(int i = 0; i < monsterArea.childCount; i++)
        {
            Destroy(monsterArea.GetChild(i).gameObject);
        }
        for (int i = 0; i < discardArea.childCount; i++)
        {
            Destroy(discardArea.GetChild(i).gameObject);
        }
        for (int i = 0; i < extractArea.childCount; i++)
        {
            Destroy(extractArea.GetChild(i).gameObject);
        }
        for (int i = 0; i < equipmentArea.childCount; i++)
        {
            Destroy(equipmentArea.GetChild(i).gameObject);
        }
        cardsEquiptment.Clear();
        monsterDeck.Clear();
        waitingMonster = null;
        usingEquipment = null;
        SelectingMonster=0;
        summonCounter = summonMax;
        PanelMask.SetActive(false);
    }
    private void Update()
    {
        if (SelectingMonster == 1 && Input.GetMouseButtonUp(1))
        {
            DestroyArrow();
            CloseHighlightWithinMonster();
            SelectingMonster = 0;
        }
        if(usingEquipment!=null&& Input.GetMouseButtonUp(1))
        {
            DestroyArrow();
            CloseHighlightWithinMonster();
            usingEquipment = null;
        }
    }
    //游戏开始
   
    //切换回合
    public void TurnEnd()
    {
        if (gameState == GameState.玩家回合)
        {
            CreateArrow(player.transform, ArrowPrefab);
            OpenHighlightWithinMonster();
        }
    }
    //玩家抽牌
    public void PlayerExtractCard()
    {

        if (gameState == GameState.玩家抽牌)
        {
            PanelMask.SetActive(true);
            FlyToDiscardArea();

            DrawHandMonster();
        }

    }
    //将monsterDeck里的玩家牌添加入抽牌堆
    public void DrawMonsterDeck()
    {
        Debug.Log("怪物牌进入抽牌堆");
        for (int i = 0; i < monsterDeck.Count; i++)
        {
            //Debug.Log(monsterDeck.Count);
            GameObject newCard = GameObject.Instantiate(monsterCardPrefab, extractArea);
            newCard.GetComponent<ThisMonsterCard>().card = monsterDeck[i];                
        }
        
    }
    //判断抽牌堆卡牌数量，若少则从弃牌堆洗牌进入抽牌堆，若足则从抽牌堆抽取卡牌
    public void DrawHandMonster()
    {
        PanelMask.SetActive(true);
        if (extractArea.childCount >= PlayerData.Instance.monsterCardMaxCount)
        {
            StartFlyToHand();
        }
        else
        {
            FlyToExtractArea();
            //多个协程一同开启时不会先执行完上一个再执行下一个，而是同时进行，故做延时处理
            //Invoke("StartFlyToHand", (discardArea.childCount+1)* interval);
            StartFlyToHand();
        }

    }
    //开启FlyToHand协程
    public void StartFlyToHand()
    {
        StartCoroutine(FlyToHand(PlayerData.Instance.monsterCardMaxCount));
    }
    //玩家开始攻击
    public void StartPlayerAttack(GameObject monster)
    {
        Debug.Log("攻击怪物");
        DestroyArrow();
        CloseHighlightWithinMonster();
        StartCoroutine(PlayerAttack(monster));
        SelectingMonster = 0;
    }
    //抽牌堆牌进入手牌协程（包含动效）
    IEnumerator FlyToHand(int count)
    {
        
        List<GameObject> extracted = new List<GameObject>();
        //抽牌堆里抽取最上方count张牌存入extracted
        if (count<= extractArea.childCount)
        {
            for (int i = 0; i < count; i++)
            {
                extracted.Add(extractArea.GetChild(i).gameObject);
                Debug.Log(extracted.Count);
            }
        }
        else
        {
            for(int i = 0; i < extractArea.childCount;i++)
            {
                extracted.Add(extractArea.GetChild(i).gameObject);
                Debug.Log(extracted.Count);
            }
        }
        
        //每张extracted放入手牌堆里
        foreach(var card in extracted)
        {
            //卡牌飞向
            //extractArea.GetChild(i).DOMove(monsterArea.position, 0.5f);
            card.SetActive(true);
            card.transform.SetParent(monsterArea);
            ChangeParent.Invoke();
            card.transform.DOPunchScale(new Vector3(0.2f,0.2f,0.2f), interval);
            Debug.Log("飞入手牌");
            yield return new WaitForSeconds(interval);
        }
        
        PanelMask.SetActive(false);
        //手牌结束抽牌后改变为玩家回合开始
        gameState = GameState.玩家回合;
        stateChangeEvent.Invoke();
        yield break;
    }
    //弃牌堆牌进入抽牌堆
    public void FlyToExtractArea()
    {
        List<GameObject> discard = new List<GameObject>();
        //弃牌堆里所有牌存入discard
        for (int i = 0; i < discardArea.childCount; i++)
        {
            discard.Add(discardArea.GetChild(i).gameObject);
        }
        //洗牌函数
        for (int i = 0; i < discard.Count; i++)
        {
            
            int randomIndex = Random.Range(0, discard.Count);
            GameObject temp = discard[i];
            discard[i] = discard[randomIndex];
            discard[randomIndex] = temp;
            
        }
        //每张discard放入抽牌堆里
        foreach (var card in discard)
        {
            Debug.Log("回到抽牌堆");
            card.transform.SetParent(extractArea);
            ChangeParent.Invoke();            
        }

    }
    //手牌回合结束剩余进入弃牌堆
    public void FlyToDiscardArea()
    {
        List<GameObject> hand = new List<GameObject>();
        //手牌堆里所有牌存入hand
        for (int i = 0; i < monsterArea.childCount; i++)
        {
            hand.Add(monsterArea.GetChild(i).gameObject);
            Debug.Log(hand.Count);
        }
        //每张hand放入弃牌堆里
        foreach (var card in hand)
        {
            Debug.Log("丢弃剩余手牌");
            
            //monsterArea.GetChild(i).DOLocalMove(discardArea.position, 0.5f);            
            card.transform.SetParent(discardArea);
            ChangeParent.Invoke();
            //card.transform.DOPunchScale(-new Vector3(0.2f, 0.2f, 0.2f), interval);
            //yield return new WaitForSeconds(interval);

        }
        
        //for (int i = 0; i < discardArea.childCount; i++)
        //{
        //    cardsInHand.RemoveAt(i);
        //    cardsDiscard.Add(discardArea.GetChild(i).gameObject);
        //}
    }
    //怪物攻击协程（包含动效）
    IEnumerator MonsterAttack(GameObject target)
    {
        foreach(var monster in monsterInBattle)
        {
            Vector3 targetPos = target.transform.localPosition;
            Vector3 monsterPos = monster.transform.parent.localPosition;
            monster.transform.DOPunchPosition(targetPos - monsterPos, 0.4f,1);
            yield return new WaitForSeconds(0.2f);
            PlayerData.Instance.HealthDecrease(monster.GetComponent<ThisMonster>().damage);
            //Skills.Instance.Attack(monster.GetComponent<ThisMonster>().damage, player);
            yield return new WaitForSeconds(0.2f);
        }
        gameState = GameState.玩家抽牌;
        stateChangeEvent.Invoke();
        yield return new WaitForSeconds(0.5f);
        PlayerExtractCard();
        currentRound++;
        yield break;
    }
    //玩家攻击协程（包含动效）
     IEnumerator PlayerAttack(GameObject monster)
    {
        Vector3 monsterPos = monster.transform.parent.localPosition;
        Vector3 playerPos = player.transform.localPosition;
        player.transform.DOPunchPosition(monsterPos- playerPos, 0.6f, 1);
        yield return new WaitForSeconds(0.3f);
        monster.GetComponent<ThisMonster>().HealthDecrease(PlayerData.Instance.attacks);
        yield return new WaitForSeconds(0.5f);
        Debug.Log("敌人回合");
        gameState = GameState.敌方回合;
        stateChangeEvent.Invoke();
        StartCoroutine(MonsterAttack(player));
    }
    //将装备牌显示到装备牌堆（包含动效）
    IEnumerator DrawEquipmentDeck()
    {
        foreach (var card in cardsEquiptment)
        {
            Destroy(card);
        }
        cardsEquiptment.Clear();
        for (int i = 0; i < PlayerData.Instance.playerEquipmentCards.Count; i++)
        {
            GameObject newCard = GameObject.Instantiate(eqiupmentCardPrefab, equipmentArea);
            cardsEquiptment.Add(newCard);
            newCard.GetComponent<ThisEquiptmentCard>().card = PlayerData.Instance.playerEquipmentCards[i];
            newCard.transform.DOPunchScale(new Vector3(0.3f, 0.3f, 0.3f), interval);
            yield return new WaitForSeconds(interval);
        }
        ChangeParent.Invoke();
    }
    //战斗时动态加入装备牌
    public void AddEquipmentCard(EquipmentCard card)
    {
        GameObject newCard = GameObject.Instantiate(eqiupmentCardPrefab, equipmentArea);
        cardsEquiptment.Add(newCard);
        newCard.GetComponent<ThisEquiptmentCard>().card = card;
        newCard.transform.DOPunchScale(new Vector3(0.3f, 0.3f, 0.3f), interval);
        ChangeParent.Invoke();
    }
    //从玩家数据中读取玩家目前具有的卡组并从卡牌库里复制一份给战场上的monsterDeck
    public void ReadDeck()
    {
        monsterDeck.Clear();
        //将读取的每一关的卡组给到当前战场上的抽牌堆monsterdeck
        for(int i = 0; i < ReadEachLevelMonsters.Instance.monsterCardList.Count; i++)
        {
            monsterDeck.Add(ReadEachLevelMonsters.Instance.monsterCardList[i]);
        }

    }
    //对monsterDeck进行洗牌
    public void ShuffleMonsterDeck()
    {
        Debug.Log("怪物牌洗牌");
        List<MonsterCard> shuffleDeck = new List<MonsterCard>();
        shuffleDeck = monsterDeck;
        for (int i = 0; i < shuffleDeck.Count; i++)
        {
            int randomIndex = Random.Range(0, shuffleDeck.Count);
            MonsterCard temp = shuffleDeck[i];
            shuffleDeck[i] = shuffleDeck[randomIndex];
            shuffleDeck[randomIndex] = temp;
        }
    }
    //召唤请求发起（由其他脚本调用）
   public void SummonRequest(GameObject _monsterCard)
    {
        bool hasEmptyBlock = false;
        if (PlayerData.Instance.actionCost>= _monsterCard.GetComponent<ThisMonsterCard>().cost)
        {
            chosenCardNumber = _monsterCard.transform.GetSiblingIndex();
            foreach (var block in blocks)
            {
                if (block.transform.childCount==1)
                {
                    //等待召唤显示高亮图片
                    block.GetComponent<Blocks>().highLightImage.SetActive(true);
                    hasEmptyBlock = true;
                }
            }
        }
        else
        {
            Debug.LogError("行动力不足");
        }
        if (hasEmptyBlock)
        {
            waitingMonster = _monsterCard;
        }
        CreateArrow(_monsterCard.transform, ArrowPrefab);
    }
    //召唤请求确认
    public void SummonConfirm(Transform _block)
    {
        highlightClear.Invoke();
        if (waitingMonster != null)
        {
            Summon(waitingMonster, _block);
        }

    }
    //中途取消召唤（鼠标右键)
    public void SummonCancel()
    {
        highlightClear.Invoke();
        waitingMonster = null;
        DestroyArrow();
        PanelMask.SetActive(false);
    }
    //召唤开始
    public void Summon(GameObject _monster,Transform _block)
    {  
        DestroyArrow();
        int monsterId = _monster.GetComponent<ThisMonsterCard>().id;
        int monsterCost = _monster.GetComponent<ThisMonsterCard>().cost;

        
        //此怪物对应的卡牌赋予给生成的怪物所在的block中的卡牌
        _block.GetComponent<Blocks>().card = _monster; ;
        _monster.transform.SetParent(_block);
        _monster.SetActive(false);

        //依据怪物编号找出monsterPrefab里对应的怪物并生成于_block处
        GameObject monster=Instantiate(monstersPrefab.transform.GetChild(monsterId), _block).gameObject;
        monsterInBattle.Add(monster);

        PlayerData.Instance.actionCost -= monsterCost;

        waitingMonster = null;
        summonCounter--;
        summonEvent.Invoke();
    }
    //使用装备请求，传入使用的装备（其他脚本调用）
    public void UseEquipmentRequest(GameObject equipment)
    {
        if (equipment.GetComponent<ThisEquiptmentCard>())
        {
            EquipmentCard card = equipment.GetComponent<ThisEquiptmentCard>().card;
            if (card.summonTimes > 0)
            {
                CreateArrow(equipment.transform, ArrowPrefab);
                usingEquipment = equipment;
                
                OpenHighlightWithinMonster();
            }
        }        
    }
    //对怪物使用装备，（之后可以考虑使用协程加入一些发射投掷物的动画）
    public void UseEquipment(GameObject monster)
    {
        DestroyArrow();
        CloseHighlightWithinMonster();
        EquipmentCard card = usingEquipment.GetComponent<ThisEquiptmentCard>().card;        
        int damage = card.damage;
        monster.GetComponent<ThisMonster>().HealthDecrease(damage);
        //其他装备效果


        //usingEquipment = null;
        card.summonTimes--;
    }
    //使存在怪物的格子开启高光
    public void OpenHighlightWithinMonster()
    {
        PanelMask.SetActive(true);
        foreach (var monster in monsterInBattle)
        {
            monster.transform.parent.GetChild(0).gameObject.SetActive(true);
        }
    }
    //使存在怪物的格子关闭高光
    public void CloseHighlightWithinMonster()
    {
        PanelMask.SetActive(false);
        foreach (var monster in monsterInBattle)
        {
            monster.transform.parent.GetChild(0).gameObject.SetActive(false);
        }
    }
    //生成箭头
    public void CreateArrow(Transform startPoint,GameObject prefab)
    {
        DestroyArrow();
        SelectingMonster = 1;
        arrow = Instantiate(prefab, startPoint.position,Quaternion.identity,this.transform.parent);
        arrow.GetComponent<BezierArrow>().SetStartPoint(new Vector2(startPoint.position.x, startPoint.position.y));
    }
    //摧毁箭头
    public void DestroyArrow()
    {
        Destroy(arrow);
        SelectingMonster = 0;
    }
    //怪物死亡
    public void MonsterDead(GameObject monster,GameObject monsterCard)
    {
        monsterInBattle.Remove(monster);
        monsterCard.transform.SetParent(discardArea);
        summonCounter++;
    }

}