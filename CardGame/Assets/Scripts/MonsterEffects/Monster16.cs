using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster16 : MonoBehaviour
{
    public ThisMonster monster;
    // Start is called before the first frame update
    //死亡时增加下次攻击力
    void Start()
    {
        monster = GetComponent<ThisMonster>();
        monster.isAddScareCount = true;
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
