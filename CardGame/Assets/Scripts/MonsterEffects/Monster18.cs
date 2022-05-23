using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster18 : MonoBehaviour
{
    public ThisMonster monster;
    public int attackAttachedScareCount;//攻击附加恐惧层数
    // Start is called before the first frame update
    void Start()
    {
        monster = GetComponent<ThisMonster>();
        monster.attackAttachedScare = attackAttachedScareCount;
        monster.isIntangible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
