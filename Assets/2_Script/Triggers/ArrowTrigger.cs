using UnityEngine;

public class ArrowTrigger : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private SenarioController2 senarioController2;


    private void OnTriggerEnter(Collider other)
    {   
        if (!other.CompareTag("Player"))
            return;

        panel.SetActive(false);
        senarioController2.CompletePhase();
    }
}