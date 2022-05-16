using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoSingleton<Skills>
{
    // Start is called before the first frame update
   public void AttackPlayer(int damage)
    {
        PlayerData.Instance.HealthDecrease(damage);
    }
    public void AttackMonster(int damage, GameObject target)
    {
        target.GetComponent<ThisMonster>().HealthDecrease(damage);
    }
    
}
