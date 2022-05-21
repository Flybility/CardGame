using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster12 : MonoBehaviour
{
    public ThisMonster monster;
    public int value;
    // Start is called before the first frame update
    //死亡时增加下次攻击力
    void Start()
    {
        monster = GetComponent<ThisMonster>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnDestroy()
    {
        PlayerData.Instance.StartAddTempAttacks(value);
    }
}
