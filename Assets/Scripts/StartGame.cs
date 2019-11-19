using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public void PlayGame()
    {
       // StartCoroutine(PlayTheGame());
       EventManager.OnPlayGameButton.Invoke();
       EventManager.OnPlaySound.Invoke("ButtonClick");
        
    }

    IEnumerator PlayTheGame()
    {
        yield return new WaitForEndOfFrame();
        //EventManager.OnPlayGame.Invoke();
    }
}
