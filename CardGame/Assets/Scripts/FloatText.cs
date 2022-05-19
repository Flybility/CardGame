using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
public class FloatText : MonoBehaviour
{
    public Vector3 distance;
    public Vector3 Scale;
    public Text value;
    public Color color;
    // Start is called before the first frame update
    void Start()
    {
        value = GetComponent<Text>();
        color = value.color;
        value.DOColor(new Color(color.r, color.g, color.b, 1), 1f);
        transform.DOLocalMove(transform.localPosition+distance, 1);
        transform.DOScale(Scale, 1);
        Invoke("Fade", 1f);
        Destroy(gameObject, 1.5f);
    }
    public void Fade()
    {
        value.DOColor(new Color(color.r, color.g, color.b, 0), 0.5f);
    }

    // Update is called once per frame
    void Updated()
    {
        if (color.a <= 0)
        {
            Destroy(gameObject);
        }
    }
}
