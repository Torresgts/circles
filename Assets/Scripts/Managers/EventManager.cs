using UnityEngine.Events;


public static class EventManager 
{
    public static UnityEvent OnGoodTouch = new UnityEvent();
    public static UnityEvent OnPerfectTouch = new UnityEvent();
    public static UnityEvent OnFailedTouch = new UnityEvent();


    public static UnityEvent OnMainMenu = new UnityEvent();
    public static UnityEvent OnPlayGame = new UnityEvent(); 


}

//public class ImageEvent : UnityEvent<Image> { };

//public class FloatEvent : UnityEvent<float, float> { };


