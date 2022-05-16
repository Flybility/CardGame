using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoSingleton<CardDatabase>
{
    public  List<EquipmentCard> equipmentCardList = new List<EquipmentCard>();
    public  List<MonsterCard> monsterCardList = new List<MonsterCard>();
    private void Awake()
    {
        equipmentCardList.Add(new EquipmentCard(0, "装备名称1", 10, 1, "装备描述1", Resources.Load<Sprite>("CardImages/1"), Resources.Load<Sprite>("CardBackgrounds/1")));
        equipmentCardList.Add(new EquipmentCard(1, "装备名称2", 10, 2, "装备描述2", Resources.Load<Sprite>("CardImages/1"), Resources.Load<Sprite>("CardBackgrounds/2")));
        equipmentCardList.Add(new EquipmentCard(2, "装备名称3", 10, 3, "装备描述3", Resources.Load<Sprite>("CardImages/2"), Resources.Load<Sprite>("CardBackgrounds/2")));
        equipmentCardList.Add(new EquipmentCard(3, "装备名称4", 10, 4,"装备描述4", Resources.Load<Sprite>("CardImages/2"), Resources.Load<Sprite>("CardBackgrounds/1")));
        equipmentCardList.Add(new EquipmentCard(4, "装备名称1", 10, 1, "装备描述1", Resources.Load<Sprite>("CardImages/1"), Resources.Load<Sprite>("CardBackgrounds/1")));
        equipmentCardList.Add(new EquipmentCard(5, "装备名称2", 10, 2, "装备描述2", Resources.Load<Sprite>("CardImages/1"), Resources.Load<Sprite>("CardBackgrounds/2")));
        equipmentCardList.Add(new EquipmentCard(6, "装备名称3", 10, 3, "装备描述3", Resources.Load<Sprite>("CardImages/2"), Resources.Load<Sprite>("CardBackgrounds/2")));
        equipmentCardList.Add(new EquipmentCard(7, "装备名称4", 10, 4, "装备描述4", Resources.Load<Sprite>("CardImages/2"), Resources.Load<Sprite>("CardBackgrounds/1")));

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
               equipment.thisImage, equipment.thisBackground);
        return copyCard;
    }
    public MonsterCard CopyMonsterCard(int _id)
    {
        var monster = monsterCardList[_id];
        MonsterCard copyCard = new MonsterCard(_id, monster.cardName, monster.health, monster.damage,monster.award, monster.summonTimes, monster.description, monster.thisImage, monster.thisBackground);
        return copyCard;

    }
}
