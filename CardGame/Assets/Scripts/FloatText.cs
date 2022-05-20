using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
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
        //transform.DOLocalMove(transform.localPosition+distance, 1);
        rigid.AddForce(distance);
        transform.DOScale(Scale, 1);
        //Invoke("Fade", 1f);
        Destroy(gameObject, 2f);
    }
    public void Fade()
    {
        float n = Mathf.Lerp(0, 1, 1);
        Color newcolor = new Color(color.r, color.g, color.b, n);
        value.color = newcolor;

    }

    // Update is called once per frame
    void Updated()
    {
        Fade();
    }
}
