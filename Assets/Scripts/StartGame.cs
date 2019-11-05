using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    void Start()
    {
        PlayGame();
    }

    public void PlayGame(){
        EventManager.SetGameplayTimeParameter.Invoke();
        EventManager.SetGameplayTimeParameter.Invoke();

        EventManager.ReduceCircleScaleLerp.Invoke();
    }

}
