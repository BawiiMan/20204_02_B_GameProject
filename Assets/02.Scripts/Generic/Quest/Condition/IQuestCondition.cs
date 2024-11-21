using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyGame.QuestSystem
{
    public interface IQuestCondition
    {
        bool IsMet();                               //������ �����Ǿ����� ���� ��ȯ

        void Initialize();                           //������ �ʱ�ȭ�ϴ� �޼���

        float GetProgress();                        //���� ������ ����
            
        string GetDescription();                    //���� ���� ��ȯ �޼���
    }

}