using UnityEngine;

public class DecisionTimerService
{
    private float remainingTime;

    public float RemainingTime => remainingTime;

    public void StartTimer(float duration)
    {
        remainingTime = duration;
    }

    public void Tick(float deltaTime)
    {
        if (remainingTime <= 0f) return;

        remainingTime -= deltaTime;
    }

    public bool IsTimeUp()
    {
        return remainingTime <= 0f;
    }
}
