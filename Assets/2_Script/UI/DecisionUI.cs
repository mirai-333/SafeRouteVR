using TMPro;
using UnityEngine;

public class DecisionUI : MonoBehaviour 
{
    [SerializeField] private ScenarioController scenarioController;
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject chooseUI;

    private DecisionPointController currentController;

    private float remainingTime;
    private bool isRunning;

    private void Update()
    {
        if (!isRunning) return;

        remainingTime -= Time.deltaTime;

        if (remainingTime < 0f)
        {
            remainingTime = 0f;
        }

        timerText.text = $"Time Left : {remainingTime:F0}";

        if (remainingTime <= 0f)
        {
            isRunning = false;

            currentController.TimeUp();

            Close();

        }
    }

    public void Open(
        DecisionPointController controller,
        string question,
        float timeLimit)
    {
        currentController = controller;

        questionText.text = question;

        remainingTime = timeLimit;
        isRunning = true;

        chooseUI.SetActive(true);
    }

    public void Close()
    {
        isRunning = false;

        gameObject.SetActive(false);
    }

    public void SelectCorrect()
    {
        currentController.SubmitAnswer(true);

        Close();
    }

    public void SelectWrong()
    {
        currentController.SubmitAnswer(false);

        Close();
    }

}
