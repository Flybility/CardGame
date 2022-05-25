using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster21 : MonoBehaviour
{
    public ThisMonster monster;
    public int attackAttachedBondage;
    // Start is called before the first frame update
    //死亡时增加下次攻击力
    void Start()
    {
        monster = GetComponent<ThisMonster>();
        monster.attackAttachedBondages = attackAttachedBondage;
        monster.isAddAward = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
