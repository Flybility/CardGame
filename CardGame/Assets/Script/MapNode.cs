using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapNode : MonoBehaviour
{
    public int value;
    public MapNode left;
    public MapNode right;
    public int level;
    public bool isUsed = false;

    public NodeType nodeType;
    public List<GameObject> nodeTypePrefabs;

    public enum NodeType
    {
        Fight,
        Wheezing,
        Comfort
    }

    private void Awake()
    {
        int typeID =  UnityEngine.Random.Range(0, 3);

        if(typeID == 0)
        {
            nodeType = NodeType.Fight;
        }
        else if(typeID == 1)
        {
            nodeType = NodeType.Wheezing;
        }
        else
        {
            nodeType = NodeType.Comfort;
        }

        //GetComponent<Image>().sprite = nodeTypePrefabs[typeID].GetComponent<Image>().sprite;
        //GetComponent<Button>().onClick = nodeTypePrefabs[typeID].GetComponent<Button>().onClick;

        GameObject.Instantiate(nodeTypePrefabs[typeID],transform);

    }

    public void ButtonComfort()
    {
        Debug.Log("enter comfort node");
    }

    public void ButtonFight()
    {
        Debug.Log("enter fight node");
    }
    public void ButtonWheezing()
    {
        Debug.Log("enter wheezing node");
    }

}
