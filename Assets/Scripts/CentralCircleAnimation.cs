using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralCircleAnimation : MonoBehaviour
{
   private Animator anim;

   private void OnEnable() 
   {
       EventManager.OnGoodTouch.AddListener(PlayGoodTouchAnim);
       EventManager.OnPerfectTouch.AddListener(PlayPerfectTouchAnim);
   }

   private void OnDisable() 
   {
       EventManager.OnGoodTouch.RemoveListener(PlayGoodTouchAnim);
       EventManager.OnPerfectTouch.RemoveListener(PlayPerfectTouchAnim);
   }

   private void Awake() 
   {
       anim = this.gameObject.GetComponent<Animator>();
   }

   public void PlayGoodTouchAnim()
   {
       anim.SetTrigger("OnGoodTouch");
   }

   public void PlayPerfectTouchAnim()
   {
       anim.SetTrigger("OnPerfectTouch");
   }
}
