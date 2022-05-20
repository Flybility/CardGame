using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DiscriptionFloat : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public string discription1, discription2;
    public Text count;//层数
    public void OnPointerEnter(PointerEventData eventData)
    {
        CursorFollow.Instance.description.transform.GetChild(0).GetComponent<Text>().text = discription1+count.text+discription2;
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
        count = transform.GetChild(0).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
