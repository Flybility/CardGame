using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
public class FloatText : MonoBehaviour
{
    public Vector2 distance;
    public Vector2 Scale;
    public Text value;
    public Color color;
    public Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        value = GetComponent<Text>();
        color = value.color;
        rigid = GetComponent<Rigidbody2D>();
        value.DOColor(new Color(color.r, color.g, color.b, 0), 2f);
        //transform.DOLocalMove(transform.localPosition+distance, 1);
        rigid.AddForce(distance);
        transform.DOScale(Scale, 1);
        //Invoke("Fade", 1f);
        Destroy(gameObject, 2f);
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
