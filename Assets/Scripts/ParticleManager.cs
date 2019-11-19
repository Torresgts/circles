using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{

      [SerializeField]
    private ParticleSystem circleExplosionOnTouch;
    private ParticleSystem.EmissionModule emission;

    private void OnEnable() 
    {
        EventManager.OnGoodTouch.AddListener(PlayOnGoodTouchParticle);
        EventManager.OnPerfectTouch.AddListener(PlayOnPerfectTouchParticle);
    }

    private void OnDisable() 
    {
        EventManager.OnGoodTouch.RemoveListener(PlayOnGoodTouchParticle);
        EventManager.OnPerfectTouch.RemoveListener(PlayOnPerfectTouchParticle);
    }

    private void Awake() 
    {
        emission = circleExplosionOnTouch.emission;
    }

    public void PlayOnGoodTouchParticle()
    {
        emission.rateOverTime = 80;
        circleExplosionOnTouch.Play();
    } 

    public void PlayOnPerfectTouchParticle()
    {
        emission.rateOverTime = 300;
        circleExplosionOnTouch.Play();
    } 
}
