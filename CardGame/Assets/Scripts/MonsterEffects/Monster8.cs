using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster8:MonoBehaviour
{
    public ThisMonster monster;
    public int decreaseValue;
    public List<GameObject> intervalMonsters = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        monster = GetComponent<ThisMonster>();
        //Skills.Instance.AttackImprovedBesides(monster.block, decreaseValue);
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
