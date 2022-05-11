using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StateDisplayer : MonoBehaviour
{
    public TextMeshProUGUI stateText;
    // Start is called before the first frame update
    void Start()
    {
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
