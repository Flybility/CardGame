using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoSingleton<Skills>
{
    public GameObject boomEffect;
    public GameObject dizzyEffect;
    public GameObject burnsEffect;
    public GameObject dizzyCounter;
    public GameObject burnsCounter;
    public GameObject attackTimesCounter;
    public GameObject counterattackCounter;

    // Start is called before the first frame update
    public void AttackPlayer(int damage)
    {
        PlayerData.Instance.HealthDecrease(damage);
    }
    public void AttackMonster(int damage, GameObject target)
    {
        target.GetComponent<ThisMonster>().HealthDecrease(damage);
    }
    public void RecoverHealth(int value)
    {
        PlayerData.Instance.HealthRecover(value);
    }
    public void StartBoom(Transform block, int damage)
    {
        StartCoroutine(BoomBeside(block, damage));
    }
    IEnumerator BoomBeside(Transform block, int damage)
    {       
        if (BattleField.Instance.isFinished == false)
        {
            yield return new WaitForSeconds(0.3f);
            //播放爆炸动画
            foreach(var monster in BlocksManager.Instance.GetNeighbours(block))
            {
                AttackMonster(damage, monster);
            }
            //for (int i = 0; i < BlocksManager.Instance.backMonsters.Count; i++)
            //{
            //    //BlocksManager.Instance.backMonsters[i].GetComponent<ThisMonster>().HealthDecrease(damage);
            //
            //    AttackMonster(damage, BlocksManager.Instance.backMonsters[i]);
            //}
        }
    }
    public void StartBoomAll(int damage)
    {
        StartCoroutine(BoomAll(damage));
    }
    IEnumerator BoomAll(int damage)
    {
        if (BattleField.Instance.isFinished == false)
        {
            yield return new WaitForSeconds(0.2f);
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
    public void AddDizzyToBesides(Transform block, int count)
    {       
        foreach(var monster in BlocksManager.Instance.GetNeighbours(block))
        {
            monster.GetComponent<ThisMonster>().AddDizzy(count, dizzyCounter);
        }

    }
    public void AddAttackTimesCount(int times)
    {
        //层数1层双次攻击，持续一回合
        PlayerData.Instance.AddAttackTimeCount(times, attackTimesCounter);
    }
    //属性被动装备
    public void StaticCounterattackCount(int times,int threshold)
    {
        PlayerData.Instance.AddCounterattackCount(times, counterattackCounter);
        PlayerData.Instance.CounterattackEffect(threshold);
    }
    public void AttackImprovedBesides(Transform block,int count)
    {
        foreach (var monster in BlocksManager.Instance.GetNeighbours(block))
        {
            monster.GetComponent<ThisMonster>().damage -= count;
        }
    }
    public void AwardImprovedBesides(Transform block,int count)
    {
        foreach (var monster in BlocksManager.Instance.GetNeighbours(block))
        {
            monster.GetComponent<ThisMonster>().awardHealth += count;
        }
    }
   

}
