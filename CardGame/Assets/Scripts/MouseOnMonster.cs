using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class MouseOnMonster : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{
    ThisMonster thismonster;
    // Start is called before the first frame update
    void Start()
    {
        thismonster = transform.parent.GetComponent<ThisMonster>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left && BattleField.Instance.SelectingMonster != 1 && BattleField.Instance.usingEquipment == null && BattleField.Instance.AttackSelecting)
        {
            BattleField.Instance.StartPlayerAttack(thismonster.gameObject);
            //BattleField.Instance.CloseHighlightWithinMonster();
        }
        if (eventData.button == PointerEventData.InputButton.Left && BattleField.Instance.usingEquipment != null)
        {
            BattleField.Instance.UseEquipment(thismonster.gameObject, BattleField.Instance.usingEquipment);
            //BattleField.Instance.usingEquipment = null;
        }
        if(eventData.button == PointerEventData.InputButton.Left && BattleField.Instance.exchangeMonster==true&& BattleField.Instance.usingEquipment == null&& BattleField.Instance.SelectingMonster != 1)
        {
            BattleField.Instance.ExchangeMonster(thismonster.gameObject);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //transform.DOScale(1.1f ,0.1f);
        Invoke("ShowDescription", 0.1f);
        CursorFollow.Instance.description.SetActive(true);
        Color color = CursorFollow.Instance.description.GetComponent<Image>().color;
        CursorFollow.Instance.description.GetComponent<Image>().DOColor(new Color(color.r, color.g, color.b, 0.7f), 0.4f);
    }
    public void ShowDescription()
    {
        CursorFollow.Instance.description.transform.GetChild(0).GetComponent<Text>().text =thismonster.monsterCard.GetComponent<ThisMonsterCard>().cardName + ":" + "\n" + thismonster.monsterCard.GetComponent<ThisMonsterCard>().card.description + "\n\n" + "?????????????????????:" + "<b>" + "<color=blue>" + thismonster.currentAwards + "</color>" + "</b>";
        if (thismonster.absorbCount > 0)
        {
            CursorFollow.Instance.description.transform.GetChild(0).GetComponent<Text>().text = thismonster.monsterCard.GetComponent<ThisMonsterCard>().cardName + ":" + "\n" + thismonster.monsterCard.GetComponent<ThisMonsterCard>().card.description + "\n" + "?????????????????????:" + "<b>" + "<color=blue>" + thismonster.currentAwards + "</color>" + "</b>" + "\n"
                + "?????????????????????:" + "<b>" + "<color=red>" + thismonster.absorbDamages + "</color>" + "</b>";
        }
        else if (thismonster.isAddAttack)
        {
            CursorFollow.Instance.description.transform.GetChild(0).GetComponent<Text>().text = thismonster.monsterCard.GetComponent<ThisMonsterCard>().cardName + ":" + "\n" + thismonster.monsterCard.GetComponent<ThisMonsterCard>().card.description + "\n" + "?????????????????????:" + "<b>" + "<color=blue>" + thismonster.currentAwards + "</color>" + "</b>" + "\n"
               + "????????????:" + "<b>" + "<color=red>" + thismonster.attackCount + "</color>" + "</b>" + "???";
        }
        else if (thismonster.isAddAward)
        {
            CursorFollow.Instance.description.transform.GetChild(0).GetComponent<Text>().text = thismonster.monsterCard.GetComponent<ThisMonsterCard>().cardName + ":" + "\n" + thismonster.monsterCard.GetComponent<ThisMonsterCard>().card.description + "\n" + "?????????????????????:" + "<b>" + "<color=blue>" + thismonster.currentAwards + "</color>" + "</b>" +
              "*????????????????????????(" + "<b>" + "<color=red>" + BattleField.Instance.perRoundDead + "</color>" + "</b>" + ")";
        }



    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //transform.DOScale(1, 0.1f);
        CursorFollow.Instance.description.transform.GetChild(0).GetComponent<Text>().text = null;
        CursorFollow.Instance.description.SetActive(false);
    }
}
