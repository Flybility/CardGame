using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.EventSystems;
using TMPro;

public class ThisMonsterCard : MonoBehaviour
{
    public int thisId;

    public int id;
    public string cardName;
    public int cost;
    public int damage;
    public int summonTimes;
    public int health;
    public string description;
    public string effect;

    public Sprite thisSprite;
    public Image thatImage;
    public Sprite thisBackground;
    public Image thatBackground;

    public MonsterCard card;

    public TextMeshProUGUI summonTimesText;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI healthText; 
    public TextMeshProUGUI cardNameText;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI descriptionText;
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
        cost = monster.cost;
        description = monster.description;
        thisSprite = monster.thisImage;
        thisBackground = monster.thisBackground;


        cardNameText.text = "" + cardName;
        costText.text = "" + cost;        
        descriptionText.text = "" + description;

        thatImage.sprite = thisSprite;
        thatBackground.sprite = thisBackground;
    }
    public void ShowCardDynamicStatus()
    {
        var monster = card as MonsterCard;
        damage = monster.damage;
        summonTimes = monster.summonTimes;
        health = monster.health;
        damageText.text = "" + damage;
        healthText.text = "" + health;
        summonTimesText.text = "" + summonTimes;
    }
}
