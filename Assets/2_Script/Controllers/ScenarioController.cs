using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;
using System.Threading.Tasks;



public class ScenarioController : MonoBehaviour
{
    [SerializeField] private ResultUI resultUI;
    [SerializeField] private TextMeshProUGUI totalTimerText;

    private EvacuationTimerService evacuationTimerService;
    private ScenarioResultData resultData;
    [SerializeField] private EarthquakeStartEvent earthquakeStartEvent;
    [SerializeField] private MapController mapController;

    [SerializeField] private GameObject[] arrows;

    [SerializeField] private Transform arrivedPoint;
    [SerializeField] private GameObject MoveControl;    
    [SerializeField] private GameObject tsunamiWave;    
    [SerializeField] private Animator tsunamiAnim;

    [SerializeField] private Animator fade;
    [SerializeField] private GameObject fadePanel;




    private void Start()
    {
        evacuationTimerService = new EvacuationTimerService();

        resultData = new ScenarioResultData();
        resultData.currentDecision = 1;

        earthquakeStartEvent.StartEvent1();
        
        /*
        ShowArrow(0);
        */
        /*
        evacuationTimerService.StartTimer();
   */
    }

    

    private void Update()
    {
        evacuationTimerService.Tick(Time.deltaTime);

        totalTimerText.text =
            $"Evacuation Time : {evacuationTimerService.ElapsedTime:F1}";
    }
/*
    public void CompleteScenario(bool decisionCorrect)
    {
        evacuationTimerService.StopTimer();

        resultData.decisionCorrect = decisionCorrect;

        resultData.scenarioSuccess = true;

        resultUI.ShowResult(resultData);
    }
*/

    public void StartEvacuation()
    {
        ShowArrow(0);
        evacuationTimerService.StartTimer();
    }
    
    public async UniTask FinishSenario()
    {
        resultData.currentDecision += 1;
        ShowArrow(resultData.currentDecision - 1);
        mapController.MoveToPoint(resultData.currentDecision - 1);


        if (resultData.currentDecision == 6)
        {
            evacuationTimerService.StopTimer();

            resultData.totalEvacuationTime = evacuationTimerService.ElapsedTime;

            resultData.scenarioSuccess = true;

            /*resultUI.ShowResult(resultData);*/

            /*mapController.MoveToPoint(arrivedPoint);*/
            fadePanel.SetActive(true);
            fade.Play("fadeIn");
            await UniTask.Delay(1000);

            await FinalEvent();

            /*ResultSceneData.IsIndoor = false;
            ResultSceneData.OutdoorResult = resultData;

            SceneManager.LoadScene("Result");*/
        }
    }

    public async UniTask FailScenario()
    {
        resultData.currentDecision += 1;
        ShowArrow(resultData.currentDecision - 1);
        mapController.MoveToPoint(resultData.currentDecision - 1);



        if (resultData.currentDecision == 6)
        {
            evacuationTimerService.StopTimer();

            resultData.totalEvacuationTime = evacuationTimerService.ElapsedTime;

            resultData.scenarioSuccess = false;

            /*resultUI.ShowResult(resultData);*/
            fadePanel.SetActive(true);
            fade.Play("fadeIn");
            await FinalEvent();

            /*ResultSceneData.IsIndoor = false;
            ResultSceneData.OutdoorResult = resultData;

            SceneManager.LoadScene("Result");*/
        }
    }

    public void ShowArrow(int index)
    {
        foreach (GameObject arrow in arrows)
        {
            arrow.SetActive(false);
        }

        if (index >= 0 && index < arrows.Length)
        {
            arrows[index].SetActive(true);
        }
    }

    public void RecordDecisionResult(
    bool isCorrect,
    float responseTime)
    {
        DecisionResult result = new DecisionResult();

        result.decisionNumber =
            resultData.currentDecision;

        result.isCorrect =
            isCorrect;

        result.responseTime =
            responseTime;

        resultData.decisionResults.Add(result);
    }

    public int CurrentDecision
    {
        get { return resultData.currentDecision; }
    }

    public async UniTask FinalEvent()
    {
        mapController.MoveToFinalPoint(arrivedPoint);
        MoveControl.SetActive(false);
        fade.Play("fadeOut");
        await UniTask.Delay(1000);
        fadePanel.SetActive(false);

        await UniTask.Delay(2000);

        tsunamiWave.SetActive(true);
        tsunamiAnim.Play("Tsunami");
        UISoundManager.Instance.PlayWave();
        await UniTask.Delay(15000);
        FinishOutdoorSenario();

    }

    private void FinishOutdoorSenario()
    {
            ResultSceneData.IsIndoor = false;
            ResultSceneData.OutdoorResult = resultData;

            SceneManager.LoadScene("Result");
    }
}

