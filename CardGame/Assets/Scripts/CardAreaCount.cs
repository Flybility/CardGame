using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardAreaCount : MonoBehaviour
{
    public Text discardCount;
    public Text extractCount;
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
