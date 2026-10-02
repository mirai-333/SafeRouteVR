using TMPro;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading.Tasks;


public class Phase1Event : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject failPanel;
    [SerializeField] private Transform movePoint;
    [SerializeField] private Transform exitPoint;
    [SerializeField] private Collider deskTrigger;




    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private SenarioController2 senarioController2;
    [SerializeField] private MapController mapController;
    [SerializeField] private GameObject moveLocomotion;
    [SerializeField] private EarthquakeShake earthquakeShake;

    [SerializeField] private float timeLimit = 20;

    private float remainingTime;
    private float startTime;
    private bool isRunning;

    public void StartPhase()
    {
        startTime = Time.time;

        remainingTime = timeLimit;
        isRunning = true;
        panel.SetActive(true);
        UISoundManager.Instance.PlayArrow();

    }

    public void Update()
    {
        if (!isRunning)
            return;

        timerText.text = $"Time Left : {remainingTime:F0}";

        remainingTime -= Time.deltaTime;

        if (remainingTime <= 0)
        {
            remainingTime = 0;
            FailPhase();

        }

    }

    public void CompletePhase()
    {
        deskTrigger.enabled = false;

        panel.SetActive(false);
        button.SetActive(false);
        isRunning = false;

        UISoundManager.Instance.PlayCorrect();


        float responseTime = Time.time - startTime;

        senarioController2.RecordPhaseResult(
            true,
            responseTime);

        UnderTheDeskEvent();

        /*senarioController2.CompletePhase();*/
        
    }


    public void FailPhase()
    {
        deskTrigger.enabled = false;


        panel.SetActive(false);
        button.SetActive(false);

        isRunning = false;

        UISoundManager.Instance.PlayWrong();


        float responseTime = Time.time - startTime;

        senarioController2.RecordPhaseResult(
            false,
            responseTime);

        failPanel.SetActive(true);

/*
        senarioController2.CompletePhase();*/


    }

    public void DoneFailPanel()
    {
        failPanel.SetActive(false);
        UnderTheDeskEvent();

    }

    public async UniTask UnderTheDeskEvent()
    {
        mapController.MoveToUnderDesk(movePoint);
        moveLocomotion.SetActive(false);

        await UniTask.Delay(8000);

        earthquakeShake.StopShake();
        await UniTask.Delay(2000);

        mapController.MoveToFinalPoint(exitPoint);
        moveLocomotion.SetActive(true);

        senarioController2.CompletePhase();

    }
}
