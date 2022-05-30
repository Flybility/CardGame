using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster25 : MonoBehaviour
{
    public ThisMonster monster;
    public int armorValue;
    // Start is called before the first frame update
    void Start()
    {
        monster = GetComponent<ThisMonster>();
        monster.isSelfArmored = true;
        monster.selfArmoredValue = armorValue;
        Skills.Instance.ArmoredSelf(monster, armorValue);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
