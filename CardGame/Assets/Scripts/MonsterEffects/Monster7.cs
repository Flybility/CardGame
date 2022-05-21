using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster7 : MonoBehaviour
{
    public ThisMonster monster;
    public int dizzyDamage;
    public int terrorValue;
    // Start is called before the first frame update
    void Start()//怪物上场时调用技能函数
    {
        monster = GetComponent<ThisMonster>();
    }
        // Update is called once per frame
     void Update()
    {
        
    }
    private void OnDestroy()
    {
        if (BattleField.Instance.isFinished == false) Skills.Instance.AddDizzyToBesides(monster.block, dizzyDamage);
    }
}
