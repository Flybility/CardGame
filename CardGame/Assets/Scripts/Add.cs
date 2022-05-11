using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add : MonoBehaviour
{
    public GameObject[] Buttons;
    private void Awake()
    {
        Buttons = GameObject.FindGameObjectsWithTag("Button");
        foreach (var button in Buttons)
        {
            button.AddComponent<ButtonInteraction>();
        }
    }
}
