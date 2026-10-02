using UnityEngine;
using TMPro;


public class Phase2Event : MonoBehaviour
{
    [SerializeField] private SenarioController2 senarioController2;
    [SerializeField] private GameObject frame;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject failPanel;

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private Animator doorAnimator;



    [SerializeField] private float timeLimit = 20;

    private float remainingTime;
    private float startTime;
    private bool isRunning;
    private bool fireDone;
    private bool doorDone;


    public void StartPhase()
    {
        startTime = Time.time;

        remainingTime = timeLimit;
        isRunning = true;

        frame.SetActive(true);
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
        panel.SetActive(false);
        isRunning = false;

        float responseTime = Time.time - startTime;

        senarioController2.RecordPhaseResult(
            true,
            responseTime);

        senarioController2.CompletePhase();
    }


    public void FailPhase()
    {

        panel.SetActive(false);
        isRunning = false;

        float responseTime = Time.time - startTime;

        UISoundManager.Instance.PlayWrong();


        senarioController2.RecordPhaseResult(
            false,
            responseTime);

        failPanel.SetActive(true);

    }

    public void CompleteFire()
    {
        frame.SetActive(false);
        fireDone = true;
        CheckPhaseComplete();
        UISoundManager.Instance.PlayCorrect();

    }

    public void CompleteDoor()
    {
        doorDone = true;
        doorAnimator.SetTrigger("DoorOpen");
        CheckPhaseComplete();
        UISoundManager.Instance.PlayCorrect();


    }

    private void CheckPhaseComplete()
    {
        if (fireDone && doorDone)
        {
            CompletePhase();
        }
    }

    public void DoneFailPanel()
    {
        failPanel.SetActive(false);
        senarioController2.CompletePhase();
    }

}
