using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster28 : MonoBehaviour
{
    public ThisMonster monster;
    // Start is called before the first frame update
    void Start()
    {
        monster = GetComponent<ThisMonster>();
        monster.isRoundSwallowBeside = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
