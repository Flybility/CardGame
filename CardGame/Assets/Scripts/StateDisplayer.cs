using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StateDisplayer : MonoBehaviour
{
    public Text stateText;
    // Start is called before the first frame update
    void Start()
    {
        stateText = transform.GetChild(0).GetComponent<Text>();
        BattleField.Instance.stateChangeEvent.AddListener(UpdateText);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateText()
    {
        stateText.text = BattleField.Instance.gameState.ToString();
    }
}
