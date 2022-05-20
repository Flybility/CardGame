using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ThisEquiptmentCard : MonoBehaviour
{
    public int thisId;

    public int id;
    public string cardName;
    public int damage;
    public int summonTimes;
    public string description;
    public string effect;
    public bool isStatic;
    public bool needAim;

    public Sprite thisSprite;
    public Image thatImage;

    public bool cardBack;
    public EquipmentCard card;

    public Text summonTimesText;
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
        description = equipment.description;
        thisSprite = equipment.thisImage;
        damage = equipment.damage;
        summonTimes = equipment.summonTimes;

        //cardNameText.text = "" + cardName;
        //costText.text = "" + cost;
        //descriptionText.text = "" + description;

        thatImage.sprite = thisSprite;
    }
    public void ShowCardDynamicStatus()
    {
        
        //damageText.text = "" + damage;
        summonTimesText.text = "" + summonTimes;
    }
}