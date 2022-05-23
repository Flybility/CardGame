using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoSingleton<AudioManager>
{
    public AudioSource click;
    public AudioSource monsterAttack;
    public AudioSource playerAttack;
    public AudioSource choseCard;
    public AudioSource cardEnter;
    public AudioSource boom1;
    public AudioSource boom2;
    public AudioSource monsterDead1;
    public AudioSource monsterDead2;
    public AudioSource summonMonster;

    public AudioSource startMusic;
    public AudioSource battleMusic;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
