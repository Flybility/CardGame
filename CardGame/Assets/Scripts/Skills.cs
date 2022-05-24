using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Skills : MonoSingleton<Skills>
{
    public GameObject boomEffect;
    public GameObject dizzyEffect;
    public GameObject burnsEffect;
    public GameObject dizzyCounter;
    public GameObject burnsCounter;
    public GameObject attackTimesCounter;
    public GameObject counterattackCounter;
    public GameObject scareCounter;
    public GameObject absorbCounter;
    public GameObject attackCounter;//攻击随回合增长计数器

    // Start is called before the first frame update
    public void AttackPlayer(int damage,ThisMonster monster)
    {
        PlayerData.Instance.HealthDecrease(damage);
        if (monster.isAddScareCount)
        {
            PlayerData.Instance.AddScareCount(BattleField.Instance.monsterInBattle.Count, scareCounter);
        }
        else { PlayerData.Instance.AddScareCount(monster.attackAttachedScare, scareCounter); }

    }
    public void AttackMonster(int damage, GameObject target,bool isStraight)
    {
        target.GetComponent<ThisMonster>().HealthDecrease(damage,isStraight);
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
            AudioManager.Instance.boom1.Play();
            List<GameObject> monsters = BlocksManager.Instance.GetNeighbours(block);
                //播放爆炸动画
            foreach (var monster in BlocksManager.Instance.GetNeighbours(block))
            {
                yield return new WaitForSeconds(0.06f);
                AttackMonster(damage, monster,false);
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
            yield return new WaitForSeconds(0.3f);
            AudioManager.Instance.boom1.Play();
            List<GameObject> monsters = new List<GameObject>();
            foreach (var monster in BlocksManager.Instance.monsters)
            {
                if (monster != null) monsters.Add(monster);
            }
            for (int i = 0; i < monsters.Count; i++)
            {
                if (monsters[i].GetComponent<ThisMonster>().isAddAward)
                {
                    //将带有增加isAddAward属性的monster放到链表尾部，使其最后结算
                    monsters.Add(monsters[i]);
                    monsters.RemoveAt(i);
                }
            }
            Debug.Log("Boom");
            yield return new WaitForSeconds(0.1f);
            for (int i = 0; i < monsters.Count; i++)
            {
                yield return new WaitForSeconds(0.06f);
                AttackMonster(damage, monsters[i],false);
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
    public void AddScareCount(int times)
    {
        PlayerData.Instance.AddScareCount(times, scareCounter);
    }
    public void AddAbsorbCount(int rounds, ThisMonster monster)
    {
        monster.AddAbsorb(rounds, absorbCounter);
    }
    public void AddAttackCount(ThisMonster monster)
    {
        monster.AddAttack(0, attackCounter);
    }
    //属性被动装备
    public void StaticAngerCount(int times,int threshold)
    {
        PlayerData.Instance.AddCounterattackCount(times, counterattackCounter);
        PlayerData.Instance.AngerEffect(threshold);
    }
    //间位攻击力改变
    public void AttackImprovedInterval(Transform block,float rate)
    {
        foreach (var Block in BlocksManager.Instance.GetIntervalBlock(block))
        {
            Block.GetComponent<Blocks>().AddAttack(rate);
        }
        foreach(var monster in BlocksManager.Instance.GetInterval(block))
        {
            monster.GetComponent<ThisMonster>().multipleAttacks = rate;
        }
    }
    public void AwardImprovedBesides(Transform block,float count)
    {
        foreach (var Block in BlocksManager.Instance.GetNeighboursBlock(block))
        {
            Block.GetComponent<Blocks>().AddAwards(count);
        }
        foreach (var monster in BlocksManager.Instance.GetInterval(block))
        {
            monster.GetComponent<ThisMonster>().multipleAwards = count;
        }
    }
    public void StartExchangePosition(GameObject monster,int way)
    {
        if (way == 0) { StartCoroutine(ExchangeBesidePosition(monster)); }
        if (way == 1) { StartCoroutine(ExchangeIntervalPosition(monster)); }
    }
    IEnumerator ExchangeBesidePosition(GameObject monster)
    {
        Transform block = monster.GetComponent<ThisMonster>().block;
        if (BlocksManager.Instance.GetNeighbourNext(block) != null)
        {
            GameObject nextMonster = BlocksManager.Instance.GetNeighbourNext(block);
            Transform nextblock = nextMonster.GetComponent<ThisMonster>().block;
            GameObject monsterCard = monster.GetComponent<ThisMonster>().monsterCard;
            GameObject nextMonsterCard = nextMonster.GetComponent<ThisMonster>().monsterCard;
            //
            yield return new WaitForSeconds(0.3f);

            nextMonsterCard.transform.SetParent(block);
            nextMonster.transform.SetParent(block);
            nextMonster.GetComponent<ThisMonster>().block = block;

            monsterCard.transform.SetParent(nextblock);
            monster.transform.SetParent(nextblock);
            monster.GetComponent<ThisMonster>().block = nextblock;

            nextMonster.transform.DOLocalMove(Vector3.zero, 0.3f);
            monster.transform.DOLocalMove(Vector3.zero, 0.3f);

            BlocksManager.Instance.MonsterChange();
        }
        else { yield return null; }

    }
    IEnumerator ExchangeIntervalPosition(GameObject monster)
    {
        Transform block = monster.GetComponent<ThisMonster>().block;
        if (BlocksManager.Instance.GetIntervalNext(block) != null)
        {
            GameObject nextMonster = BlocksManager.Instance.GetIntervalNext(block);
            Transform nextblock = nextMonster.GetComponent<ThisMonster>().block;
            GameObject monsterCard = monster.GetComponent<ThisMonster>().monsterCard;
            GameObject nextMonsterCard = nextMonster.GetComponent<ThisMonster>().monsterCard;
            //
            yield return new WaitForSeconds(0.3f);

            nextMonsterCard.transform.SetParent(block);
            nextMonster.transform.SetParent(block);
            nextMonster.GetComponent<ThisMonster>().block = block;

            monsterCard.transform.SetParent(nextblock);
            monster.transform.SetParent(nextblock);
            monster.GetComponent<ThisMonster>().block = nextblock;

            nextMonster.transform.DOLocalMove(Vector3.zero, 0.3f);
            monster.transform.DOLocalMove(Vector3.zero, 0.3f);

            BlocksManager.Instance.MonsterChange();
        }
        else { yield return null; }

    }



}
