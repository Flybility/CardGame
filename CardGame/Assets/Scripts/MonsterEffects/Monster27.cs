using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster27 : MonoBehaviour
{
    public ThisMonster monster;
    // Start is called before the first frame update
    void Start()
    {
        monster = GetComponent<ThisMonster>();
        monster.isRoundExchangeInterval = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
