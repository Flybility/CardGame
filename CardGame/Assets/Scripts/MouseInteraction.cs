using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

public class MouseInteraction : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler, IPointerUpHandler
{
    public float zoomSize;
    public float clickSize;
    public bool isInOpenMonsterPool;
    public bool isInOpenEquipmentPool;
    public bool isInBattle;
    public bool isInDiscard;
    public bool isInExtract;
    public bool isInEquipment;
    public bool isInBag;
    private bool clicked;
    public int number;
    ThisEquiptmentCard thisCard1;
    ThisMonsterCard thisCard2;



    public float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        number = transform.GetSiblingIndex();
        clicked = false;
        isInOpenMonsterPool = transform.parent.CompareTag("OpenMonsterPool");
        isInOpenEquipmentPool = transform.parent.CompareTag("OpenEquipmentPool");
        isInBattle= transform.parent.CompareTag("BattleMonsterPanel");
        isInEquipment = transform.parent.CompareTag("BattleEquipmentPanel");
        isInBag= transform.parent.CompareTag("Bag");
        if (GetComponent<ThisEquiptmentCard>() != null)
        {
            thisCard1 = GetComponent<ThisEquiptmentCard>();
            
        }
        if (GetComponent<ThisMonsterCard>() != null)
        {
            thisCard2 = GetComponent<ThisMonsterCard>();
           
        }
        BattleField.Instance.summonEvent.AddListener(OnSummonOver);
        BattleField.Instance.ChangeParent.AddListener(OnChangeParent);
    }

    // Update is called once per frame
    void Update()
    {
        number = transform.GetSiblingIndex();
        //右键取消召唤
        if (Input.GetMouseButtonUp(1) && clicked == true)
        {
            transform.localScale = Vector3.one;
            clicked = false;
            BattleField.Instance.SummonCancel();
        }
    }
    public void OnChangeParent()
    {
        isInBattle = transform.parent.CompareTag("BattleMonsterPanel");
        isInExtract = transform.parent.CompareTag("BattleExtractPanel");
        isInDiscard = transform.parent.CompareTag("BattleDiscardPanel");
        isInEquipment = transform.parent.CompareTag("BattleEquipmentPanel");
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale (zoomSize,0.1f);
        AudioManager.Instance.choseCard.Play();
        if (GetComponent<ThisEquiptmentCard>() != null)
        {
            CursorFollow.Instance.description.SetActive(true);
            Color color = CursorFollow.Instance.description.GetComponent<Image>().color;
            CursorFollow.Instance.description.GetComponent<Image>().DOColor(new Color(color.r, color.g, color.b, 0.7f), 0.5f);
            Invoke("ShowDescriptionEquipment", 0.1f);
        }
        if (GetComponent<ThisMonsterCard>() != null)
        {
            CursorFollow.Instance.description.SetActive(true);
            Color color = CursorFollow.Instance.description.GetComponent<Image>().color;
            CursorFollow.Instance.description.GetComponent<Image>().DOColor(new Color(color.r, color.g, color.b, 0.7f), 0.5f);
            Invoke("ShowDescriptionMonster", 0.1f);
        }
        
    }
    public void ShowDescriptionEquipment()
    {
        CursorFollow.Instance.description.transform.GetChild(0).GetComponent<Text>().text = thisCard1.cardName + ":" + "\n" + thisCard1.description;       
    }
    public void ShowDescriptionMonster()
    {
        CursorFollow.Instance.description.transform.GetChild(0).GetComponent<Text>().text = thisCard2.cardName+":"+ "\n" + thisCard2.description;
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        CursorFollow.Instance.description.SetActive(false);
        if (isInBattle && clicked)
        {
            return;
        }
        else
        {
            transform.DOScale(Vector3.one, 0.1f);
        }
        if (isInBag&&thisCard1!=null)
        {
            Cancel();
        }

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        { 
            transform.DOScale(clickSize, 0.1f);
            AudioManager.Instance.click.Play();
        }

    }
    public void OnPointerUp(PointerEventData eventData)
    {
        //当在战场手牌里和怪物当前可召唤数量大于0和是否已经点击召唤为false和点击鼠标左键和战斗状态为玩家回合时才可召唤
        if (isInBattle && BattleField.Instance.monstersCounter < 6 &&clicked==false&& eventData.button == PointerEventData.InputButton.Left&&BattleField.Instance.gameState==GameState.玩家回合)
        {
            transform.DOScale(zoomSize, 0.1f);
            clicked = true;
            BattleField.Instance.PanelMask.SetActive(true);
            BattleField.Instance.SummonRequest(gameObject);
        }
        if (isInOpenMonsterPool&&eventData.button == PointerEventData.InputButton.Left)
        {
            transform.DOScale(zoomSize, 0.1f);
            //向玩家怪物卡组加入选中的怪物牌
            PlayerData.Instance.playerMonsterCards.Add(thisCard2.card);
            //点击卡包里的卡之后其他卡牌消失
            foreach(var monster in OpenPackage.Instance.cardsMonster)
            {
                Destroy(monster);
            }
            OpenPackage.Instance.cardsMonster.Clear();
            //开卡包界面消失
            GameManager.Instance.openMonsterCard.SetActive(false);
            //选完怪物卡选装备卡
            GameManager.Instance.openEquipmentCard.SetActive(true);
            OpenPackage.Instance.OpenEquiptmentCard(PlayerData.Instance.awardEquipCardAmount);
           
        }
        if (isInOpenEquipmentPool&&eventData.button == PointerEventData.InputButton.Left)
        {
            transform.DOScale(1 / clickSize, 0.1f);
            //向玩家装备卡组加入选中的装备牌并实时显示在装备栏中
            PlayerData.Instance.playerEquipmentCards.Add(thisCard1.card);
            BattleField.Instance.AddEquipmentCard(thisCard1.card);
            foreach (var equip in OpenPackage.Instance.cardsEquiptment)
            {
                Destroy(equip);
            }
            OpenPackage.Instance.cardsEquiptment.Clear();
            //开卡包界面消失
            GameManager.Instance.openEquipmentCard.SetActive(false);
        }
        if (isInBag && eventData.button == PointerEventData.InputButton.Right && thisCard1 != null)
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }


    }
    public void DiscardEquipment()
    {
        if (BattleField.Instance.isFinished == false)
        {
            BattleField.Instance.cardsEquiptment.Remove(this.gameObject);
        }
        PlayerData.Instance.playerEquipmentCards.Remove(this.GetComponent<ThisEquiptmentCard>().card);
        Destroy(this.gameObject,0.2f);
    }
    public void Cancel()
    {
        transform.GetChild(1).gameObject.SetActive(false);
    }
    public void OnSummonOver()
    {
        transform.localScale = Vector3.one;
        clicked =false;
        BattleField.Instance.PanelMask.SetActive(false);
        //if (BattleField.Instance.chosenCardNumber == number&&isInBattle)
        //{
        //    transform.SetParent()
        //}
    }
    
}
