using System.Text;
using TMPro;
using UnityEngine;

public class ResultUI : MonoBehaviour
{
    [SerializeField] private GameObject[] DiscriptionPanels;
    [SerializeField] private ScenarioController scenarioController;

    [SerializeField] private TextMeshProUGUI resultText;

    public void ShowResult(ScenarioResultData data)
    {
        resultText.gameObject.SetActive(true);

        StringBuilder sb = new StringBuilder();

        if (data.scenarioSuccess)
        {
            sb.AppendLine("CONGRATULATIONS");
            sb.AppendLine($"Time : {data.totalEvacuationTime:F1}");
            sb.AppendLine();

            foreach (DecisionResult result in data.decisionResults)
            {
                sb.AppendLine(
                    $"DP{result.decisionNumber} : " +
                    $"{(result.isCorrect ? "Correct" : "Wrong")} " +
                    $"({result.responseTime:F1}s)");
            }
        }
        else
        {
            sb.AppendLine("FAILED");
            sb.AppendLine();

            foreach (DecisionResult result in data.decisionResults)
            {
                sb.AppendLine(
                    $"DP{result.decisionNumber} : " +
                    $"{(result.isCorrect ? "Correct" : "Wrong")} " +
                    $"({result.responseTime:F1}s)");
            }
        }

        resultText.text = sb.ToString();
    }

    public void ShowDiscription()
    {
        foreach (GameObject panel in DiscriptionPanels)
        {
            panel.SetActive(false);
        }

        int index = scenarioController.CurrentDecision - 1;

        if (index >= 0 && index < DiscriptionPanels.Length)
        {
            DiscriptionPanels[index].SetActive(true);
        }
    }

    public void ClickOK()
    {
        foreach (GameObject panel in DiscriptionPanels)
        {
            panel.SetActive(false);
        }        
        scenarioController.FailScenario();
    }
}