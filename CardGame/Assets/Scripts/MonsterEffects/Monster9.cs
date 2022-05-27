using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster9:MonoBehaviour
{
    public ThisMonster monster;
    public float multipleRate;
    // Start is called before the first frame update
    //加入时增加邻位怪兽获取的情绪量
    void Start()
    {
        monster = GetComponent<ThisMonster>();
        monster.isNeighbourAwardMultiple = true;
        Skills.Instance.AddAttackCount(monster);
        
       // foreach (var monster in BlocksManager.Instance.GetNeighbours(monster.block))
       // {
       //     monster.GetComponent<ThisMonster>().multipleAwards = multipleRate;
       // }
    }

    // Update is called once per frame
    void Update()
    {
        // Detected();
        //Skills.Instance.AwardImprovedBesides(monster.block, multipleRate);

    }
   //private void OnDestroy()
   //{
   //   if (BattleField.Instance.isFinished == false)
   //   {
   //       Skills.Instance.AwardImprovedBesides(monster.block, 1);
   //       //foreach (var monster in BlocksManager.Instance.GetNeighbours(monster.block))
   //       //{
   //       //    monster.GetComponent<ThisMonster>().multipleAwards = 1;
   //       //}
   //   }
           
   //}
}
