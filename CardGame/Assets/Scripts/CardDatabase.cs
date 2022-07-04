using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoSingleton<CardDatabase>
{
    public  List<EquipmentCard> equipmentCardList = new List<EquipmentCard>();
    public  List<MonsterCard> monsterCardList = new List<MonsterCard>();
    private void Awake()
    {
        equipmentCardList.Add(new EquipmentCard( 0, "蓝宝石",     10, 10, "使指定的心魔顺时针与下一个心魔互换位置",                                                Resources.Load<Sprite>("EquipmentImages/01"),  false));
        equipmentCardList.Add(new EquipmentCard( 1, "紫宝石",     10, 10, "使指定的心魔顺时针与下一个相间的心魔互换位置",                                          Resources.Load<Sprite>("EquipmentImages/02"),  false));
        equipmentCardList.Add(new EquipmentCard( 2, "红宝石",     10, 10, "下次攻击对目标攻击2次",                                                   Resources.Load<Sprite>("EquipmentImages/03"),  false));
        equipmentCardList.Add(new EquipmentCard( 3, "绿宝石",     10,  3, "选择一名心魔使其本回合免疫任何伤害",                                                    Resources.Load<Sprite>("EquipmentImages/04"),  false));
        equipmentCardList.Add(new EquipmentCard( 4, "橙宝石",     10,  3, "下次攻击伤害分摊至相邻的心魔，一回合限用一次",                                                          Resources.Load<Sprite>("EquipmentImages/01"),  false));
        equipmentCardList.Add(new EquipmentCard( 5, "黄宝石",     10,  2, "下次攻击伤害分摊至相间的心魔，一回合限用一次",                                                          Resources.Load<Sprite>("EquipmentImages/01"),  false));
        equipmentCardList.Add(new EquipmentCard( 6, "橙水晶",     10,  3, "下次攻击间位获得与被攻击目标同样的伤害,一回合限用一次",                                                Resources.Load<Sprite>("EquipmentImages/01"),  false));
        equipmentCardList.Add(new EquipmentCard( 7, "黄水晶",     10,  3, "下次攻击邻位获得与被攻击目标同样的伤害，一回合限用一次",                                                Resources.Load<Sprite>("EquipmentImages/01"),  false));        
        equipmentCardList.Add(new EquipmentCard( 8, "酒精",       10,  5, "被击中的目标本回合内若受到“爆炸伤害”被添加3层“灼伤”",                               Resources.Load<Sprite>("EquipmentImages/08"),  false));
        equipmentCardList.Add(new EquipmentCard( 9, "燃烧的烟头", 10,100, "场上所有带有“灼伤”效果的敌人每回合受到的“灼伤”伤害+6”",                            Resources.Load<Sprite>("EquipmentImages/01"),  true));
        equipmentCardList.Add(new EquipmentCard(10, "小喇叭",     10,  3, "被击中的目标本回合内若受到“爆炸伤害”被添加1层“眩晕”",                               Resources.Load<Sprite>("EquipmentImages/01"),  false));
        equipmentCardList.Add(new EquipmentCard(11, "花纹手绢",   10,100, "对眩晕态的敌人攻击增加1倍",                                                             Resources.Load<Sprite>("EquipmentImages/01"),  true));
        equipmentCardList.Add(new EquipmentCard(12, "断裂铅笔",   10,  5, "对一个目标造成6点伤害，若目标处在眩晕态造成16点伤害",                                   Resources.Load<Sprite>("EquipmentImages/01"),  false));
        equipmentCardList.Add(new EquipmentCard(13, "催眠怀表",   10, 10, "使相邻位置的心魔互换",                                                                  Resources.Load<Sprite>("EquipmentImages/01"),  false));
        equipmentCardList.Add(new EquipmentCard(14, "纸杯蛋糕",   10, 10, "休息节点回复的情绪增至15点（初始10点）",                                                Resources.Load<Sprite>("EquipmentImages/01"),  true));
        equipmentCardList.Add(new EquipmentCard(15, "幸运草",     10, 10, "情绪最大值扩充15",                                                                      Resources.Load<Sprite>("EquipmentImages/15"),  true));
        equipmentCardList.Add(new EquipmentCard(16, "秘密日记本", 10,  3, "丢弃所有手牌，重新抽一次牌",                                                            Resources.Load<Sprite>("EquipmentImages/01"),  false));
        equipmentCardList.Add(new EquipmentCard(17, "发霉面包",   10,  3, "情绪回复15点，血量上限降低5点",                                                         Resources.Load<Sprite>("EquipmentImages/01"),  false));
        equipmentCardList.Add(new EquipmentCard(18, "烤肉",       10,  2, "情绪回复10点",                                                                          Resources.Load<Sprite>("EquipmentImages/18"),  false));
        equipmentCardList.Add(new EquipmentCard(19, "    ",       10,  3, "每击杀1名心魔，额外回复3点情绪",                                                        Resources.Load<Sprite>("EquipmentImages/01"),  true));
        equipmentCardList.Add(new EquipmentCard(20, "破旧雨伞",   10,  3, "每回合开始获得10点护甲",                                                                Resources.Load<Sprite>("EquipmentImages/01"),  true));
        equipmentCardList.Add(new EquipmentCard(21, "啜泣外衣",   10,100, "每回合获得15点护甲，局末初始伤害 - 5",                                                  Resources.Load<Sprite>("EquipmentImages/01"),  true));
        equipmentCardList.Add(new EquipmentCard(22, "安眠药",     10,  5, "恢复50点情绪",                                                                          Resources.Load<Sprite>("EquipmentImages/01"),  false));
        equipmentCardList.Add(new EquipmentCard(23, "玩具盾牌",   10, 10, "获得60点护甲",                                                                          Resources.Load<Sprite>("EquipmentImages/01"),  false));
        equipmentCardList.Add(new EquipmentCard(24, "    ",       10, 10, "回合末攻击伤害 + 8",                                                                    Resources.Load<Sprite>("EquipmentImages/01"),  true));
        equipmentCardList.Add(new EquipmentCard(25, "    ",       10, 10, "该回合末攻击伤害 + 16",                                                                 Resources.Load<Sprite>("EquipmentImages/01"),  true));
        equipmentCardList.Add(new EquipmentCard(26, "叛逆",       10,  3, "每受到一次大于4点的伤害，增加一层反击",                                                 Resources.Load<Sprite>("EquipmentImages/01"),  true));
        equipmentCardList.Add(new EquipmentCard(27, "烟花",       10,  3, "对一个目标造成13点伤害，邻位受到6点伤害",                                               Resources.Load<Sprite>("EquipmentImages/01"),  false));
        equipmentCardList.Add(new EquipmentCard(28, "玩具弓",     10,  2, "对一个目标造成25点伤害",                                                                Resources.Load<Sprite>("EquipmentImages/28"),  false));
        equipmentCardList.Add(new EquipmentCard(29, "英雄护腕",   10,  3, "增加2层反击",                                                                           Resources.Load<Sprite>("EquipmentImages/01"),  false));
        equipmentCardList.Add(new EquipmentCard(30, "英雄护甲",   10,  3, "每回合开始获得10点护甲",                                                                Resources.Load<Sprite>("EquipmentImages/30"),  true));
        equipmentCardList.Add(new EquipmentCard(31, "安眠药水",   10,  2, "清空所有恐惧",                                                                          Resources.Load<Sprite>("EquipmentImages/31"),  false));
        equipmentCardList.Add(new EquipmentCard(32, "水果硬糖",   10,  3, "增加2层反击",                                                                           Resources.Load<Sprite>("EquipmentImages/01"),  true));
        equipmentCardList.Add(new EquipmentCard(33, "",           10,  3, "每回合开始获得10点护甲",                                                                Resources.Load<Sprite>("EquipmentImages/01"),  true));
        equipmentCardList.Add(new EquipmentCard(33, "沙漏",        3,  3, "指定一只心魔进行回收",                                                                  Resources.Load<Sprite>("EquipmentImages/01"),  false));

        monsterCardList.Add(new MonsterCard(00, "伤痕(小)",    8,  3,  2,  1, "",                                                                                                                                       Resources.Load<Sprite>("CardImages/00"), Resources.Load<Sprite>("CardBackgrounds/2"),  false));
        monsterCardList.Add(new MonsterCard(01, "愤怒(小)",    5,  2,  1,  1, "击杀后爆炸,对左右位置的心魔造成8点爆炸伤害",                                                                                             Resources.Load<Sprite>("CardImages/01"), Resources.Load<Sprite>("CardBackgrounds/2"),  false));
        monsterCardList.Add(new MonsterCard(02, "伤痕(中)",   12,  4,  5,  2, "",                                                                                                                                       Resources.Load<Sprite>("CardImages/02"), Resources.Load<Sprite>("CardBackgrounds/2"),  false));
        monsterCardList.Add(new MonsterCard(03, "伤痕(大)",   20,  6,  8,  3, "",                                                                                                                                       Resources.Load<Sprite>("CardImages/03"), Resources.Load<Sprite>("CardBackgrounds/2"),  false));
        monsterCardList.Add(new MonsterCard(04, "伤痕(特)",   30,  8, 13,  4, "",                                                                                                                                       Resources.Load<Sprite>("CardImages/04"), Resources.Load<Sprite>("CardBackgrounds/2"),  false));
        monsterCardList.Add(new MonsterCard(05, "愤怒(中)",    8,  4,  2,  2, "击杀后爆炸,对左右邻位的心魔造成15点爆炸伤害",                                                                                            Resources.Load<Sprite>("CardImages/05"), Resources.Load<Sprite>("CardBackgrounds/2"),  false));
        monsterCardList.Add(new MonsterCard(06, "愤怒(大)",   40,  7,  2,  1, "击杀后爆炸,对场上所有心魔均造成50点爆炸伤害,对主角造成15点伤害",                                                                         Resources.Load<Sprite>("CardImages/06"), Resources.Load<Sprite>("CardBackgrounds/2"),  false));
        monsterCardList.Add(new MonsterCard(07, "嘶叫",        8,  4,  2,  2, "击杀后惨叫,对左右位置的心魔各施加1层眩晕,对玩家施加1层恐惧",                                                                             Resources.Load<Sprite>("CardImages/07"), Resources.Load<Sprite>("CardBackgrounds/2"),  false));
        monsterCardList.Add(new MonsterCard(08, "悲伤",        6,  3,  1,  1, "存活时,其间位的心魔攻击力减半"+"\n"+"攻击力随回合数增加",                                                                                Resources.Load<Sprite>("CardImages/08"), Resources.Load<Sprite>("CardBackgrounds/2"),  false));
        monsterCardList.Add(new MonsterCard(09, "怜悯",        6,  3,  1,  1, "存活时,击杀其邻位的心魔情绪恢复翻倍" + "\n" + "攻击力随回合数增加",                                                                      Resources.Load<Sprite>("CardImages/00"), Resources.Load<Sprite>("CardBackgrounds/2"),  false));
        monsterCardList.Add(new MonsterCard(10, "掮客",        6,  6,  1,  1, "怪物描述2",                                                                                                                              Resources.Load<Sprite>("CardImages/02"), Resources.Load<Sprite>("CardBackgrounds/2"),  false));
        monsterCardList.Add(new MonsterCard(11, "    ",        8,  4,  2,  2, "击杀后下回合从抽牌堆中多抽取2张牌",                                                                                                      Resources.Load<Sprite>("CardImages/02"), Resources.Load<Sprite>("CardBackgrounds/2"),  false));
        monsterCardList.Add(new MonsterCard(12, "    ",        8,  4,  2,  2, "击杀后下回合常规攻击+15",                                                                                                                Resources.Load<Sprite>("CardImages/02"), Resources.Load<Sprite>("CardBackgrounds/2"),  false));
        monsterCardList.Add(new MonsterCard(13, "鬼脸",        8,  4,  2,  2, "存在场上时情绪每回合不再下降",                                                                                                           Resources.Load<Sprite>("CardImages/02"), Resources.Load<Sprite>("CardBackgrounds/2"),  false));
        monsterCardList.Add(new MonsterCard(14, "无形",        1,  1,  1,  1, "放置后变身成所在位置对位的心魔",                                                                                                         Resources.Load<Sprite>("CardImages/02"), Resources.Load<Sprite>("CardBackgrounds/2"),  false));
        monsterCardList.Add(new MonsterCard(15, "忍耐",       10,  6,  2,  1, "放置后的3回合内无敌,第3回合结束时爆炸,对相邻心魔造成期间所承受的所有伤害",                                                               Resources.Load<Sprite>("CardImages/15"), Resources.Load<Sprite>("CardBackgrounds/2"),  false));
        monsterCardList.Add(new MonsterCard(16, "小丑",       25,  8,  5,  1, "每回合末对玩家攻击时施加X层恐惧(X为场上心魔数)",                                                                                         Resources.Load<Sprite>("CardImages/16"), Resources.Load<Sprite>("CardBackgrounds/2"),  false));
        monsterCardList.Add(new MonsterCard(17, "黑夜",       25,  8,  5,  1, "每回合末对玩家攻击时施加2层恐惧。",                                                                                                      Resources.Load<Sprite>("CardImages/02"), Resources.Load<Sprite>("CardBackgrounds/2"),  false));
        monsterCardList.Add(new MonsterCard(18, "蝙蝠",       16, 14,  5,  1, "1.每回合末对玩家攻击时施加1层恐惧\n2.直接攻击对其无效",                                                                                  Resources.Load<Sprite>("CardImages/18"), Resources.Load<Sprite>("CardBackgrounds/2"),  false));
        monsterCardList.Add(new MonsterCard(19, "焚者",       25,  8,  5,  1, "每回合末对玩家攻击时施加X层灼伤\n(X为场上心魔数)",                                                                                       Resources.Load<Sprite>("CardImages/02"), Resources.Load<Sprite>("CardBackgrounds/2"),  false));
        monsterCardList.Add(new MonsterCard(20, "炙鬼",       25, 14,  5,  1, "每回合末对玩家攻击时施加2层灼伤",                                                                                                        Resources.Load<Sprite>("CardImages/02"), Resources.Load<Sprite>("CardBackgrounds/2"),  false));
        monsterCardList.Add(new MonsterCard(21, "蜘蛛",       33,  8,  5,  1, "每回合末对玩家攻击时施加1层束缚(下回合抽牌数-1)",                                                                                        Resources.Load<Sprite>("CardImages/02"), Resources.Load<Sprite>("CardBackgrounds/2"),  false));
        monsterCardList.Add(new MonsterCard(22, "负面本质",   50, 20, 45,  1, "在场上时邻位心魔攻击翻倍",                                                                                                               Resources.Load<Sprite>("CardImages/02"), Resources.Load<Sprite>("CardBackgrounds/2"),  false));                                                              
        monsterCardList.Add(new MonsterCard(23, "负面本质",   50, 20, 45,  1, "每回合为邻位的心魔恢复血量各10点",                                                                                                       Resources.Load<Sprite>("CardImages/02"), Resources.Load<Sprite>("CardBackgrounds/2"),  false));                                                              
        monsterCardList.Add(new MonsterCard(24, "顽固",       70, 20, 45,  1, "每回合为邻位的心魔生成护盾各10点",                                                                                                       Resources.Load<Sprite>("CardImages/02"), Resources.Load<Sprite>("CardBackgrounds/2"),  false));                                                              
        monsterCardList.Add(new MonsterCard(25, "纸醉金迷",   20, 20, 45,  1, "每回合生成50护甲",                                                                                                                       Resources.Load<Sprite>("CardImages/25"), Resources.Load<Sprite>("CardBackgrounds/2"),  false));                                                              
        monsterCardList.Add(new MonsterCard(26, "自卑1",      25, 20, 35,  1, "1.每回合攻击后生成30护甲并顺时针与邻位的心魔互换。",                                                                                     Resources.Load<Sprite>("CardImages/02"), Resources.Load<Sprite>("CardBackgrounds/2"),  false));
        monsterCardList.Add(new MonsterCard(27, "自卑2",      40, 24, 35,  1, "攻击后顺时针与间位的心魔互换",                                                                                                           Resources.Load<Sprite>("CardImages/02"), Resources.Load<Sprite>("CardBackgrounds/2"),  false));
        monsterCardList.Add(new MonsterCard(28, "贪婪",       15,  4,  5,  1, "回合结束顺时针吞噬相邻心魔,若其血量大于自身则改变吞噬方向",                                                                              Resources.Load<Sprite>("CardImages/28"), Resources.Load<Sprite>("CardBackgrounds/2"),  false));
        monsterCardList.Add(new MonsterCard(29, "贪婪2",      35, 16,  8,  1, "回合结束顺时针吞噬相邻心魔,若其血量大于自身则改变吞噬方向",                                                                              Resources.Load<Sprite>("CardImages/02"), Resources.Load<Sprite>("CardBackgrounds/2"),  false));
        monsterCardList.Add(new MonsterCard(30, "分赃",       50, 20, 35,  1, "死亡后在场的所有心魔恢复15点血量",                                                                                                       Resources.Load<Sprite>("CardImages/02"), Resources.Load<Sprite>("CardBackgrounds/2"),  false));
        monsterCardList.Add(new MonsterCard(31, "挣扎",       40, 30, 40,  1, "死亡时仍会对玩家立即造成最后一次伤害",                                                                                                   Resources.Load<Sprite>("CardImages/02"), Resources.Load<Sprite>("CardBackgrounds/2"),  false));
        monsterCardList.Add(new MonsterCard(32, "孵化者",    160, 33, 70,  1, "每回合末在战场任意一空位置召唤一只孪生恶魔",                                                                                             Resources.Load<Sprite>("CardImages/02"), Resources.Load<Sprite>("CardBackgrounds/2"),  false));
        monsterCardList.Add(new MonsterCard(33, "孪生恶魔",   10,  4,  0,  1, "1.其中1只死亡时 另1只血量回满,攻击变为20\n每回合攻击后施加3层恐惧并添加12点护甲",                                                        Resources.Load<Sprite>("CardImages/02"), Resources.Load<Sprite>("CardBackgrounds/2"),  false));
        monsterCardList.Add(new MonsterCard(34, "父亲",       35, 16,  8,  1, "怪物描述3",                                                                                                                              Resources.Load<Sprite>("CardImages/02"), Resources.Load<Sprite>("CardBackgrounds/2"),  false));
        monsterCardList.Add(new MonsterCard(35, "堂吉诃德",   50, 20, 35,  1, "主角情绪上升时'堂吉诃德'血量下降相应的量\n主角情绪下降时'堂吉诃德'血量上升相应的量",                                                     Resources.Load<Sprite>("CardImages/02"), Resources.Load<Sprite>("CardBackgrounds/2"),  false));
        monsterCardList.Add(new MonsterCard(36, "焦虑",       20,  8,  5,  1, "击杀后对相邻的怪物添加两层灼伤",                                                                                                         Resources.Load<Sprite>("CardImages/02"), Resources.Load<Sprite>("CardBackgrounds/2"),  false));



    }                                                       
    public EquipmentCard RandomEquipmentCard()
    {
        EquipmentCard card = CopyEquipmentCard(Random.Range(0, equipmentCardList.Count));
        return card;
    }
    public MonsterCard RandomMonsterCard()
    {
        MonsterCard card = CopyMonsterCard(Random.Range(0, monsterCardList.Count));
        return card;
    }
    public EquipmentCard CopyEquipmentCard(int _id)
    {
        var equipment = equipmentCardList[_id];
        EquipmentCard copyCard = new EquipmentCard(_id, equipment.cardName, equipment.damage,equipment.summonTimes, equipment.description,
               equipment.thisImage,equipment.isStatic);
        return copyCard;
    }
    public MonsterCard CopyMonsterCard(int _id)
    {
        var monster = monsterCardList[_id];
        MonsterCard copyCard = new MonsterCard(_id, monster.cardName, monster.health, monster.damage,monster.award, monster.summonTimes, monster.description, monster.thisImage, monster.thisBackground,monster.isStatic);
        return copyCard;

    }
}
