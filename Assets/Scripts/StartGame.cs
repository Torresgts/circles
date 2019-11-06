using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    void Start()
    {
        //PlayGame();
    }

    public void PlayGame()
    {
        //StartCoroutine(StartGameplay());
        EventManager.OnPlayGame.Invoke();
    }

    IEnumerator StartGameplay()
    {
        yield return new WaitForSeconds(1f);
        EventManager.OnPlayGame.Invoke();
    }

}
