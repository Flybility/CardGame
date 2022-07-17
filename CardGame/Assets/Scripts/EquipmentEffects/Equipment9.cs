using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment9 : MonoBehaviour
{
    public bool isInEquipment;
    public MouseInteraction mi;
    public ThisEquiptmentCard card;
    public int count;//层数
    public int initialDamage;
    // Start is called before the first frame update
    void Start()
    {
        mi = GetComponent<MouseInteraction>();
        isInEquipment = mi.isInEquipment;
        card = GetComponent<ThisEquiptmentCard>();
        initialDamage = PlayerData.Instance.burnsDamageMonster;
        if (isInEquipment)
        {
            PlayerData.Instance.burnsDamageMonster = initialDamage+count;
        }

    }
    private void OnDestroy()
    {
        if (isInEquipment)
        {
            PlayerData.Instance.burnsDamageMonster = initialDamage;
        }
    }
}
