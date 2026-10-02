using UnityEngine;

public class NPCtrigger : MonoBehaviour
{
    [SerializeField] private NPCMove[] npcs;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        foreach (NPCMove npc in npcs)
        {
            npc.StartMove();
        }

        gameObject.SetActive(false);
    }
}