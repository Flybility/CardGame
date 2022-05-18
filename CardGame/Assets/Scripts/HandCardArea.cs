using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HandCardArea : MonoBehaviour
{
    public Vector2 spot;
    public Vector2 thisPos;
    public List<Transform> childs;
    public Vector2 distant;

    // Start is called before the first frame update
    void Start()
    {
        thisPos = transform.position;
        distant = thisPos - spot;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount>0)
        {
            CheckChilds();
        }
    }
    public void CheckChilds()
    {
        childs.Clear();
        for(int i = 0; i < transform.childCount; i++)
        {
            childs.Add(transform.GetChild(i));
        }
        TransformChild();
    }
    public void TransformChild()
    {
        if (childs.Count == 1)
        {
            foreach (var child in childs)
            {
                child.position = spot + distant;                  
            }
        }
        else if(childs.Count > 1)
        {
            float angle = childs.Count*5;
            float halfAngle = angle / 2;
            float perAngle = angle / childs.Count;
            Quaternion halfRotation = Quaternion.AngleAxis(-halfAngle, Vector2.up);
            Quaternion perRotation = Quaternion.AngleAxis(perAngle, Vector2.up);
            Vector2[] directions = new Vector2[childs.Count];
            directions[0] = distant * halfRotation.eulerAngles;
            childs[0].position = spot + directions[0];
            childs[0].rotation = halfRotation;
            for (int i = 1; i < childs.Count; i++)
            {
                directions[i] = directions[i - 1] * perRotation.eulerAngles;
                childs[i].position = spot + directions[i];
                childs[i].rotation = childs[i - 1].rotation *perRotation;
            }
        }
       
    }
}
