using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster10:MonoBehaviour
{
    public ThisMonster monster;
    public int value;
    // Start is called before the first frame update
    //加入时增加邻位怪兽获取的情绪量
    void Start()
    {
        monster = GetComponent<ThisMonster>();
        //Skills.Instance.AwardImprovedBesides(monster.block, value);
    }

    // Update is called once per frame
    void Update()
    {
       // Detected();
        

    }
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
