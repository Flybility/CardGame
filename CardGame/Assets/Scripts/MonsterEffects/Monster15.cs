using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Monster15 : MonoBehaviour
{
    public ThisMonster monster;
    public int rounds;
    // Start is called before the first frame update
    void Start()
    {
        monster = GetComponent<ThisMonster>();
        AbsorbDamages();
        monster.isAbsorbBoom = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AbsorbDamages()
    {
        Skills.Instance.AddAbsorbCount(rounds, monster);
    }
}
