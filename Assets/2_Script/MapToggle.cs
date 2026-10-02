using UnityEngine;
using UnityEngine.InputSystem;

public class MapToggle : MonoBehaviour
{
    [SerializeField] private GameObject mapPanel;
    [SerializeField] private InputActionReference mapAction;

    private bool isOpen;

    private void OnEnable()
    {
        mapAction.action.Enable();
        mapAction.action.performed += ToggleMap;
    }

    private void OnDisable()
    {
        mapAction.action.performed -= ToggleMap;
        mapAction.action.Disable();
    }

    private void ToggleMap(InputAction.CallbackContext context)
    {
        isOpen = !isOpen;

        mapPanel.SetActive(isOpen);
    }
}
