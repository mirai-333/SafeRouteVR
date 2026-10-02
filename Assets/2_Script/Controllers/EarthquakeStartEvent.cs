using UnityEngine;
using Cysharp.Threading.Tasks;

public class EarthquakeStartEvent : MonoBehaviour
{
    [SerializeField] private GameObject EalertPanel;
    [SerializeField] private GameObject TalertPanel;
    [SerializeField] private GameObject discriptionPanel;
    [SerializeField] private ScenarioController scenarioController;    
    [SerializeField] private AudioSource earthquakeAlert;    
    [SerializeField] private AudioSource tsunamiAlert;    
    [SerializeField] private EarthquakeShake earthquakeShake;



    public async UniTask StartEvent1()
    {
        await UniTask.Delay(2000);

        EalertPanel.SetActive(true);
        UISoundManager.Instance.PlayAppear2();

        await UniTask.Delay(1000);

        earthquakeAlert.Play();
        
        await UniTask.Delay(1000);

        await earthquakeShake.Shake(4f);

        await UniTask.Delay(2000);

        TalertPanel.SetActive(true);
        tsunamiAlert.Play();

        await UniTask.Delay(3000);

        discriptionPanel.SetActive(true);
    }

    public void ClickedOK()
    {
        discriptionPanel.SetActive(false);

        scenarioController.StartEvacuation();


    }

    public void ClickedEAlertClose()
    {
        earthquakeAlert.Stop();
        EalertPanel.SetActive(false);

    }

    public void ClickedTAlertClose()
    {
        tsunamiAlert.Stop();
        TalertPanel.SetActive(false);

    }
}
