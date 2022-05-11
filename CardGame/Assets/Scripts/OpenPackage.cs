using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPackage : MonoBehaviour
{
    public GameObject eqiupmentCardPrefab;
    public GameObject monsterCardPrefab;
    public GameObject cardPoolEquiptment;
    public GameObject cardPoolMonster;

    CardDatabase cardData;
    public List<GameObject> cardsEquiptment = new List<GameObject>();
    public List<GameObject> cardsMonster = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        cardData = GetComponent<CardDatabase>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //开装备卡包
    public void OpenEquiptmentCard()
    {
        ClearPoolEquiptment();
        for (int i = 0; i < 4; i++)
        {
            GameObject newCard = GameObject.Instantiate(eqiupmentCardPrefab,cardPoolEquiptment.transform);
            newCard.GetComponent<ThisEquiptmentCard>().card = cardData.RandomEquipmentCard();
            cardsEquiptment.Add(newCard);
        }
        //SaveCardData();
    }
    //开怪物卡包
    public void OpenMonsterCard()
    {
        ClearPoolMonster();
        for (int i = 0; i < 4; i++)
        {
            GameObject newCard = GameObject.Instantiate(monsterCardPrefab, cardPoolMonster.transform);
            newCard.GetComponent<ThisMonsterCard>().card = cardData.RandomMonsterCard();
            cardsMonster.Add(newCard);
        }
        //SaveCardData();
    }
    //清除现有装备卡牌包
    public void ClearPoolEquiptment()
    {
        foreach(var card in cardsEquiptment)
        {
            Destroy(card);
        }
        cardsEquiptment.Clear();
    }
    //清除现有怪物卡牌包
    public void ClearPoolMonster()
    {
        foreach (var card in cardsMonster)
        {
            Destroy(card);
        }
        cardsMonster.Clear();
    }
   //public void SaveCardData()
   //{
   //    foreach(var card in cardsEquiptment)
   //    {
   //        int idE = card.GetComponent<ThisEquiptmentCard>().card.id;
   //    }
   //    foreach(var card in cardsMonster)
   //    {
   //        int idM = card.GetComponent<ThisMonsterCard>().card.id;
   //    }
   //}
}
