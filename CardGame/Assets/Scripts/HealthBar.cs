using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;


    // Start is called before the first frame update
    void Start()
    {
        PlayerData.Instance.healthChange.AddListener(HealthBarChange);
        slider = GetComponent<Slider>();
        HealthBarChange();
    }
    public void HealthBarChange()
    {
        Debug.Log("生命值改变");
        slider.value = (float)PlayerData.Instance.currentHealth / PlayerData.Instance.maxHealth ;
    }
}
