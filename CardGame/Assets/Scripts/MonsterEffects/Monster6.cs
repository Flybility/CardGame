using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster6 :MonoBehaviour
{
    public ThisMonster monster;
    public int boomDamage;
    // Start is called before the first frame update
    void Start()//怪物上场时调用技能函数
    {
        monster = GetComponent<ThisMonster>();
        boomDamage = 50;
        // Skills.Instance.AttackPlayer(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        if(BattleField.Instance.isFinished == false) Skills.Instance.StartBoomAll(boomDamage);
    }
}
