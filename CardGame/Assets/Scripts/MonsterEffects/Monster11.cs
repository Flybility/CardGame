using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster11 : MonoBehaviour
{
    public ThisMonster monster;
    public int value;
    // Start is called before the first frame update
    //死亡时增加下次手牌抽取量
    void Start()
    {
        monster = GetComponent<ThisMonster>();
        value = 2;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnDestroy()
    {
        PlayerData.Instance.tempExtraCardMax += value;
    }

}
