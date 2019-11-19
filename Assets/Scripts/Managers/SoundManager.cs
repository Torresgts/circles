using UnityEngine.Audio;
using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
   public Sound[] sounds;

   private void OnEnable() 
   {
      EventManager.OnPlaySound.AddListener(PlaySound);
   }
   private void OnDisable()
   {
       EventManager.OnPlaySound.RemoveListener(PlaySound);
   }

   private void Awake() 
   {
      foreach(Sound s in sounds)
      {
         s.source = gameObject.AddComponent<AudioSource>();
         s.source.clip = s.clip;

         s.source.volume = s.volume;
         s.source.pitch = s.pitch;

      }
   }

   public void PlaySound(string name)
   {
      Sound s = Array.Find(sounds, sound => sound.name == name);
      s.source.Play();
   }

}
