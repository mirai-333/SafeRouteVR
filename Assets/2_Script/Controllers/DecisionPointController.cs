using UnityEngine;

public class DecisionPointController : MonoBehaviour
{
    [SerializeField] private ScenarioController scenarioController;
    [SerializeField] private DecisionUI decisionUI;
    [SerializeField] private ResultUI resultUI;

    [Header("Decision Settings")]

    [SerializeField] private string question;
    [SerializeField] private float timeLimit = 5f;


    private bool answered;
    private float startTime;

    public void StartDecision()
    {
        answered = false;

        startTime = Time.time;

        UISoundManager.Instance.PlayAppear();

        decisionUI.Open(
            this,
            question,
            timeLimit);
    }

    public void SubmitAnswer(bool isCorrect)
    {
        if (answered) return;

        answered = true;

        float responseTime = Time.time - startTime;
        scenarioController.RecordDecisionResult(
        isCorrect,
        responseTime);

        if (isCorrect)
        {
            UISoundManager.Instance.PlayCorrect();
            scenarioController.FinishSenario();
        }
        else
        {
            UISoundManager.Instance.PlayWrong();
            resultUI.ShowDiscription();
        }
    }

    public void TimeUp()
    {
        if (answered) return;

        answered = true;

        float responseTime = Time.time - startTime;

        scenarioController.RecordDecisionResult(
        false,
        responseTime);

        UISoundManager.Instance.PlayTing2();

        scenarioController.FailScenario();
    }
}