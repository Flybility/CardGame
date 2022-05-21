using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster13 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerData.Instance.extraPerRoundHealthDecrease = -PlayerData.Instance.perRoundHealthDecrease;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        PlayerData.Instance.extraPerRoundHealthDecrease = 0;
    }
}
