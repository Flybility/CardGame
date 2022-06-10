using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Skills : MonoSingleton<Skills>
{
    public GameObject boomEffect;
    public GameObject dizzyEffect;
    public GameObject burnsEffect;

    public GameObject boomCounter;
    public GameObject dizzyCounter;
    public GameObject burnsCounter;
    public GameObject bondageCounter;
    public GameObject attackTimesCounter;
    public GameObject counterattackCounter;
    public GameObject scareCounter;
    public GameObject absorbCounter;
    public GameObject attackCounter;//攻击随回合增长计数器
    public GameObject summonTimesCounter;
    public GameObject armorCounter;//护甲计数器

    // Start is called before the first frame update
    public void AttackPlayer(int damage,ThisMonster monster)
    {
        PlayerData.Instance.HealthDecrease(damage);
        if (monster.isAddScareCount)
        {
            PlayerData.Instance.AddScareCount(BattleField.Instance.monsterInBattle.Count, scareCounter);
        }
        else { PlayerData.Instance.AddScareCount(monster.attackAttachedScare, scareCounter); }
        if (monster.isAddBurnsCount)
        {
            PlayerData.Instance.AddBurns(BattleField.Instance.monsterInBattle.Count, burnsCounter);
        }
        else { PlayerData.Instance.AddBurns(monster.attackAttachedBurns, scareCounter); }
        PlayerData.Instance.AddBondages(monster.attackAttachedBondages, bondageCounter);
        PlayerData.Instance.gameObject.transform.DOPunchPosition(new Vector3(-40, 0, 0), 0.3f, 3, 1);

    }
    public void AttackMonster(int damage, GameObject target,bool isStraight)
    {
        List<GameObject> monster = new List<GameObject>();
        if (PlayerData.Instance.isAttackBesides)
        {
            
            monster = BlocksManager.Instance.GetNeighbours(target.GetComponent<ThisMonster>().block);
            PlayerData.Instance.isAttackBesides = false;
        }
        if (PlayerData.Instance.isAttackInterval) 
        {
            
            monster = BlocksManager.Instance.GetInterval(target.GetComponent<ThisMonster>().block);
            PlayerData.Instance.isAttackInterval = false;
        }
        monster.Add(target);
        int c = monster.Count;
        int n = damage % c;
        if (n != 0)
        {
            if (n >= c-1) { damage = damage / c + 1; } 
        }
        else { damage /= c; }
        foreach (var mons in monster)
        {
            mons.GetComponent<ThisMonster>().HealthDecrease(damage, isStraight, false);
            mons.transform.DOPunchPosition(new Vector3(30, 0, 0), 0.3f, 3, 1);
        }
        
    }
    public void RecoverPlayerHealth(int value)
    {
        PlayerData.Instance.HealthRecover(value);
    }
    public void StartBoom(ThisMonster thisMonster, int damage)
    {
        StartCoroutine(BoomBeside(thisMonster, damage));
    }
    IEnumerator BoomBeside(ThisMonster thisMonster, int damage)
    {       
        if (BattleField.Instance.isFinished == false)
        {
            
            AudioManager.Instance.boom1.Play();
            List<GameObject> monsters = BlocksManager.Instance.GetNeighbours(thisMonster.block);
                //播放爆炸动画
            foreach (var monster in BlocksManager.Instance.GetNeighbours(thisMonster.block))
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
            yield return new WaitForSeconds(0.2f);
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
    public void AddArmorToPlayer(int count)
    {
        PlayerData.Instance.AddArmor(count, armorCounter);
    }
    public void AddDizzyToBesides(Transform block, int count)
    {       
        foreach(var monster in BlocksManager.Instance.GetNeighbours(block))
        {
            monster.GetComponent<ThisMonster>().AddDizzy(count, dizzyCounter);
        }
    }
    public void AddBurnsToBesides(Transform block,int count)
    {
        foreach (var monster in BlocksManager.Instance.GetNeighbours(block))
        {
            monster.GetComponent<ThisMonster>().AddBurns(count, burnsCounter);
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
    public void AddBurnsToPlayer(int times)
    {
        PlayerData.Instance.AddBurns(times, burnsCounter);
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
       // foreach (var Block in BlocksManager.Instance.GetIntervalBlock(block))
       // {
       //     Block.GetComponent<Blocks>().AddAttack(rate);
       // }
        foreach(var monster in BlocksManager.Instance.GetInterval(block))
        {
            monster.GetComponent<ThisMonster>().multipleAttacks = rate;
        }
    }
    public void AttackImprovedBesides(Transform block, float rate)
    {
       // foreach (var Block in BlocksManager.Instance.GetNeighboursBlock(block))
       // {
       //     Block.GetComponent<Blocks>().AddAttack(rate);
       // }
        foreach (var monster in BlocksManager.Instance.GetNeighbours(block))
        {
            monster.GetComponent<ThisMonster>().multipleAttacks = rate;
        }
    }
    public void AwardImprovedBesides(Transform block,float count)
    {
       //foreach (var Block in BlocksManager.Instance.GetNeighboursBlock(block))
       //{
       //    Block.GetComponent<Blocks>().AddAwards(count);
       //}
        foreach (var monster in BlocksManager.Instance.GetInterval(block))
        {
            monster.GetComponent<ThisMonster>().multipleAwards = count;
        }
    }
    public void RecoverBesides(Transform block, int count)
    {       
        foreach (var monster in BlocksManager.Instance.GetNeighbours(block))
        {
            monster.GetComponent<ThisMonster>().HealthRecover(count);
        }
    }
    public void ArmoredBesides(Transform block, int count)
    {
        foreach (var monster in BlocksManager.Instance.GetNeighbours(block))
        {
            monster.GetComponent<ThisMonster>().AddArmor(count, armorCounter);
        }
    }
    public void ArmoredSelf(ThisMonster monster,int count)
    {
        monster.AddArmor(count, armorCounter);
    }
    public void StartExchangeBesidePosition(GameObject monster)
    {
        StartCoroutine(ExchangeBesidePosition(monster)); 
    }
    public void StartExchangeIntervalPosition(GameObject monster)
    {
        StartCoroutine(ExchangeIntervalPosition(monster));
    }
    IEnumerator ExchangeBesidePosition(GameObject monster)
    {
        Transform block = monster.GetComponent<ThisMonster>().block;
        GameObject monsterCard = monster.GetComponent<ThisMonster>().monsterCard;
        if (BlocksManager.Instance.GetNeighbourNext(block) != null)
        {
            GameObject nextMonster = BlocksManager.Instance.GetNeighbourNext(block);
            Transform nextblock = nextMonster.GetComponent<ThisMonster>().block;

            GameObject nextMonsterCard = nextMonster.GetComponent<ThisMonster>().monsterCard;
            //
            yield return new WaitForSeconds(0.05f);

            nextMonsterCard.transform.SetParent(block);
            nextMonster.transform.SetParent(block);
            //nextMonster.GetComponent<ThisMonster>().stateBlock.SetParent(block);
            ///nextMonster.GetComponent<ThisMonster>().stateBlock.DOLocalMove(nextMonster.GetComponent<ThisMonster>().initialStateBlock, 0.2f);
            nextMonster.GetComponent<ThisMonster>().block = block;
            

            monsterCard.transform.SetParent(nextblock);
            monster.transform.SetParent(nextblock);
            //monster.GetComponent<ThisMonster>().stateBlock.SetParent(nextblock);
            //monster.GetComponent<ThisMonster>().stateBlock.DOLocalMove(monster.GetComponent<ThisMonster>().initialStateBlock, 0.2f) ;
            monster.GetComponent<ThisMonster>().block = nextblock;

            nextMonster.transform.DOLocalMove(Vector3.zero, 0.3f);
            monster.transform.DOLocalMove(Vector3.zero, 0.3f);

            BlocksManager.Instance.MonsterChange();
        }
        else 
        {
            yield return new WaitForSeconds(0.05f);
            Transform nextBlock = BlocksManager.Instance.GetNextBlock(block).transform;
            monsterCard.transform.SetParent(nextBlock);
            monster.transform.SetParent(nextBlock);
            //monster.GetComponent<ThisMonster>().stateBlock.SetParent(nextBlock);
            //monster.GetComponent<ThisMonster>().stateBlock.DOLocalMove(monster.GetComponent<ThisMonster>().initialStateBlock, 0.2f);
            monster.GetComponent<ThisMonster>().block = nextBlock;
            monster.transform.DOLocalMove(Vector3.zero, 0.3f);

            BlocksManager.Instance.MonsterChange();
        }

    }
    IEnumerator ExchangeIntervalPosition(GameObject monster)
    {
        Transform block = monster.GetComponent<ThisMonster>().block;
        GameObject monsterCard = monster.GetComponent<ThisMonster>().monsterCard;
        if (BlocksManager.Instance.GetIntervalNext(block) != null)
        {
            GameObject nextMonster = BlocksManager.Instance.GetIntervalNext(block);
            Transform nextblock = nextMonster.GetComponent<ThisMonster>().block;
            GameObject nextMonsterCard = nextMonster.GetComponent<ThisMonster>().monsterCard;
            //
            yield return new WaitForSeconds(0.05f);

            nextMonsterCard.transform.SetParent(block);
            nextMonster.transform.SetParent(block);
            //nextMonster.GetComponent<ThisMonster>().stateBlock.SetParent(block);
            //nextMonster.GetComponent<ThisMonster>().stateBlock.DOLocalMove(nextMonster.GetComponent<ThisMonster>().initialStateBlock, 0.2f);
            nextMonster.GetComponent<ThisMonster>().block = block;


            monsterCard.transform.SetParent(nextblock);
            monster.transform.SetParent(nextblock);
            //monster.GetComponent<ThisMonster>().stateBlock.SetParent(nextblock);
            //monster.GetComponent<ThisMonster>().stateBlock.DOLocalMove(monster.GetComponent<ThisMonster>().initialStateBlock, 0.2f);
            monster.GetComponent<ThisMonster>().block = nextblock;

            nextMonster.transform.DOLocalMove(Vector3.zero, 0.3f);
            monster.transform.DOLocalMove(Vector3.zero, 0.3f);

            BlocksManager.Instance.MonsterChange();
        }
        else
        {
            yield return new WaitForSeconds(0.05f);
            Transform nextBlock = BlocksManager.Instance.GetNextIntervalBlock(block).transform;
            monsterCard.transform.SetParent(nextBlock);
            monster.transform.SetParent(nextBlock);
            //monster.GetComponent<ThisMonster>().stateBlock.SetParent(nextBlock);
            //monster.GetComponent<ThisMonster>().stateBlock.DOLocalMove(monster.GetComponent<ThisMonster>().initialStateBlock, 0.2f);
            monster.GetComponent<ThisMonster>().block = nextBlock;
            monster.transform.DOLocalMove(Vector3.zero, 0.3f);

            BlocksManager.Instance.MonsterChange();
        }

    }
    public GameObject nextMonster;
    public Transform nextBlock;
    public GameObject nextMonsterCard;
    public bool isNext = true;
    public int reverse;
    public void StartSwallowMonster(GameObject monster)
    {
        if (isNext == true)
        {
            StartCoroutine(SwallowMonsterNext(monster));
        }
        else if(isNext==false)
        {
            StartCoroutine(SwallowMonsterPrevious(monster));
        }

    }

    IEnumerator SwallowMonsterNext(GameObject monster)
    {
        Transform block = monster.GetComponent<ThisMonster>().block;
        GameObject monsterCard = monster.GetComponent<ThisMonster>().monsterCard;
        if (BlocksManager.Instance.GetNeighbourNext(block))
        {
            nextMonster = BlocksManager.Instance.GetNeighbourNext(block);
            nextBlock = nextMonster.GetComponent<ThisMonster>().block;
            nextMonsterCard = nextMonster.GetComponent<ThisMonster>().monsterCard;
            if (nextMonster.GetComponent<ThisMonster>().health < monster.GetComponent<ThisMonster>().health)
            {
                reverse = 0;
                yield return new WaitForSeconds(0.05f);
                Debug.Log("change");
                nextMonsterCard.GetComponent<ThisMonsterCard>().summonTimes--;
                int n = nextMonster.GetComponent<ThisMonster>().awardHealth;
                monster.GetComponent<ThisMonster>().awardHealth += n;
                int award = nextMonster.GetComponent<ThisMonster>().awardHealth;
                int attack = nextMonster.GetComponent<ThisMonster>().currentAttacks;
                int health = nextMonster.GetComponent<ThisMonster>().health;
                monster.GetComponent<ThisMonster>().awardHealth += award;
                monster.GetComponent<ThisMonster>().currentAttacks += (int)attack / 2;
                monster.GetComponent<ThisMonster>().health += (int)health / 2;
                monster.GetComponent<ThisMonster>().maxHealth += (int)health / 2;
                //Destroy(nextMonster.GetComponent<ThisMonster>().stateBlock.gameObject);
                BattleField.Instance.StartMonsterDead(nextMonster, nextMonsterCard);
                monsterCard.transform.SetParent(nextBlock);
                monster.transform.SetParent(nextBlock);
                //monster.GetComponent<ThisMonster>().stateBlock.SetParent(nextBlock);
                // monster.GetComponent<ThisMonster>().stateBlock.DOLocalMove(monster.GetComponent<ThisMonster>().initialStateBlock, 0.2f);
                monster.GetComponent<ThisMonster>().block = nextBlock;
                monster.transform.DOLocalMove(Vector3.zero, 0.3f);



                BlocksManager.Instance.MonsterChange();
                yield break;
            }
            else if (BlocksManager.Instance.GetNeighbourPrevious(block))
            {
                reverse += 1;
                isNext = false;

                if (reverse > 2)
                {
                    Debug.Log("stop");
                    yield break;
                }
                else
                {
                    StartCoroutine(SwallowMonsterPrevious(monster));
                }
                // nextMonster = BlocksManager.Instance.GetNeighbourNext(block);
                // nextBlock = nextMonster.GetComponent<ThisMonster>().block;
                // nextMonsterCard = nextMonster.GetComponent<ThisMonster>().monsterCard;
                // yield return new WaitForSeconds(0.05f);
                //
                // nextMonsterCard.GetComponent<ThisMonsterCard>().summonTimes--;
                //
                // int award = nextMonster.GetComponent<ThisMonster>().awardHealth;
                // int attack = nextMonster.GetComponent<ThisMonster>().currentAttacks;
                // int health = nextMonster.GetComponent<ThisMonster>().health;
                // monster.GetComponent<ThisMonster>().awardHealth += award;
                // monster.GetComponent<ThisMonster>().currentAttacks += attack;
                // monster.GetComponent<ThisMonster>().health += (int)health / 2;
                // monster.GetComponent<ThisMonster>().maxHealth += (int)health / 2;
                // //Destroy(nextMonster.GetComponent<ThisMonster>().stateBlock.gameObject);
                // BattleField.Instance.StartMonsterDead(nextMonster, nextMonsterCard);

            }
            else if (BlocksManager.Instance.GetNeighbourPrevious(block)==null)
            {
                isNext = false;
                reverse = 0;
                nextBlock= BlocksManager.Instance.GetPreviousBlock(block).transform;
                monsterCard.transform.SetParent(nextBlock);
                monster.transform.SetParent(nextBlock);
                //monster.GetComponent<ThisMonster>().stateBlock.SetParent(nextBlock);
                // monster.GetComponent<ThisMonster>().stateBlock.DOLocalMove(monster.GetComponent<ThisMonster>().initialStateBlock, 0.2f);
                monster.GetComponent<ThisMonster>().block = nextBlock;
                monster.transform.DOLocalMove(Vector3.zero, 0.3f);



                BlocksManager.Instance.MonsterChange();
            }

            yield break;
        }
        else
        {
            reverse = 0;
            Debug.Log("hhh");
            yield return new WaitForSeconds(0.05f);
            Transform nextBlock = BlocksManager.Instance.GetNextBlock(block).transform;
            monsterCard.transform.SetParent(nextBlock);
            monster.transform.SetParent(nextBlock);
            //monster.GetComponent<ThisMonster>().stateBlock.SetParent(nextBlock);
            //monster.GetComponent<ThisMonster>().stateBlock.DOLocalMove(monster.GetComponent<ThisMonster>().initialStateBlock, 0.2f);
            monster.GetComponent<ThisMonster>().block = nextBlock;
            monster.transform.DOLocalMove(Vector3.zero, 0.3f);

            BlocksManager.Instance.MonsterChange();
        }
    }
    IEnumerator SwallowMonsterPrevious(GameObject monster)
    {
        Transform block = monster.GetComponent<ThisMonster>().block;
        GameObject monsterCard = monster.GetComponent<ThisMonster>().monsterCard;
        if (BlocksManager.Instance.GetNeighbourPrevious(block))
        {
            nextMonster = BlocksManager.Instance.GetNeighbourPrevious(block);
            nextBlock = nextMonster.GetComponent<ThisMonster>().block;
            nextMonsterCard = nextMonster.GetComponent<ThisMonster>().monsterCard;
            if (nextMonster.GetComponent<ThisMonster>().health < monster.GetComponent<ThisMonster>().health)
            {
                reverse = 0;
                yield return new WaitForSeconds(0.05f);

                nextMonsterCard.GetComponent<ThisMonsterCard>().summonTimes--;
                int n = nextMonster.GetComponent<ThisMonster>().awardHealth;
                monster.GetComponent<ThisMonster>().awardHealth += n;
                int award = nextMonster.GetComponent<ThisMonster>().awardHealth;
                int attack = nextMonster.GetComponent<ThisMonster>().currentAttacks;
                int health = nextMonster.GetComponent<ThisMonster>().health;
                monster.GetComponent<ThisMonster>().awardHealth += award;
                monster.GetComponent<ThisMonster>().currentAttacks += (int)attack/2;
                monster.GetComponent<ThisMonster>().health += (int)health / 2;
                monster.GetComponent<ThisMonster>().maxHealth += (int)health / 2;
                //Destroy(nextMonster.GetComponent<ThisMonster>().stateBlock.gameObject);
                BattleField.Instance.StartMonsterDead(nextMonster, nextMonsterCard);
                monsterCard.transform.SetParent(nextBlock);
                monster.transform.SetParent(nextBlock);
                //monster.GetComponent<ThisMonster>().stateBlock.SetParent(nextBlock);
                // monster.GetComponent<ThisMonster>().stateBlock.DOLocalMove(monster.GetComponent<ThisMonster>().initialStateBlock, 0.2f);
                monster.GetComponent<ThisMonster>().block = nextBlock;
                monster.transform.DOLocalMove(Vector3.zero, 0.3f);



                BlocksManager.Instance.MonsterChange();
                yield break;
            }
            else if (BlocksManager.Instance.GetNeighbourNext(block))
            {
                reverse += 1;
                isNext = true;
                if (reverse >2)
                {
                    Debug.Log("stop");
                    yield break;
                }
                else
                {
                    StartCoroutine(SwallowMonsterNext(monster));
                }

               // nextMonster = BlocksManager.Instance.GetNeighbourNext(block);
               // nextBlock = nextMonster.GetComponent<ThisMonster>().block;
               // nextMonsterCard = nextMonster.GetComponent<ThisMonster>().monsterCard;
               // yield return new WaitForSeconds(0.05f);
               //
               // nextMonsterCard.GetComponent<ThisMonsterCard>().summonTimes--;
               //
               // int award = nextMonster.GetComponent<ThisMonster>().awardHealth;
               // int attack = nextMonster.GetComponent<ThisMonster>().currentAttacks;
               // int health = nextMonster.GetComponent<ThisMonster>().health;
               // monster.GetComponent<ThisMonster>().awardHealth += award;
               // monster.GetComponent<ThisMonster>().currentAttacks += attack;
               // monster.GetComponent<ThisMonster>().health += (int)health / 2;
               // monster.GetComponent<ThisMonster>().maxHealth += (int)health / 2;
               // //Destroy(nextMonster.GetComponent<ThisMonster>().stateBlock.gameObject);
               // BattleField.Instance.StartMonsterDead(nextMonster, nextMonsterCard);

            }
            else if (BlocksManager.Instance.GetNeighbourNext(block) == null)
            {
                isNext = true;
                reverse = 0;
                nextBlock = BlocksManager.Instance.GetNextBlock(block).transform;
                monsterCard.transform.SetParent(nextBlock);
                monster.transform.SetParent(nextBlock);
                //monster.GetComponent<ThisMonster>().stateBlock.SetParent(nextBlock);
                // monster.GetComponent<ThisMonster>().stateBlock.DOLocalMove(monster.GetComponent<ThisMonster>().initialStateBlock, 0.2f);
                monster.GetComponent<ThisMonster>().block = nextBlock;
                monster.transform.DOLocalMove(Vector3.zero, 0.3f);



                BlocksManager.Instance.MonsterChange();
            }

            yield break;
           
        }
        else
        {
            reverse = 0;
            yield return new WaitForSeconds(0.05f);
            Transform nextBlock = BlocksManager.Instance.GetPreviousBlock(block).transform;
            monsterCard.transform.SetParent(nextBlock);
            monster.transform.SetParent(nextBlock);
            //monster.GetComponent<ThisMonster>().stateBlock.SetParent(nextBlock);
            //monster.GetComponent<ThisMonster>().stateBlock.DOLocalMove(monster.GetComponent<ThisMonster>().initialStateBlock, 0.2f);
            monster.GetComponent<ThisMonster>().block = nextBlock;
            monster.transform.DOLocalMove(Vector3.zero, 0.3f);

            BlocksManager.Instance.MonsterChange();
        }
    }



}
