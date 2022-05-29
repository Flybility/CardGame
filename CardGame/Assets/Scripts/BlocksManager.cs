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
                if (transform.GetChild(i).GetChild(2).CompareTag("Monster"))
                {
                    monsters[i] = transform.GetChild(i).GetChild(2).gameObject;
                }
                else { monsters[i] = null; }
            }
            else
            {
                monsters[i] = null;
            }
        }
    }
    public GameObject GetNeighbourNext(Transform block)
    {
        int higherNumber = block.GetSiblingIndex() + 1;

        if (higherNumber > 5) higherNumber = 0;
        if (monsters[higherNumber] != null )
        {
            return monsters[higherNumber].gameObject;
        }
        else
        {
            return null;
        }

       
    }
    public GameObject GetIntervalNext(Transform block)
    {
        int higherNumber = block.GetSiblingIndex() + 2;

        if (higherNumber > 5) higherNumber -= 6;
        if (monsters[higherNumber] != null)
        {
            Debug.Log(monsters[higherNumber].gameObject);
            return monsters[higherNumber].gameObject;

        }
        else
        {
            return null;
        }


    }
    public GameObject GetNextBlock(Transform thisBlock)
    {
        int higherNumber = thisBlock.GetSiblingIndex() + 1;
        GameObject block =new GameObject();
        if (higherNumber > 5) higherNumber = 0;
        if (BattleField.Instance.blocks[higherNumber] != null)
        { block = BattleField.Instance.blocks[higherNumber]; }
        return block;

    }
    public List<GameObject> GetNeighbours(Transform thisBlock)
    {        
        List<GameObject> neighbours = new List<GameObject>();
        int lowerNumber = thisBlock.GetSiblingIndex() - 1;
        int higherNumber= thisBlock.GetSiblingIndex() + 1;

        if (lowerNumber < 0) lowerNumber = 5;
        if (higherNumber > 5) higherNumber = 0;
        if(monsters[lowerNumber]!=null)
        neighbours.Add(monsters[lowerNumber].gameObject);
        if(monsters[higherNumber]!=null)
        neighbours.Add(monsters[higherNumber].gameObject);

        for (int i = 0; i < neighbours.Count; i++)
        {
            if (neighbours[i].GetComponent<ThisMonster>().isAddAward)
            {
                //将带有增加isAddAward属性的monster放到链表尾部，使其最后结算
                neighbours.Add(neighbours[i]);
                neighbours.RemoveAt(i);
            }
        }
        return neighbours;
    }
    public GameObject GetNextIntervalBlock(Transform thisBlock)
    {
        GameObject interval = new GameObject();
        int higherNumber = thisBlock.GetSiblingIndex() + 2;
        if (higherNumber > 5) higherNumber -= 6;

        if (BattleField.Instance.blocks[higherNumber] != null)
        { interval = BattleField.Instance.blocks[higherNumber]; }
       
        return interval;
    }
    public List<GameObject> GetInterval(Transform thisBlock)
    {
        List<GameObject> interval = new List<GameObject>();
        int lowerNumber = thisBlock.GetSiblingIndex() - 2;
        int higherNumber = thisBlock.GetSiblingIndex() + 2;

        if (lowerNumber < 0) lowerNumber += 6;
        if (higherNumber > 5) higherNumber -= 6;
        //if (lowerNumber ==-1) lowerNumber = 5;
        //if (lowerNumber == -2) lowerNumber = 4;

        //if (higherNumber == 6) higherNumber = 0;
        //if (higherNumber == 7) higherNumber = 1;
        if (monsters[lowerNumber] != null)
            interval.Add(monsters[lowerNumber].gameObject);
        if (monsters[higherNumber] != null)
            interval.Add(monsters[higherNumber].gameObject);

        for (int i = 0; i < interval.Count; i++)
        {
            if (interval[i].GetComponent<ThisMonster>().isAddAward)
            {
                //将带有增加isAddAward属性的monster放到链表尾部，使其最后结算
                interval.Add(interval[i]);
                interval.RemoveAt(i);
            }
        }
        return interval;
    }
    public GameObject GetOpposite(Transform thisBlock)
    {
        GameObject opposite;
        int n = thisBlock.GetSiblingIndex() + 3;
        if (n > 5) { n-=6;}
        opposite = monsters[n].gameObject;
        return opposite;
    }

}
