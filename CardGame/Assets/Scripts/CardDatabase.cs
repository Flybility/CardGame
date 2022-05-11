using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoSingleton<CardDatabase>
{
    public  List<EquipmentCard> equipmentCardList = new List<EquipmentCard>();
    public  List<MonsterCard> monsterCardList = new List<MonsterCard>();
    private void Awake()
    {
        equipmentCardList.Add(new EquipmentCard(0, "装备名称1", 2, 10, 5, "装备描述1", Resources.Load<Sprite>("CardImages/1"), Resources.Load<Sprite>("CardBackgrounds/1")));
        equipmentCardList.Add(new EquipmentCard(1, "装备名称2", 2, 10, 5, "装备描述2", Resources.Load<Sprite>("CardImages/1"), Resources.Load<Sprite>("CardBackgrounds/2")));
        equipmentCardList.Add(new EquipmentCard(2, "装备名称3", 2, 10, 5, "装备描述3", Resources.Load<Sprite>("CardImages/2"), Resources.Load<Sprite>("CardBackgrounds/2")));
        equipmentCardList.Add(new EquipmentCard(3, "装备名称4", 2, 10, 5,"装备描述4", Resources.Load<Sprite>("CardImages/2"), Resources.Load<Sprite>("CardBackgrounds/1")));

        monsterCardList.Add(new MonsterCard(0, "怪物名称1", 1, 10, 3, "怪物描述1", Resources.Load<Sprite>("CardImages/1"), Resources.Load<Sprite>("CardBackgrounds/1"),20));
        monsterCardList.Add(new MonsterCard(1, "怪物名称2", 1, 10, 3, "怪物描述2", Resources.Load<Sprite>("CardImages/1"), Resources.Load<Sprite>("CardBackgrounds/2"),20));
        monsterCardList.Add(new MonsterCard(2, "怪物名称3", 1, 10, 3, "怪物描述3", Resources.Load<Sprite>("CardImages/2"), Resources.Load<Sprite>("CardBackgrounds/1"), 20));
        monsterCardList.Add(new MonsterCard(3, "怪物名称4", 1, 10, 3, "怪物描述4", Resources.Load<Sprite>("CardImages/2"), Resources.Load<Sprite>("CardBackgrounds/2"), 20));
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
        EquipmentCard copyCard = new EquipmentCard(_id, equipment.cardName, equipment.cost, equipment.damage,equipment.summonTimes, equipment.description,
               equipment.thisImage, equipment.thisBackground);
        return copyCard;
    }
    public MonsterCard CopyMonsterCard(int _id)
    {
        var monster = monsterCardList[_id];
        MonsterCard copyCard = new MonsterCard(_id, monster.cardName, monster.cost, monster.damage, monster.summonTimes, monster.description, monster.thisImage, monster.thisBackground,monster.health);
        return copyCard;

    }
}
