using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksManager : MonoSingleton<BlocksManager>
{
    public GameObject[] monsters;
    public List<GameObject> backMonsters = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        monsters = new GameObject[6];
        BattleField.Instance.monsterChange.AddListener(MonsterChange);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MonsterChange()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).childCount > 2)
            {
                monsters[i] = transform.GetChild(i).GetChild(2).gameObject;
            }
            else
            {
                monsters[i] = null;
            }
        }
    }
    public void GetNeighbours(Transform thisBlock)
    {        
        //List<GameObject> neighbours = new List<GameObject>();
        int lowerNumber = thisBlock.GetSiblingIndex() - 1;
        int higherNumber= thisBlock.GetSiblingIndex() + 1;

        if (lowerNumber < 0) lowerNumber = 5;
        if (higherNumber > 5) higherNumber = 0;
        if(monsters[lowerNumber]!=null)
        backMonsters.Add(monsters[lowerNumber].gameObject);
        if(monsters[higherNumber]!=null)
        backMonsters.Add(monsters[higherNumber].gameObject);
        //return neighbours;
    }

}
