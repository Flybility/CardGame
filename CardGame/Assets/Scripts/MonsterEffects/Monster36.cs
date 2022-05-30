using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Monster36 : MonoBehaviour
{
    public ThisMonster monster;
    public int burnsCount;
    // Start is called before the first frame update
    void Start()//怪物上场时调用技能函数
    {
        monster = GetComponent<ThisMonster>();
        // GameObject boomCounter = Instantiate(Skills.Instance.boomCounter, monster.stateBlock);
        // boomCounter.transform.GetChild(0).GetComponent<Text>().text = boomDamage.ToString();
        // Skills.Instance.AttackPlayer(1);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnDestroy()//击杀怪物时调用技能函数
    {
        if (BattleField.Instance.isFinished == false) Skills.Instance.AddBurnsToBesides(monster.block, burnsCount);
    }
}
