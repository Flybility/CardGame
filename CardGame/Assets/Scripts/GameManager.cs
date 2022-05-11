using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoSingleton<GameManager>
{
    public GameObject canvas;
    public GameObject gameStart;
    public GameObject openEquipmentCard;
    public GameObject openMonsterCard;
    public GameObject battleFieldPanel;
    public int level;//目前关卡数
    // Start is called before the first frame update
    void Start()
    {
        level = 1;
        //isStart = false;
        openEquipmentCard.SetActive(false);
        openMonsterCard.SetActive(false);
        battleFieldPanel.SetActive(false);
        gameStart.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameStart()
    {
        //isStart = true;
        gameStart.SetActive(false);
    }
    public void OpenPackage()
    {
        openEquipmentCard.SetActive(true);
        openMonsterCard.SetActive(true);
    }
    public void StartBattle()
    {
        battleFieldPanel.SetActive(true);
        //延迟0.2秒开始战斗，期间可以加入一些角色独白

        Invoke("BattleStart", 0.2f);
    }
    public void BattleEnd()
    {
        BattleField.Instance.OnBattleEnd();
        battleFieldPanel.SetActive(false);
    }
    private  void BattleStart()
    {
        battleFieldPanel.GetComponent<BattleField>().BattleStart();
    }
}
