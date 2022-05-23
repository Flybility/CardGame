using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster17 : MonoBehaviour
{
    public ThisMonster monster;
    public int attackAttachedScareCount;//攻击附加恐惧层数
    // Start is called before the first frame update
    //死亡时增加下次攻击力
    void Start()
    {
        monster = GetComponent<ThisMonster>();
        monster.attackAttachedScare = attackAttachedScareCount;
        AddAwards();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddAwards()
    {
        monster.isAddAward = true;
    }
}
