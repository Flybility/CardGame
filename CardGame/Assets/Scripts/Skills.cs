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
    public void StartBoom(Transform block, int damage)
    {
        StartCoroutine(BoomBeside(block, damage));
    }
    IEnumerator BoomBeside(Transform block, int damage)
    {
        yield return new WaitForSeconds(0.1f);
        BlocksManager.Instance.backMonsters.Clear();
        if (BattleField.Instance.isFinished == false)
        {
            BlocksManager.Instance.GetNeighbours(block);
            yield return new WaitForSeconds(0.3f);
            //播放爆炸动画

            for (int i = 0; i < BlocksManager.Instance.backMonsters.Count; i++)
            {
                //BlocksManager.Instance.backMonsters[i].GetComponent<ThisMonster>().HealthDecrease(damage);

                AttackMonster(damage, BlocksManager.Instance.backMonsters[i]);
            }
        }
    }
    public void StartBoomAll(int damage)
    {
        StartCoroutine(BoomAll(damage));
    }
    IEnumerator BoomAll(int damage)
    {
        yield return new WaitForSeconds(0.2f);
        if (BattleField.Instance.isFinished == false)
        {
            List<GameObject> monsters = new List<GameObject>();
            foreach (var monster in BlocksManager.Instance.monsters)
            {
                if (monster != null) monsters.Add(monster);
            }
            Debug.Log("Boom");
            yield return new WaitForSeconds(0.3f);
            for (int i = 0; i < monsters.Count; i++)
            {
                AttackMonster(damage, monsters[i]);
            }
        }
        
    }
}
