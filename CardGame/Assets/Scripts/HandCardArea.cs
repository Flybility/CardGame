using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HandCardArea : MonoSingleton<HandCardArea>
{
    //public GridLayoutGroup glg;
    public List<GameObject> childs = new List<GameObject>();
    public float width;
    public float cardWidth;

    private void Start()
    {
        //glg = GetComponent<GridLayoutGroup>();
       
        BattleField.Instance.AddToHand.AddListener(StartChange);
        
    }
    private void StartChange()
    {
        
        StartCoroutine(ChangeHandCard());
    }
    IEnumerator ChangeHandCard()
    {

        int childAmount = transform.childCount;
        float cardwidth = cardWidth * Mathf.Log(6, childAmount + 1);

        
        width = (childAmount - 1) * cardwidth;

        float leftPosX = -width / 2;
        childs.Clear();
        for (int i = 0; i < childAmount; i++)
        {
            Transform card = transform.GetChild(i);
            Vector2 pos = new Vector2(leftPosX + cardwidth * i, 0);
            card.transform.DOLocalMove(pos, 0.2f);
            card.transform.DOScale(Vector3.one, 0.2f);
            //if (card != null)
            //{
            //    card.transform.DOPunchScale(new Vector3(0.3f, 0.3f, 0.3f), 0.25f);
            //}
            childs.Add(transform.GetChild(i).gameObject);

        }

        yield return new WaitForSeconds(0.2f);
        AudioManager.Instance.cardEnter.Play();
        
    }
   //IEnumerator OnPointerEnterCard(GameObject card)
   //{
   //
   //}
}
