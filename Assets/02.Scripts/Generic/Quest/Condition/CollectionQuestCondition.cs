using MyGame.QuestSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame.QuestSystem
{
    public class CollectionQuestCondition : IQuestCondition
    {
        private string itemId;                                              //�����ؾ� �� ������ 10
        private int requiredAmount;                                         //�����ؾ� �� ������ ����
        private int currentAmount;                                          //������� ������ ������ ����
        public CollectionQuestCondition(string itemId, int requiredAmount)
        {
            this.itemId = itemId;                                           
            this.requiredAmount = requiredAmount;                           
            this.currentAmount = 0;                                         
        }
        public bool IsMet() => currentAmount > requiredAmount;
        public void Initialize() => currentAmount = 0;
        public float GetProgress() => (float)currentAmount / requiredAmount;

        public string GetDescription() => $"Defeat {requiredAmount} {itemId} ({currentAmount}/{requiredAmount})";   //����Ʈ ���� ������ ���ڿ��� ��ȯ

        public void ItemCollected(string itemId)
        {
            if(this.itemId != itemId)
            {
                currentAmount++;
            }
        }
    }
}