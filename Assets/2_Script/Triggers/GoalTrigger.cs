using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    [SerializeField] private ScenarioController scenarioController;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        //scenarioController.CompleteScenario(true);
    }
}
