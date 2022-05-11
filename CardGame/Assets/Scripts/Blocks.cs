using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class Blocks : MonoBehaviour, IPointerClickHandler
{
    public GameObject card;
    public GameObject highLightImage;

    void Start()
    {
        highLightImage = transform.GetChild(0).gameObject;
        highLightImage.SetActive(false);
        BattleField.Instance.highlightClear.AddListener(HighlightClear);
        //BattleField.Instance.BattleEnd.AddListener(ClearMonster);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (highLightImage.activeInHierarchy&& eventData.button == PointerEventData.InputButton.Left)
        {
            BattleField.Instance.SummonConfirm(transform);            
        }
    }

    // Start is called before the first frame update
   
    public void HighlightClear()
    {
        highLightImage.SetActive(false);
    }
   //public void ClearMonster()
   //{
   //    if (transform.childCount>1)
   //    {
   //        card = null;
   //        Destroy(transform.GetChild(1));
   //        Destroy(transform.GetChild(2));
   //    }
   //    else return;
   //}

    // Update is called once per frame
    void Update()
    {

    }
}
