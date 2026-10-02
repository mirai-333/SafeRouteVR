using Cysharp.Threading.Tasks;
using UnityEngine;

public class EarthquakeShake : MonoBehaviour
{
    private Vector3 startPos;
    private bool isShaking;


    private void Awake()
    {
        startPos = transform.localPosition;
        isShaking = true;

    }

    public async UniTask Shake(float duration)
    {
        float timer = 0;

        while (timer < duration)
        {
            timer += Time.deltaTime;

            transform.localPosition =
                startPos +
                Random.insideUnitSphere * 0.03f;

            await UniTask.Yield();
        }

        transform.localPosition = startPos;
    }


    public async UniTask ContinuousShake()
    {
        isShaking = true;

        while (isShaking)
        {

            transform.localPosition =
                startPos +
                Random.insideUnitSphere * 0.03f;

            await UniTask.Yield();
        }

        transform.localPosition = startPos;
    }

    public void StopShake()
    {
        isShaking = false;
    }
}