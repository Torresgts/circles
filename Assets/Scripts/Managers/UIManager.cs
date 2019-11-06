using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject MainMenuUI;
   
    [SerializeField]
    private GameObject GameplayUI;

    [SerializeField]
    private GameObject GameOverUI;

    private void Awake() 
    {
        EventManager.OnMainMenu.AddListener(ActiveMainMenuUI);
        EventManager.OnPlayGame.AddListener(ActiveGameplayUI);
        EventManager.OnFailedTouch.AddListener(ActiveGameOverUI);

        ActiveMainMenuUI();
    }

    public void ActiveMainMenuUI()
    {
        MainMenuUI.gameObject.SetActive(true);
        GameplayUI.gameObject.SetActive(false);
        GameOverUI.gameObject.SetActive(false);
    }

    public void ActiveGameplayUI()
    {
        MainMenuUI.gameObject.SetActive(false);
        GameplayUI.gameObject.SetActive(true);
        GameOverUI.gameObject.SetActive(false);
    }

     public void ActiveGameOverUI()
    {
        MainMenuUI.gameObject.SetActive(false);
        GameplayUI.gameObject.SetActive(false);
        GameOverUI.gameObject.SetActive(true);
    }
   
}
