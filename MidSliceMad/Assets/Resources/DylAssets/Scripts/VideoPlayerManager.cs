using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerManager : MonoBehaviour
{
    [SerializeField] private VideoClip[] videoClips;
    [SerializeField] private VideoPlayer videoPlayer;
    private int currentVideoIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (videoClips.Length == 0)
        {
            Debug.LogError("No video clips assigned!");
            return;
        }

        videoPlayer.loopPointReached += OnVideoFinished;
        PlayNextVideo();
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        currentVideoIndex++;
        if (currentVideoIndex < videoClips.Length)
        {
            PlayNextVideo();
        }
        else
        {
            Debug.Log("Finished all videos.");
            currentVideoIndex = 0;
            PlayNextVideo();
        }
    }

    void PlayNextVideo()
    {
        videoPlayer.clip = videoClips[currentVideoIndex];
        videoPlayer.Prepare(); // Prepare the video to play
        videoPlayer.Play();
    }
}
