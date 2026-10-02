using UnityEngine;

public class EvacuationTimerService
{
    private float elapsedTime;
    private bool isRunning;

    public float ElapsedTime => elapsedTime;

    public void StartTimer()
    {
        elapsedTime = 0f;
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void Tick(float deltaTime)
    {
        if (!isRunning) return;

        elapsedTime += deltaTime;
    }
}
