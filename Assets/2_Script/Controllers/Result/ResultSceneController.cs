using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ResultSceneController : MonoBehaviour
{
    [Header("Common")]
    [SerializeField] private TextMeshProUGUI scenarioText;
    [SerializeField] private TextMeshProUGUI successText;
    [SerializeField] private TextMeshProUGUI totalTimeText;

    [Header("Outdoor")]
    [SerializeField] private TextMeshProUGUI correctCountText;
    [SerializeField] private TextMeshProUGUI[] decisionTexts;

    [Header("Indoor")]
    [SerializeField] private TextMeshProUGUI[] phaseTexts;

    [SerializeField] private GameObject outdoorImage;
    [SerializeField] private GameObject indoorImage;

    [SerializeField] private GameObject successImage;
    [SerializeField] private GameObject failImage;
    [SerializeField] private GameObject currentChoicePanel;
    [SerializeField] private RectTransform divider;
    [SerializeField] private RectTransform[] dividerPositions;

    private void Start()
    {
        if (ResultSceneData.IsIndoor)
        {
            outdoorImage.SetActive(false);
            indoorImage.SetActive(true);
            currentChoicePanel.SetActive(false);
            
            HideOutdoor();
            ShowIndoor();
        }
        else
        {
            outdoorImage.SetActive(true);
            indoorImage.SetActive(false);
            currentChoicePanel.SetActive(true);


            HideIndoor();
            ShowOutdoor();
        }

        UpdateDivider();

    }

    private void ShowOutdoor()
    {
        ScenarioResultData data = ResultSceneData.OutdoorResult;

        /*scenarioText.text = "Outdoor";*/
        /*ShowResult(data.scenarioSuccess);      */
        totalTimeText.text = $"{data.totalEvacuationTime:F1}s";

        int correct = 0;

        for (int i = 0; i < data.decisionResults.Count; i++)
        {
            DecisionResult result = data.decisionResults[i];

            if (result.isCorrect)
                correct++;

            decisionTexts[i].text =
                $"Decision {result.decisionNumber}    " +
                $"{(result.isCorrect ? "○" : "×")}    " +
                $"{result.responseTime:F1}s";
        }

        bool success = correct == data.decisionResults.Count;
        ShowResult(success);

        correctCountText.text =
            $"{correct}/{data.decisionResults.Count}";
    }

    private void ShowIndoor()
    {
        SenarioResultData2 data = ResultSceneData.IndoorResult;

        /*scenarioText.text = "Indoor";*/
        /*ShowResult(data.scenarioSuccess);   */     
        totalTimeText.text = $"{data.totalTime:F1}s";

        int successCount = 0;


        for (int i = 0; i < data.phaseResults.Count; i++)
        {
            PhaseResult result = data.phaseResults[i];

            if (result.isSuccess)
                successCount++;

            phaseTexts[i].text =
                $"Phase {result.phaseNumber}    " +
                $"{(result.isSuccess ? "○" : "×")}    " +
                $"{result.responseTime:F1}s";
        }

        bool success = successCount == data.phaseResults.Count;
        ShowResult(success);
    }

    private void HideOutdoor()
    {
        correctCountText.gameObject.SetActive(false);

        foreach (TextMeshProUGUI text in decisionTexts)
        {
            text.gameObject.SetActive(false);
        }
    }

    private void HideIndoor()
    {
        foreach (TextMeshProUGUI text in phaseTexts)
        {
            text.gameObject.SetActive(false);
        }
    }       
    private void ShowResult(bool success)
    {
        successImage.SetActive(success);
        failImage.SetActive(!success);

        /*successText.text = success ? "SUCCESS" : "FAIL";*/
    }

    private void UpdateDivider()
    {
        for (int i = 0; i < dividerPositions.Length; i++)
        {
            bool show = ResultSceneData.IsIndoor
                ? (i == 1 || i == 2)
                : true;

            dividerPositions[i].gameObject.SetActive(show);
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Intro");

    }
    
}