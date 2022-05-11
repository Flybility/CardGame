using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CardAreaCount : MonoBehaviour
{
    public TextMeshProUGUI discardCount;
    public TextMeshProUGUI extractCount;
    public Transform discardArea;
    public Transform extractArea;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        discardCount.text = discardArea.childCount.ToString();
        extractCount.text = extractArea.childCount.ToString();
    }
}
