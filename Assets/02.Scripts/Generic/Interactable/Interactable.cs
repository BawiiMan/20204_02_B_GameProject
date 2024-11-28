using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    string GetInteractPrompt();     //상호작용시 표시할 텍스트

    void OnInteract(GameObject player);

    float GetInteractionDistance();

    bool CanInteract(GameObject player);
}

