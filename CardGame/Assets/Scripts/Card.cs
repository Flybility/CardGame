using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class EquipmentCard
{
    public int id;
    public string cardName;
    public int cost;
    public int damage;
    public int summonTimes;
    public string description;
    public Sprite thisImage;
    public Sprite thisBackground;

    public EquipmentCard()
    {

    }
    public EquipmentCard(int Id, string CardName, int Cost, int Damage, int SummonTimes,string CardDescription, Sprite ThisImage, Sprite ThisBackground)
    {
        this.id = Id;
        this.cardName = CardName;
        this.cost = Cost;
        this.damage = Damage;
        this.summonTimes = SummonTimes;
        this.description = CardDescription;
        this.thisImage = ThisImage;
        this.thisBackground = ThisBackground;
    }

}
public class MonsterCard : EquipmentCard
{
    public int health;
    public MonsterCard()
    {

    }
    public MonsterCard(int Id, string CardName, int Cost, int Damage, int SummonTimes,string CardDescription, Sprite ThisImage,
        Sprite ThisBackground, int Health) : base(Id, CardName, Cost, Damage,SummonTimes, CardDescription, ThisImage, ThisBackground)
    {
        this.health = Health;
    }
}

