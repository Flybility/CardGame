using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HandCardArea : MonoSingleton<HandCardArea>
{
    //public GridLayoutGroup glg;
    public List<GameObject> childs = new List<GameObject>();
    private float width;
    public float cardWidth;

    private void Start()
    {
        //glg = GetComponent<GridLayoutGroup>();
       
        BattleField.Instance.AddToHand.AddListener(StartChange);
        
    }
    private void StartChange(GameObject card)
    {
        
        StartCoroutine(ChangeHandCard(card));
    }
    IEnumerator ChangeHandCard(GameObject card)
    {
        
        int childAmount = transform.childCount;
        
        //
        width = (childAmount-1) * cardWidth;

        float leftPosX = -width / 2;
        childs.Clear();
        for (int i = 0; i < childAmount; i++)
        {
            Vector2 pos = new Vector2(leftPosX + cardWidth * i, 0);
            transform.GetChild(i).transform.DOLocalMove(pos, 0.2f);
            transform.GetChild(i).transform.DOScale(Vector3.one, 0.2f);
            if (card != null)
            {
                card.transform.DOPunchScale(new Vector3(0.3f, 0.3f, 0.3f), 0.25f);
            }
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
