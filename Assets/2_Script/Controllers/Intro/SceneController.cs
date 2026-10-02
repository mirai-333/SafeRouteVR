using UnityEngine;
using Cysharp.Threading.Tasks;

public class SceneController : MonoBehaviour
{
    [SerializeField] private ScenePortal scenePortal;
    [SerializeField] private ScenePortal scenePortal2;

    
    [SerializeField] private Animator panelAnimator1;
    [SerializeField] private Animator panelAnimator2;


    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject[] HowPanels;
    [SerializeField] private GameObject navigatePanel;



    [SerializeField] private GameObject settingPanel;

    [SerializeField] private GameObject outdoorPanel;
    [SerializeField] private GameObject outdoorText;
    [SerializeField] private GameObject indoorPanel;
    [SerializeField] private GameObject indoorText;

    private int currentPage;

    void Start()
    {
        UIappear();

        mainPanel.SetActive(false);

        foreach(GameObject panel in HowPanels)
        {
            panel.SetActive(false);
        }
        
        outdoorPanel.SetActive(false);
        outdoorText.SetActive(false);
        indoorPanel.SetActive(false);
        indoorText.SetActive(false);
    }

    void Update()
    {
        
    }

    private async UniTask UIappear()
    {
        await UniTask.Delay(1000);

        mainPanel.SetActive(true);
        UISoundManager.Instance.PlayAppear2();

    }

    public void ClickedStart()
    {
        mainPanel.SetActive(false);
        startPanel.SetActive(true);
        outdoorPanel.SetActive(true);
        outdoorText.SetActive(true);
        indoorPanel.SetActive(true);
        indoorText.SetActive(true);
        panelAnimator1.Play("PanelAppear");
        panelAnimator2.Play("PanelAppear");

        UISoundManager.Instance.PlayAppear();


        scenePortal.EnableTrigger();
        scenePortal2.EnableTrigger();


    }

    public void ClickedSetting()
    {
        mainPanel.SetActive(false);
        settingPanel.SetActive(true);

        UISoundManager.Instance.PlayAppear2();

    }

    public void ClickedHowtoPlay()
    {
        mainPanel.SetActive(false);
        navigatePanel.SetActive(true);
        HowPanels[0].SetActive(true);
        currentPage = 0;
        UISoundManager.Instance.PlayAppear2();

    }
    public void GotoNext()
    {
        if (currentPage >= HowPanels.Length - 1)
            return;

        HowPanels[currentPage].SetActive(false);
        currentPage += 1;
        HowPanels[currentPage].SetActive(true);
        UISoundManager.Instance.PlayAppear2();


    }

    public void GotoPrevious()
    {
        if (currentPage <= 0)
        return;

        HowPanels[currentPage].SetActive(false);
        currentPage -= 1;
        HowPanels[currentPage].SetActive(true);
        UISoundManager.Instance.PlayAppear2();


    }

    public void GotoMain()
    {
        foreach(GameObject panel in HowPanels)
        {
            panel.SetActive(false);
        }
        navigatePanel.SetActive(false);

        mainPanel.SetActive(true);
        UISoundManager.Instance.PlayAppear2();

    }

    public void ClickedBack()
    {
        startPanel.SetActive(false);
        settingPanel.SetActive(false);
        mainPanel.SetActive(true);
        UISoundManager.Instance.PlayAppear2();

    }


}
