using UnityEngine;
using UnityEngine.SceneManagement;


public class ScenePortal : MonoBehaviour
{
    [SerializeField] private string sceneName;

    private bool isWorking = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isWorking)
            return;

        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void EnableTrigger()
    {
        isWorking = true;
    }
}
