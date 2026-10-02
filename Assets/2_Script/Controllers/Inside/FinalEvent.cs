using UnityEngine;

public class FinalEvent : MonoBehaviour
{
    [SerializeField] private GameObject pointUI;
    [SerializeField] private GameObject trigger;


    public void ShowArrow()
    {
        pointUI.SetActive(true);
        trigger.SetActive(true);

    }
}
