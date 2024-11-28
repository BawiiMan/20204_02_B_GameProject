using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    string GetInteractPrompt();     //��ȣ�ۿ�� ǥ���� �ؽ�Ʈ

    void OnInteract(GameObject player);

    float GetInteractionDistance();

    bool CanInteract(GameObject player);
}

