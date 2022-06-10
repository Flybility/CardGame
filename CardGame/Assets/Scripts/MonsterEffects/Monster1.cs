using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster1 :MonoBehaviour
{
    public ThisMonster monster;
    public int boomDamage;
    // Start is called before the first frame update
    void Start()//怪物上场时调用技能函数
    {
        monster = GetComponent<ThisMonster>();
        monster.isBoom = true;
        GameObject boomCounter=Instantiate(Skills.Instance.boomCounter, monster.stateBlock);
        boomCounter.transform.GetChild(0).GetComponent<Text>().text = boomDamage.ToString();
       // Skills.Instance.AttackPlayer(1);
    }

    // Update is called once per frame
    void Update()
    {        

    }
    public void OnDestroy()//击杀怪物时调用技能函数
    {
        if (BattleField.Instance.isFinished==false) Skills.Instance.StartBoom(monster, boomDamage);
    }
    
}
