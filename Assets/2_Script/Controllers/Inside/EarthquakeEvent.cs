using UnityEngine;
using Cysharp.Threading.Tasks;

public class EarthquakeEvent : MonoBehaviour
{
    [SerializeField] private GameObject alertPanel;
    [SerializeField] private AudioSource earthquakeAlert;
    [SerializeField] private GameObject discriptionPanel;


    [SerializeField] private EarthquakeShake earthquakeShake;
    [SerializeField] private SenarioController2 senarioController2;


 
    public async UniTask StartInsideEvent1()
    {
        await UniTask.Delay(2000);

        alertPanel.SetActive(true);
        UISoundManager.Instance.PlayAppear2();

        await UniTask.Delay(500);

        earthquakeAlert.Play();

        await UniTask.Delay(1000);

        earthquakeShake.ContinuousShake();

        await UniTask.Delay(500);

        discriptionPanel.SetActive(true);



    }

    public void ClickedEAlertButton()
    {
        alertPanel.SetActive(false);
        earthquakeAlert.Stop();
    }

    public void ClickedOK()
    {
        discriptionPanel.SetActive(false);
        senarioController2.StartScenario();


    }

}

