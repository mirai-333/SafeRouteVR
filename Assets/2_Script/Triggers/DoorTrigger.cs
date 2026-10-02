using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private GameObject button;
    [SerializeField] private SenarioController2 scenarioController2;


    private void OnTriggerEnter(Collider other)
    {
        if (scenarioController2.CurrentPhase != 2)
        return;

        if (!other.CompareTag("Player"))
            return;

        button.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        button.SetActive(false);
    }
}
