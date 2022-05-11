using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Vector2 StartPoint;
    private Vector2 EndPoint;
    private RectTransform arrowHead, arrowBody;

    private float arrowLength;
    private float arrowAngle;
    private Vector2 arrowPosition;

    void Start()
    {
        arrowBody = transform.GetChild(0).GetComponent<RectTransform>();
        arrowHead = transform.GetChild(1).GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Camera camera = Camera.main;

        EndPoint = Vector3.one;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            GetComponentInParent<RectTransform>(), Input.mousePosition, camera, out EndPoint);
               
        arrowHead.localPosition = EndPoint;

        arrowPosition = new Vector2((EndPoint.x + StartPoint.x) / 2, (EndPoint.y + StartPoint.y) / 2);
        arrowLength = Vector2.Distance(StartPoint, EndPoint);
        arrowAngle = Mathf.Atan2(EndPoint.y - StartPoint.y, EndPoint.x - StartPoint.x);

        arrowBody.localPosition = arrowPosition;
        arrowBody.sizeDelta = new Vector2(arrowLength, arrowBody.sizeDelta.y);
        arrowBody.localEulerAngles = new Vector3(0, 0,arrowAngle * 180 / Mathf.PI);
        arrowHead.localEulerAngles = new Vector3(0, 0, arrowAngle * 180 / Mathf.PI);
        //targetDir.position = Camera.main.WorldToScreenPoint(Input.mousePosition);
        //Vector3 offset = targetDir.position - transform.position;
        //for(int i=)
        //lineRend.SetPositions(segmentPos);
        ////tailEnd.position = segmentPos[segmentPos.Length - 1];
    }
    
    public void SetStartPoint(Vector2 startPoint)
    {
        StartPoint = startPoint;
    }
}
