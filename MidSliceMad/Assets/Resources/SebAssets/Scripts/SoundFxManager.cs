using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*****************************************************************************
 *SoundFxManager: Singleton
 * - Manages SoundFx and Audio in the game
 *  Only hase one function used to play a wav or ogg file
 *  mp3's do not currently work in unity
 *
 *  To refer to SoundFxManager use: SoundFxManager.Instance
 *
 *
 *
 *
 *****************************************************************************/
public class SoundFxManager : MonoBehaviour
{


    [SerializeField] private AudioSource soundFXobj;

    public static SoundFxManager Instance;


    //make Class a singleton
   

    private void Awake()
    {

        

        Debug.Log($"Initializing Singleton");
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Ensure that the singleton persists between scene changes
            
        }
        else
        {
            Destroy(gameObject); // Destroy additional instances
        }
    }


   




    //plays a sound effect, float goes from 
    //0-1 1 being full volume
    //just pass "transform" for ts
    //pass the audioclip you want to play for ac
   public void playSFX(AudioClip ac, Transform ts, float volume)
   {

        Debug.Log($"Playing Sfx");
        //spawn gameobj
        AudioSource audioSource = Instantiate(soundFXobj, ts.position, Quaternion.identity);

        //assign to audioclip
        audioSource.clip = ac;

        //assign volume
        audioSource.volume = volume;

        //play sound
        audioSource.Play();

        //get length of clip
        float clipLength = audioSource.clip.length;

        //deallocate
        Destroy(audioSource.gameObject, clipLength);


   }


}
