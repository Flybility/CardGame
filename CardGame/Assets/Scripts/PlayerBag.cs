using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerBag : MonoBehaviour
{
    public List<GameObject> objects = new List<GameObject>();
    private List<MonsterCard> monsterDeck = new List<MonsterCard>();
    public GameObject monsterCardPrefab;
    public GameObject equipmentCardPrefab;
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
        StartCoroutine(ShowPlayerMonsters());
    }
    IEnumerator ShowPlayerMonsters()
    {
        ReadMonsterDeck();
        if (objects != null)
        {
            foreach (var Monster in objects)
            {
                Destroy(Monster);
            }
            objects.Clear();
        }
        
        for (int i = 0; i < monsterDeck.Count; i++)
        {
            //Debug.Log(monsterDeck.Count);
            GameObject newCard = GameObject.Instantiate(monsterCardPrefab, transform);
            newCard.GetComponent<ThisMonsterCard>().card = monsterDeck[i];
            objects.Add(newCard);
            newCard.transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0.2f), 0.2f);
            yield return new WaitForSeconds(0.1f);
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
        StartCoroutine(ShowPlayerEquipments());
    }
    IEnumerator ShowPlayerEquipments()
    {
        if (objects != null)
        {
            foreach (var equip in objects)
            {
                Destroy(equip);
            }
            objects.Clear();
        }
        for (int i = 0; i < PlayerData.Instance.playerEquipmentCards.Count; i++)
        {
            int id = PlayerData.Instance.playerEquipmentCards[i].id;
            GameObject newCard = GameObject.Instantiate(equipmentCardPrefab.transform.GetChild(id).gameObject, transform);
            objects.Add(newCard);
            newCard.GetComponent<ThisEquiptmentCard>().card = PlayerData.Instance.playerEquipmentCards[i];
            newCard.transform.DOPunchScale(new Vector3(0.3f, 0.3f, 0.3f), 0.2f);
            yield return new WaitForSeconds(0.1f);
        }
    }

}
