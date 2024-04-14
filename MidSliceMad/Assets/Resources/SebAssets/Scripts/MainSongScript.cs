using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSongScript : MonoBehaviour
{


     [SerializeField]
    private AudioClip sfxClip;
    // Start is called before the first frame update
    void Start()
    {
        SoundFxManager.Instance.playSFX(sfxClip, transform, 1f);
    }


}
