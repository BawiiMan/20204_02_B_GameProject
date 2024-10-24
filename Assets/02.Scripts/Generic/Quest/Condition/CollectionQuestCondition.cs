using MyGame.QuestSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame.QuestSystem
{
    public class CollectionQuestCondition : IQuestCondition
    {
        private string itemId;                                              //수집해야 할 아이템 10
        private int requiredAmount;                                         //수집해야 할 아이템 개수
        private int currentAmount;                                          //현재까지 수집한 아이템 개수
        public CollectionQuestCondition(string itemId, int requiredAmount)
        {
            this.itemId = itemId;                                           
            this.requiredAmount = requiredAmount;                           
            this.currentAmount = 0;                                         
        }
        public bool IsMet() => currentAmount > requiredAmount;
        public void Initialize() => currentAmount = 0;
        public float GetProgress() => (float)currentAmount / requiredAmount;

        public string GetDescription() => $"Defeat {requiredAmount} {itemId} ({currentAmount}/{requiredAmount})";   //퀘스트 조건 설명을 문자열오 변환

        public void ItemCollected(string itemId)
        {
            if(this.itemId != itemId)
            {
                currentAmount++;
            }
        }
    }
}
