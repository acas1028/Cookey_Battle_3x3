using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;


public class TimelineController : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayableDirector playableDirector;
    public TimelineAsset timeline;

    public void Play()
    {
        playableDirector.Play();
    }

    public void PlayFromTimeline()
    {
        playableDirector.Play(timeline);
    }

    private void Update()
    {
        PlayFromTimeline();
    }
}
