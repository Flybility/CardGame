using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadEachLevelMonsters : MonoSingleton<ReadEachLevelMonsters>
{
    public TextAsset cardText;
    public List<MonsterCard> monsterCardList = new List<MonsterCard>();

    // Start is called before the first frame update
    void Start()
    {
        ReadCardInText();
    }
        //用于加载recourses里的每个关卡文档中的卡牌
    public void ReadCardInText()
    {
        cardText = Resources.Load<TextAsset>("Level" + GameManager.Instance.level.ToString());
        string[] cardId = cardText.text.Split(',');
        foreach(var id in cardId)
        {
            monsterCardList.Add(CardDatabase.Instance.CopyMonsterCard(int.Parse(id)));
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
