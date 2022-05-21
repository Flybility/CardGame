using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Equipment26 : MonoBehaviour
{
    public bool isInEquipment;
    public MouseInteraction mi;
    public ThisEquiptmentCard card;
    public int count;//层数
    public int threshold;//临界值
    // Start is called before the first frame update
    void Start()
    {
        mi = GetComponent<MouseInteraction>();
        isInEquipment = mi.isInEquipment;
        card = GetComponent<ThisEquiptmentCard>();
        if (isInEquipment)
        {
           Skills.Instance.StaticAngerCount(0,4);//传入层数，临界值，大于4点增加一层愤怒
            PlayerData.Instance.isAngerCountOpen = true; ;
        }
    }
    private void Update()
    {
        
    }
    private void OnDestroy()
    {
 
        PlayerData.Instance.isAngerCountOpen = false;

    }
}
