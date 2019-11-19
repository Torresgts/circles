using UnityEngine.Events;


public static class EventManager 
{
    public static UnityEvent OnGoodTouch = new UnityEvent();
    public static UnityEvent OnPerfectTouch = new UnityEvent();
    public static UnityEvent OnFailedTouch = new UnityEvent();



    public static UnityEvent OnMainMenu = new UnityEvent();
    //All Gameplay UI enables
    public static UnityEvent OnPlayGameButton = new UnityEvent(); 


    // All parameters and scripts to enable
    public static UnityEvent OnStartGameplay = new UnityEvent();

    public static UnityEvent OnUpdateUI = new UnityEvent();


    // After Playfab Login - This Event is Called
    public static UnityEvent OnGameVersionChanged = new UnityEvent();
    public static UnityEvent OnGameDataUpdated = new UnityEvent();
    public static UnityEvent OnGameDataNotUpdated = new UnityEvent();


    public static StringEvent OnPlaySound = new StringEvent();


}

//public class ImageEvent : UnityEvent<Image> { };

//public class FloatEvent : UnityEvent<float, float> { };

[System.Serializable]
public class StringEvent : UnityEvent<string> { };


