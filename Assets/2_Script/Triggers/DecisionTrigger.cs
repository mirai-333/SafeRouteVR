using UnityEngine;

public class DecisionTrigger : MonoBehaviour
{
    [SerializeField] private DecisionPointController decisionPointController;

    private bool triggered;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;

        if (!other.CompareTag("Player")) return;

        triggered = true;

        UISoundManager.Instance.PlayArrow();

        decisionPointController.StartDecision();
    }
}
