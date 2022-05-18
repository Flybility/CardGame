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
        value.DOColor(new Color(1, 1, 1, 0), 2);
        transform.DOLocalMove(transform.localPosition+distance, 1);
        transform.DOScale(Scale, 1);
        Destroy(gameObject, 2);
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
