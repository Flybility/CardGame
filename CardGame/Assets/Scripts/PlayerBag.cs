using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerBag : MonoSingleton<PlayerBag>
{
    public List<GameObject> monster = new List<GameObject>();
    public List<GameObject> equipment = new List<GameObject>();
    private List<MonsterCard> monsterDeck = new List<MonsterCard>();
    public GameObject monsterCardPrefab;
    public GameObject equipmentCardPrefab;
    public Transform armedEquipArea;
    public Transform cardArea;
    public Transform equipmentArea;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartShowPlayerMonsters()
    {
        transform.parent.gameObject.SetActive(true);
        ShowPlayerMonsters();
    }
    public void ShowPlayerMonsters()
    {
        ReadMonsterDeck();
        if (equipment.Count!=0)
        {
            foreach (var equip in equipment)
            {
                Destroy(equip);
            }
            equipment.Clear();
        }
        if (monster.Count != 0)
        {
            foreach (var mons in monster)
            {
                Destroy(mons);
            }
            monster.Clear();
        }
        for (int i = 0; i < monsterDeck.Count; i++)
        {
            //Debug.Log(monsterDeck.Count);
            GameObject newCard = GameObject.Instantiate(monsterCardPrefab, cardArea);
            newCard.GetComponent<ThisMonsterCard>().card = monsterDeck[i];
            monster.Add(newCard);
            //newCard.transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0.2f), 0.2f);
            //AudioManager.Instance.cardEnter.Play();

        }
    }
    public void ReadMonsterDeck()
    {
        monsterDeck.Clear();
        for (int i = 0; i < PlayerData.Instance.playerMonsterCards.Count; i++)
        {
            monsterDeck.Add(PlayerData.Instance.playerMonsterCards[i]);
        }
    }
    public void StartShowPlayerEquipments()
    {
        transform.parent.gameObject.SetActive(true);
        ShowPlayerEquipments();
    }
    public void ShowPlayerEquipments()
    {
       if (monster .Count!= 0)
       {
           foreach (var mons in monster)
           {
               Destroy(mons);
           }
           monster.Clear();
       }
        if (equipment.Count== 0)
        {
            for (int i = 0; i < PlayerData.Instance.playerEquipmentCards.Count; i++)
            {
                int id = PlayerData.Instance.playerEquipmentCards[i].id;
                GameObject newCard = GameObject.Instantiate(equipmentCardPrefab.transform.GetChild(id).gameObject, equipmentArea);
                equipment.Add(newCard);
                newCard.GetComponent<ThisEquiptmentCard>().card = PlayerData.Instance.playerEquipmentCards[i];
                //newCard.transform.DOPunchScale(new Vector3(0.3f, 0.3f, 0.3f), 0.2f);
                //AudioManager.Instance.cardEnter.Play();

            }
        }
        
    }

}
