using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;


public static class EventManager 
{

    public static UnityEvent GoodTouch = new UnityEvent();
    public static UnityEvent Perfecttouch = new UnityEvent();
    public static UnityEvent FailedTouch = new UnityEvent();

    public static UnityEvent SetGameplayTimeParameter = new UnityEvent();
    public static UnityEvent SetGameplayScaleParameters = new UnityEvent();


   public static UnityEvent IncrementScore = new UnityEvent();
   public static UnityEvent IncrementBonusScore = new UnityEvent();
   public static UnityEvent IncrementScoreText = new UnityEvent();

   public static UnityEvent ReduceCircleScaleLerp = new UnityEvent();
   
}

public class ImageEvent : UnityEvent<Image> { };

public class FloatEvent : UnityEvent<float, float> { };


