using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.EventSystems;

public class ThisMonsterCard : MonoBehaviour
{
    public int thisId;

    public int id;
    public string cardName;
    public int damage;
    public int summonTimes;
    public int health;
    public int award;
    public string description;
    public string effect;

    public Sprite thisSprite;
    public Image thatImage;
    public Sprite thisBackground;
    public Image thatBackground;

    public MonsterCard card;

    public Text summonTimesText;
    public Text healthText;
    public Text awardText;
    public Text cardNameText;
    public Text damageText;
    public Text descriptionText;
    // Start is called before the first frame update
    void Start()
    {
        ShowCardStaticStatus();
    }

    // Update is called once per frame
    void Update()
    {
        ShowCardDynamicStatus();

    }
    public void ShowCardStaticStatus()
    {

        var monster = card as MonsterCard;
        id = monster.id;
        cardName = monster.cardName;
        description = monster.description;
        thisSprite = monster.thisImage;
        thisBackground = monster.thisBackground;

        damage = monster.damage;
        summonTimes = monster.summonTimes;
        health = monster.health;
        award = monster.award;


        cardNameText.text = "" + cardName;    
        descriptionText.text = "" + description;

        thatImage.sprite = thisSprite;
        thatBackground.sprite = thisBackground;
    }
    public void ShowCardDynamicStatus()
    {
       
        damageText.text = "" + damage;
        healthText.text = "" + health;
        awardText.text = "" + award;
        summonTimesText.text = "" + summonTimes;
    }
}
