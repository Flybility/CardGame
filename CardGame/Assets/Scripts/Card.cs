using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class EquipmentCard
{
    public int id;
    public string cardName;
    public int damage;
    public int summonTimes;
    public string description;
    public Sprite thisImage;

    public EquipmentCard()
    {

    }
    public EquipmentCard(int Id, string CardName, int Damage, int SummonTimes,string CardDescription, Sprite ThisImage)
    {
        this.id = Id;
        this.cardName = CardName;
        this.damage = Damage;
        this.summonTimes = SummonTimes;
        this.description = CardDescription;
        this.thisImage = ThisImage;
    }

}
public class MonsterCard : EquipmentCard
{
    public int health;
    public int award;
    public Sprite thisBackground;
    public MonsterCard()
    {

    }
    public MonsterCard(int Id, string CardName,int Health,int Damage,int Award, int SummonTimes,string CardDescription, Sprite ThisImage,
        Sprite ThisBackground) : base(Id, CardName, Damage,SummonTimes, CardDescription, ThisImage)
    {
        this.health = Health;
        this.award = Award;
        this.thisBackground = ThisBackground;
    }
}

