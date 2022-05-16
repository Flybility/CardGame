using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster1 :MonoBehaviour
{
    public ThisMonster monster;
    public int boomDamage;
    // Start is called before the first frame update
    void Start()//怪物上场时调用技能函数
    {
        monster = GetComponent<ThisMonster>();
        boomDamage = 5;
        BattleField.Instance.MonsterDeadEvent.AddListener(OnDead);
       // Skills.Instance.AttackPlayer(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDead()
    {
        foreach (var monster in BlocksManager.Instance.GetNeighbours(monster.block))
        {
            Debug.Log("爆炸");
            Skills.Instance.AttackMonster(boomDamage, monster);
        }
    } 
}
