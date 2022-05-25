using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster19 : MonoBehaviour
{
    public ThisMonster monster;
    // Start is called before the first frame update
    //死亡时增加下次攻击力
    void Start()
    {
        monster = GetComponent<ThisMonster>();
        monster.isAddBurnsCount = true;//确定附加恐惧随怪物数增长
        monster.isAddAward = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
