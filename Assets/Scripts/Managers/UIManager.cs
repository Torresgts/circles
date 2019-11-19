using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Canvas MainMenuUI;
   
    [SerializeField]
    private Canvas GameplayUI;

    [SerializeField]
    private Canvas GameOverUI;

    private void Awake() 
    {
        EventManager.OnMainMenu.AddListener(ActiveMainMenuUI);
        EventManager.OnPlayGameButton.AddListener(ActiveGameplayUI);
        EventManager.OnFailedTouch.AddListener(ActiveGameOverUI);

        ActiveMainMenuUI();
    }

    public void ActiveMainMenuUI()
    {
        MainMenuUI.enabled = true;
        GameplayUI.enabled = false;
        GameOverUI.enabled = false;
    }

    public void ActiveGameplayUI()
    {
        MainMenuUI.enabled = false;
        GameplayUI.enabled = true;
        GameOverUI.enabled = false;
    }

     public void ActiveGameOverUI()
    {
        MainMenuUI.enabled = false;
        GameplayUI.enabled = false;
        GameOverUI.enabled = true;
    }
   
}
