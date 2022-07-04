using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveArrow : MonoBehaviour
{
    public ThisMonster mCard;
    private Transform nextPos ;
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        mCard = transform.GetComponentInParent<ThisMonster>();
        Skills.Instance.reverse.AddListener(ChangeDirection);  
        nextPos = BlocksManager.Instance.GetNextBlock(mCard.block).transform; 
        dir= nextPos.transform.localPosition - mCard.block.localPosition;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;
    }

    public void ChangeDirection()
    {
       
        if (mCard.isCW)
        {
            nextPos = BlocksManager.Instance.GetNextBlock(mCard.block).transform;  
        }
        else
        {
            nextPos = BlocksManager.Instance.GetPreviousBlock(mCard.block).transform;
        }

        dir = nextPos.transform.localPosition - mCard.block.localPosition;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);
        transform.rotation = rotation;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
