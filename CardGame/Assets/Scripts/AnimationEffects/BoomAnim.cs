using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomAnim : MonoBehaviour
{
    private Animator effect;
    // Start is called before the first frame update
    void Start()
    {
        effect = GetComponent<Animator>();
        effect.SetInteger("state", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
