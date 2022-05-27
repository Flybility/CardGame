using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster22 : MonoBehaviour
{
    public ThisMonster monster;
    public Blocks block;
    public float multipleRate;
    // Start is called before the first frame update
    void Start()
    {
        monster = GetComponent<ThisMonster>();
        block = monster.block.GetComponent<Blocks>();
        monster.isNeiboursAttackMultiple = true;
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
        //Skills.Instance.AttackImprovedBesides(monster.block, multipleRate);

    }

    //private void OnDestroy()
    //{
    //    if (BattleField.Instance.isFinished == false)
    //    {
    //        Skills.Instance.AttackImprovedBesides(monster.block, 1);
    //        // foreach (var monster in BlocksManager.Instance.GetInterval(monster.block))
    //        // {
    //        //     monster.GetComponent<ThisMonster>().multipleAttacks = 1;
    //        // }
    //    }
    //}
}
