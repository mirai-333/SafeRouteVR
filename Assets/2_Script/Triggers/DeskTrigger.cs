using UnityEngine;

public class DeskTrigge : MonoBehaviour
{
    [SerializeField] private GameObject button;
    [SerializeField] private SenarioController2 scenarioController2;


    private void OnTriggerEnter(Collider other)
    {
        if (scenarioController2.CurrentPhase != 1)
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
