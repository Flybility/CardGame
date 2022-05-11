using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.EventSystems;
using TMPro;

public class ThisEquiptmentCard : MonoBehaviour
{
    public int thisId;

    public int id;
    public string cardName;
    public int cost;
    public int damage;
    public int summonTimes;
    public string description;
    public string effect;

    public Sprite thisSprite;
    public Image thatImage;

    public bool cardBack;
    public EquipmentCard card;

    public TextMeshProUGUI summonTimesText;
    //public TextMeshProUGUI costText;
    //public TextMeshProUGUI cardNameText;
    //public TextMeshProUGUI damageText;
    //public TextMeshProUGUI descriptionText;
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

        var equipment = card as EquipmentCard;
        id = equipment.id;
        cardName = equipment.cardName;
        cost = equipment.cost;
        description = equipment.description;
        thisSprite = equipment.thisImage;


        //cardNameText.text = "" + cardName;
        //costText.text = "" + cost;
        //descriptionText.text = "" + description;

        thatImage.sprite = thisSprite;
    }
    public void ShowCardDynamicStatus()
    {
        var equipment = card as EquipmentCard;
        damage = equipment.damage;
        summonTimes = equipment.summonTimes;
        //damageText.text = "" + damage;
        summonTimesText.text = "" + summonTimes;
    }
}