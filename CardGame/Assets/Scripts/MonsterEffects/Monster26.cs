using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster26 : MonoBehaviour
{
    public ThisMonster monster;
    public int armorValue;
    // Start is called before the first frame update
    void Start()
    {
        monster = GetComponent<ThisMonster>();
        monster.isSelfArmored = true;
        monster.isRoundExchange = true;
        monster.selfArmoredValue = armorValue;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
