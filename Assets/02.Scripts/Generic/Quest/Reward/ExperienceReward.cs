using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame.QuestSystem
{
    public class ExperienceReward : IQuestReward                //����ġ ������ �����ϴ� Ŭ����
    {
        private int exprienceAmount;                //�������� ������ ����ġ��

        public ExperienceReward(int amount)                     //����ġ ���� �ʱ�ȭ ������
        {
            this.exprienceAmount = amount;
        }

        public void Grant(GameObject player)
        {
            //TODO : ���� ����ġ ���� ���� ����
            Debug.Log($"Granted {exprienceAmount} experience");
        }

        public string GetDescription() => $"{exprienceAmount} Experience Points";       //���� ������ ���ڿ��� ��ȯ
    }

}
