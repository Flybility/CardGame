using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster8:MonoBehaviour
{
    public ThisMonster monster;
    public Blocks block;
    public float multipleRate;
    // Start is called before the first frame update
    void Start()
    {
        monster = GetComponent<ThisMonster>();
        block = monster.block.GetComponent<Blocks>();
        monster.isIntervalAttackMultiple = true;
        Skills.Instance.AddAttackCount(monster);
        
        //foreach(var monster in BlocksManager.Instance.GetInterval(monster.block))
        //{
        //    monster.GetComponent<ThisMonster>().multipleAttacks = multipleRate;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        // Detected();
        //Skills.Instance.AttackImprovedInterval(monster.block, multipleRate);

    }
    
    //private void OnDestroy()
    //{
    //    if (BattleField.Instance.isFinished == false)
    //    {
    //        Skills.Instance.AttackImprovedInterval(monster.block, 1);
    //       // foreach (var monster in BlocksManager.Instance.GetInterval(monster.block))
    //       // {
    //       //     monster.GetComponent<ThisMonster>().multipleAttacks = 1;
    //       // }
    //    }
    //}
    //private void Detected()
    //{
    //    bool n = false;
    //    intervalMonsters = BlocksManager.Instance.GetInterval(monster.block);        
    //    int a= intervalMonsters[1].GetComponent<ThisMonster>().damage - decreaseValue;
    //
    //    foreach (var monster in intervalMonsters)
    //    {
    //        monster.GetComponent<ThisMonster>().damage = intervalMonsters[i].GetComponent<ThisMonster>().damage - decreaseValue;
    //    }   
    //}
    //private void OnDestroy()
    //{
    //    //Skills.Instance.AttackImprovedBesides(monster.block, -decreaseValue);
    //}
}
