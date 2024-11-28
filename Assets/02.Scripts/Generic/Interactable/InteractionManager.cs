using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionManager : MonoBehaviour
{
    public static InteractionManager Instance { get; private set; }

    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI promptText;
    [SerializeField] private float checkRadius = 3f;
    [SerializeField] private LayerMask interactableLayers;

    private IInteractable currentInteractable;
    private GameObject player;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance);

        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        CheckInteractables();
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.OnInteract(player);
        }
    }

    private void UpdatePrompt()
    {
        if (currentInteractable != null)
        {
            promptText.text = $"[E] {currentInteractable.GetInteractPrompt()}";
            promptText.gameObject.SetActive(true);
        }
        else
        {
            promptText.gameObject.SetActive(false);
        }
    }

    private void CheckInteractables()
    {
        Collider[] colliders = Physics.OverlapSphere(player.transform.position, checkRadius, interactableLayers);
        IInteractable closest = null;
        float closestsDistance = float.MaxValue;

        foreach (var col in colliders)
        {
            if (col.TryGetComponent<IInteractable>(out var interactable))
            {
                float distance = Vector3.Distance(player.transform.position, col.transform.position);

                if (distance <= interactable.GetInteractionDistance() && distance < closestsDistance && interactable.CanInteract(player))
                {
                    closest = interactable;
                    closestsDistance = distance;
                }
            }
        }
        currentInteractable = closest;
        UpdatePrompt();
    }
}