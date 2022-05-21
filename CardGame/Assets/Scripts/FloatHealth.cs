using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FloatHealth : MonoBehaviour
{
    public Vector3 distance;
    public Vector2 Scale;
    public Text value;
    public Color color;
    // Start is called before the first frame update
    void Start()
    {
        value = GetComponent<Text>();
        color = value.color;
        transform.DOLocalMove(transform.localPosition+distance, 1.2f);
        transform.DOScale(Scale, 0.5f);
        Invoke("Fade", 0.5f);
        Destroy(gameObject, 1.5f);
    }
    public void Fade()
    {
        value.DOColor(new Color(color.r, color.g, color.b, 0),1);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
