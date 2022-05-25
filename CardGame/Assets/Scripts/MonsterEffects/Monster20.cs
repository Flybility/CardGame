using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster20 : MonoBehaviour
{
    public ThisMonster monster;
    public int attackAttachedBurns;
    // Start is called before the first frame update
    //死亡时增加下次攻击力
    void Start()
    {
        monster = GetComponent<ThisMonster>();
        monster.attackAttachedBurns = attackAttachedBurns;
        monster.isAddAward = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
