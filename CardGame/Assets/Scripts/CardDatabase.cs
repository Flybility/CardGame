using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoSingleton<CardDatabase>
{
    public  List<EquipmentCard> equipmentCardList = new List<EquipmentCard>();
    public  List<MonsterCard> monsterCardList = new List<MonsterCard>();
    private void Awake()
    {
        equipmentCardList.Add(new EquipmentCard(0, "蓝宝石", 10, 10, "使相邻位置的心魔互换", Resources.Load<Sprite>("EquipmentImages/1")));
        equipmentCardList.Add(new EquipmentCard(1, "紫宝石", 10, 10, "使相间位置的心魔互换", Resources.Load<Sprite>("EquipmentImages/1")));
        equipmentCardList.Add(new EquipmentCard(2, "红宝石", 10, 10, "下次攻击对目标攻击2次", Resources.Load<Sprite>("EquipmentImages/2")));
        equipmentCardList.Add(new EquipmentCard(3, "橙宝石", 10, 3, "装备描述4", Resources.Load<Sprite>("EquipmentImages/2")));
        equipmentCardList.Add(new EquipmentCard(4, "黄宝石", 10, 3, "装备描述1", Resources.Load<Sprite>("EquipmentImages/1")));
        equipmentCardList.Add(new EquipmentCard(5, "红水晶", 10, 2, "下次攻击对目标攻击3次", Resources.Load<Sprite>("EquipmentImages/1")));
        equipmentCardList.Add(new EquipmentCard(6, "橙水晶", 10, 3, "下次攻击间位获得与被攻击目标同样的伤害", Resources.Load<Sprite>("EquipmentImages/2")));
        equipmentCardList.Add(new EquipmentCard(7, "黄水晶", 10, 4, "下次攻击邻位获得与被攻击目标同样的伤害", Resources.Load<Sprite>("EquipmentImages/2")));        
        equipmentCardList.Add(new EquipmentCard(0, "酒精", 10, 10, "被击中的目标本回合内若受到“爆炸伤害”被添加3层“灼伤”", Resources.Load<Sprite>("EquipmentImages/1")));
        equipmentCardList.Add(new EquipmentCard(1, "燃烧的烟头", 10, 10, "场上所有带有“灼伤”效果的敌人每回合受到的“灼伤”伤害+6，但每触发一次增加1层“恐惧”", Resources.Load<Sprite>("EquipmentImages/1")));
        equipmentCardList.Add(new EquipmentCard(2, "小喇叭", 10, 10, "本回合受到爆炸伤害的心魔被添加1层“眩晕”", Resources.Load<Sprite>("EquipmentImages/2")));
        equipmentCardList.Add(new EquipmentCard(3, "橙宝石", 10, 3, "装备描述4", Resources.Load<Sprite>("EquipmentImages/2")));
        equipmentCardList.Add(new EquipmentCard(4, "黄宝石", 10, 3, "装备描述1", Resources.Load<Sprite>("EquipmentImages/1")));

        monsterCardList.Add(new MonsterCard(00, "愤怒0", 8, 3, 2, 1, "怪物描述1", Resources.Load<Sprite>("CardImages/1"), Resources.Load<Sprite>("CardBackgrounds/1")));
        monsterCardList.Add(new MonsterCard(01, "愤怒0",    8,   3, 2, 1, "怪物描述1", Resources.Load<Sprite>("CardImages/1"), Resources.Load<Sprite>("CardBackgrounds/1")));
        monsterCardList.Add(new MonsterCard(02, "愤怒",     5,   2, 1, 1, "怪物描述2", Resources.Load<Sprite>("CardImages/1"), Resources.Load<Sprite>("CardBackgrounds/2")));
        monsterCardList.Add(new MonsterCard(03, "    ",   12,   4, 6, 3, "怪物描述3", Resources.Load<Sprite>("CardImages/2"), Resources.Load<Sprite>("CardBackgrounds/1")));
        monsterCardList.Add(new MonsterCard(04, "    ",   20,   6, 10,4, "怪物描述4", Resources.Load<Sprite>("CardImages/2"), Resources.Load<Sprite>("CardBackgrounds/2")));
        monsterCardList.Add(new MonsterCard(05, "愤怒0",  10, 3, 2, 1, "怪物描述1", Resources.Load<Sprite>("CardImages/1"), Resources.Load<Sprite>("CardBackgrounds/1")));
        monsterCardList.Add(new MonsterCard(06, "愤怒",   80, 2, 1, 1, "怪物描述2", Resources.Load<Sprite>("CardImages/1"), Resources.Load<Sprite>("CardBackgrounds/2")));
        monsterCardList.Add(new MonsterCard(07, "嘶叫", 10, 4, 6, 3, "怪物描述3", Resources.Load<Sprite>("CardImages/2"), Resources.Load<Sprite>("CardBackgrounds/1")));
        monsterCardList.Add(new MonsterCard(08, "悲伤", 7, 6, 10, 4, "怪物描述4", Resources.Load<Sprite>("CardImages/2"), Resources.Load<Sprite>("CardBackgrounds/2")));
        monsterCardList.Add(new MonsterCard(09, "    ", 7, 3, 2, 1, "怪物描述1", Resources.Load<Sprite>("CardImages/1"), Resources.Load<Sprite>("CardBackgrounds/1")));
        monsterCardList.Add(new MonsterCard(10, "掮客", 7, 2, 1, 1, "怪物描述2", Resources.Load<Sprite>("CardImages/1"), Resources.Load<Sprite>("CardBackgrounds/2")));
        monsterCardList.Add(new MonsterCard(11, "    ", 10, 4, 6, 3, "怪物描述3", Resources.Load<Sprite>("CardImages/2"), Resources.Load<Sprite>("CardBackgrounds/1")));
        monsterCardList.Add(new MonsterCard(12, "    ", 10, 6, 10, 4, "怪物描述4", Resources.Load<Sprite>("CardImages/2"), Resources.Load<Sprite>("CardBackgrounds/2")));
        monsterCardList.Add(new MonsterCard(13, "    ", 10, 3, 2, 1, "怪物描述1", Resources.Load<Sprite>("CardImages/1"), Resources.Load<Sprite>("CardBackgrounds/1")));
        monsterCardList.Add(new MonsterCard(14, "无形", 0, 0, 0, 0, "怪物描述2", Resources.Load<Sprite>("CardImages/1"), Resources.Load<Sprite>("CardBackgrounds/2")));
        monsterCardList.Add(new MonsterCard(15, "    ", 25, 4, 6, 3, "怪物描述3", Resources.Load<Sprite>("CardImages/2"), Resources.Load<Sprite>("CardBackgrounds/1")));
        monsterCardList.Add(new MonsterCard(16, "小丑", 25, 6, 10, 4, "怪物描述4", Resources.Load<Sprite>("CardImages/2"), Resources.Load<Sprite>("CardBackgrounds/2")));
        monsterCardList.Add(new MonsterCard(17, "黑夜", 25, 3, 2, 1, "怪物描述1", Resources.Load<Sprite>("CardImages/1"), Resources.Load<Sprite>("CardBackgrounds/1")));
        monsterCardList.Add(new MonsterCard(18, "蝙蝠", 16, 2, 1, 1, "怪物描述2", Resources.Load<Sprite>("CardImages/1"), Resources.Load<Sprite>("CardBackgrounds/2")));
        monsterCardList.Add(new MonsterCard(19, "小丑", 25, 4, 6, 3, "怪物描述3", Resources.Load<Sprite>("CardImages/2"), Resources.Load<Sprite>("CardBackgrounds/1")));
        monsterCardList.Add(new MonsterCard(20, "    ", 25, 6, 10, 4, "怪物描述4", Resources.Load<Sprite>("CardImages/2"), Resources.Load<Sprite>("CardBackgrounds/2")));
        monsterCardList.Add(new MonsterCard(21, "蜘蛛", 33, 3, 2, 1, "怪物描述1", Resources.Load<Sprite>("CardImages/1"), Resources.Load<Sprite>("CardBackgrounds/1")));
        monsterCardList.Add(new MonsterCard(22, "    ", 40, 2, 1, 1, "怪物描述2", Resources.Load<Sprite>("CardImages/1"), Resources.Load<Sprite>("CardBackgrounds/2")));
        monsterCardList.Add(new MonsterCard(23, "    ", 40, 4, 6, 3, "怪物描述3", Resources.Load<Sprite>("CardImages/2"), Resources.Load<Sprite>("CardBackgrounds/1")));
        monsterCardList.Add(new MonsterCard(24, "    ", 40, 6, 10, 4, "怪物描述4", Resources.Load<Sprite>("CardImages/2"), Resources.Load<Sprite>("CardBackgrounds/2")));
        monsterCardList.Add(new MonsterCard(25, "    ", 70, 2, 1, 1, "怪物描述2", Resources.Load<Sprite>("CardImages/1"), Resources.Load<Sprite>("CardBackgrounds/2")));
        monsterCardList.Add(new MonsterCard(26, "负面本质", 70, 4, 6, 3, "怪物描述3", Resources.Load<Sprite>("CardImages/2"), Resources.Load<Sprite>("CardBackgrounds/1")));
        monsterCardList.Add(new MonsterCard(27, "    ", 70, 6, 10, 4, "怪物描述4", Resources.Load<Sprite>("CardImages/2"), Resources.Load<Sprite>("CardBackgrounds/2")));
        monsterCardList.Add(new MonsterCard(28, "    ", 70, 3, 2, 1, "怪物描述1", Resources.Load<Sprite>("CardImages/1"), Resources.Load<Sprite>("CardBackgrounds/1")));
        monsterCardList.Add(new MonsterCard(29, "    ", 20, 2, 1, 1, "怪物描述2", Resources.Load<Sprite>("CardImages/1"), Resources.Load<Sprite>("CardBackgrounds/2")));
        monsterCardList.Add(new MonsterCard(30, "狡猾1", 25, 4, 6, 3, "怪物描述3", Resources.Load<Sprite>("CardImages/2"), Resources.Load<Sprite>("CardBackgrounds/1")));
        monsterCardList.Add(new MonsterCard(31, "狡猾2", 40, 6, 10, 4, "怪物描述4", Resources.Load<Sprite>("CardImages/2"), Resources.Load<Sprite>("CardBackgrounds/2"))); 
        monsterCardList.Add(new MonsterCard(32, "贪婪1", 10, 2, 1, 1, "怪物描述2", Resources.Load<Sprite>("CardImages/1"), Resources.Load<Sprite>("CardBackgrounds/2")));
        monsterCardList.Add(new MonsterCard(33, "贪婪2", 35, 4, 6, 3, "怪物描述3", Resources.Load<Sprite>("CardImages/2"), Resources.Load<Sprite>("CardBackgrounds/1")));
        monsterCardList.Add(new MonsterCard(34, "孵化者", 160, 6, 10, 4, "怪物描述4", Resources.Load<Sprite>("CardImages/2"), Resources.Load<Sprite>("CardBackgrounds/2"))); 
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
               equipment.thisImage);
        return copyCard;
    }
    public MonsterCard CopyMonsterCard(int _id)
    {
        var monster = monsterCardList[_id];
        MonsterCard copyCard = new MonsterCard(_id, monster.cardName, monster.health, monster.damage,monster.award, monster.summonTimes, monster.description, monster.thisImage, monster.thisBackground);
        return copyCard;

    }
}
