using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class DiscriptionFloat : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public string discription1, discription2;
    public Text count;//层数
    private bool havecount;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Color color = CursorFollow.Instance.description.GetComponent<Image>().color;
        CursorFollow.Instance.description.GetComponent<Image>().DOColor(new Color(color.r, color.g, color.b, 1), 0.5f);
        if (havecount) { CursorFollow.Instance.description.transform.GetChild(0).GetComponent<Text>().text = discription1 + count.text + discription2; }
        else { CursorFollow.Instance.description.transform.GetChild(0).GetComponent<Text>().text = discription1 ; }
       
        CursorFollow.Instance.description.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CursorFollow.Instance.description.transform.GetChild(0).GetComponent<Text>().text = null;
        CursorFollow.Instance.description.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.DOPunchScale(new Vector3(0.4f, 0.4f, 0.4f), 0.3f);
        
                
            if (transform.GetChild(0).GetComponent<Text>() != null)
            {
                havecount = true;
                count = transform.GetChild(0).GetComponent<Text>();       
            }
            
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
