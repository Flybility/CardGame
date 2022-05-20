using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CursorFollow : MonoSingleton<CursorFollow>
{
    Canvas canvas;
    RectTransform rectTransform;
    Vector2 pos;
    Camera _camera;
    RectTransform canvasRectTransform;
    public GameObject description;
    public bool isOnUI;
    void Start()
    {
        description = transform.GetChild(0).gameObject;
        description.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(false);
        Cursor.visible = false;
        rectTransform = transform as RectTransform;
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        _camera = canvas.GetComponent<Camera>();
        canvasRectTransform = canvas.transform as RectTransform;
        Debug.Log(canvas.renderMode);
    }
    void Update()
    {
        FollowMouseMove();
        isOnUI = GetOverUI(canvas);
        if (isOnUI==false)
        {
            description.SetActive(false);
        }
    }
    public void FollowMouseMove()
    {
        //worldCamera:1.screenSpace-Camera 
        // canvas.GetComponent<Camera>() 1.ScreenSpace -Overlay 
        if (RenderMode.ScreenSpaceCamera == canvas.renderMode)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, Input.mousePosition, canvas.worldCamera, out pos);
        }
        else if (RenderMode.ScreenSpaceOverlay == canvas.renderMode)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, Input.mousePosition, _camera, out pos);
        }
        else
        {
            Debug.Log("请选择正确的相机模式!");
        }
        rectTransform.anchoredPosition = pos;

        //或者

        //transform.localPosition = new Vector3(pos.x, pos.y, 0);
    }
    public GameObject GetOverUI(Canvas canvas)
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;
        GraphicRaycaster gr = canvas.GetComponent<GraphicRaycaster>();
        List<RaycastResult> results = new List<RaycastResult>();
        gr.Raycast(pointerEventData, results);
        if (results.Count != 0)
        {
            return results[0].gameObject;
        }

        return null;
    }
}


