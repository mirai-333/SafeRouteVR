using UnityEngine;
using System.Linq;


public class Phase3Event : MonoBehaviour
{
    [SerializeField] private GameObject backpack;
    [SerializeField] private BackpackTrigger backpackTrigger;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject failPanel;
    [SerializeField] private SenarioController2 senarioController2;

    private float remainingTime;
    private float startTime;
    private bool isRunning;


    public void StartPhase()
    {
        startTime = Time.time;
        isRunning = true;

        backpack.SetActive(true);
        panel.SetActive(true);
        UISoundManager.Instance.PlayArrow();

    }


    public void ClickedDone()
    {
        ItemType[] correctItems =
        {
            ItemType.Water,
            ItemType.Battery,
            ItemType.Light,
            ItemType.Clothes

        };

        bool isCorrect =
            backpackTrigger.packedItems.Count == correctItems.Length &&
            correctItems.All(item =>
                backpackTrigger.packedItems.Contains(item));

        isRunning = false;
        if (isCorrect)
        {
            panel.SetActive(false);
            UISoundManager.Instance.PlayBackpack();
            backpack.SetActive(false);

            isRunning = false;

            float responseTime = Time.time - startTime;

            senarioController2.RecordPhaseResult(
                true,
                responseTime);

            senarioController2.CompletePhase();



        }
        else
        {
            panel.SetActive(false);
            failPanel.SetActive(true);
            UISoundManager.Instance.PlayWrong();

            isRunning = false;

            float responseTime = Time.time - startTime;

            senarioController2.RecordPhaseResult(
                false,
                responseTime);



        }
    }

    public void DoneFailPanel()
    {
        failPanel.SetActive(false);
        senarioController2.CompletePhase();
        UISoundManager.Instance.PlayBackpack();
        backpack.SetActive(false);
    }

    public void PlayGrab()
    {
        UISoundManager.Instance.PlayPickup();
    }




}
