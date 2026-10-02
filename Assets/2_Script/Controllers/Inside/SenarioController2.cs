using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SenarioController2 : MonoBehaviour
{
    [SerializeField] private EarthquakeEvent earthquakeEvent;
    [SerializeField] private Phase1Event phase1;
    [SerializeField] private Phase2Event phase2;
    [SerializeField] private Phase3Event phase3;
    [SerializeField] private FinalEvent final;




    [SerializeField] private TextMeshProUGUI timerText;

    private SenarioResultData2 resultData;
    private int currentPhase = 1;
    private EvacuationTimerService totalTimer;

    private void Start()
    {
        earthquakeEvent.StartInsideEvent1();
        totalTimer = new EvacuationTimerService();
        totalTimer.StartTimer();

        resultData = new SenarioResultData2();

    }

    private void Update()
    {
        totalTimer.Tick(Time.deltaTime);
        timerText.text = $"{totalTimer.ElapsedTime:F0}";    }

    public void StartScenario()
    {
        phase1.StartPhase();
    }
    
    public void CompletePhase()
    {
        currentPhase++;

        switch(currentPhase)
        {
            case 2:
                phase2.StartPhase();
                break;

            case 3:
                phase3.StartPhase();
                break;

            case 4:
                final.ShowArrow();
                break;

            case 5:

                totalTimer.StopTimer();

                resultData.totalTime = totalTimer.ElapsedTime;

                resultData.scenarioSuccess = true;
                
                ResultSceneData.IsIndoor = true;
                ResultSceneData.IndoorResult = resultData;

                SceneManager.LoadScene("Result");
                break;
                /*FinishScenario();
                break;*/
        }
    }

    public void RecordPhaseResult(
    bool isSuccess,
    float responseTime)
    {
        PhaseResult result =
            new PhaseResult();

        result.phaseNumber =
            currentPhase;

        result.isSuccess =
            isSuccess;

        result.responseTime =
            responseTime;

        resultData.phaseResults.Add(result);
    }

    public int CurrentPhase
    {
        get { return currentPhase; }
    }
}
