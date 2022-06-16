using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoSingleton<GameManager>
{
    public GameObject canvas;
    public GameObject nodePanel;
    public GameObject gameStart;
    public GameObject openEquipmentCard;
    public GameObject openMonsterCard;
    public GameObject battleFieldPanel;
    public GameObject wheezingPanel;
    public int level;  //目前关卡数
    public int recover;//
    // Start is called before the first frame update
    void Start()
    {
        level = 1;
        //isStart = false;
        openEquipmentCard.SetActive(false);
        openMonsterCard.SetActive(false);
        battleFieldPanel.SetActive(false);
        wheezingPanel.SetActive(false);
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
        nodePanel.SetActive(true);
    }
    public void ChoseCard()
    {
        //openEquipmentCard.SetActive(true);
        openMonsterCard.SetActive(true);
        OpenPackage.Instance.OpenMonsterCard(PlayerData.Instance.awardMonsterCardAmount);
    }
    public void StartBattle()
    {
        battleFieldPanel.SetActive(true);
        nodePanel.SetActive(false);
        //延迟0.2秒开始战斗，期间可以加入一些角色独白
        AudioManager.Instance.startMusic.Stop();
        AudioManager.Instance.battleMusic.Play();
        Invoke("BattleStart", 0.2f);
    }
    public void BattleEnd()
    {
        if (BattleField.Instance.isFinished == false)
        {
            BattleField.Instance.OnBattleEnd();
            AudioManager.Instance.battleMusic.Stop();
            battleFieldPanel.SetActive(false);
        }
        

    }
    public void QuitGame()
    {
        Application.Quit();
    }
    private  void BattleStart()
    {
        battleFieldPanel.GetComponent<BattleField>().BattleStart();
    }
    public void Wheezing()
    {
        wheezingPanel.SetActive(true);
        nodePanel.SetActive(false);
    }
}
