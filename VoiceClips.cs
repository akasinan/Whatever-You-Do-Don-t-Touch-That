using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceClips : MonoBehaviour
{
    AudioSource audioSrc;
    public AudioClip[] noTouchClips;
	public AudioClip[] nearTouchClips;
    public AudioClip[] touchClips;
    public AudioClip preamble;
    //GameObject lamp;
    //TrackTouch touch;
	HandStatus touch;
    bool start = true;
    float timer;
    float timeBetweenTouches = 4f;
    float timeBetweenWords = 15f;
    int i = 0;
	int noTouchClipsSize;
	public bool touched = false;
    bool timesup = false;

    // Use this for initialization
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        //lamp = GameObject.FindGameObjectWithTag("Lamp");
        //touch = lamp.GetComponent<TrackTouch>();
		touch = GetComponent<HandStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (start)
        {
            audioSrc.clip = preamble;
            audioSrc.Play();
            start = false;
        }
		if (!start && !touched && !touch.isNear && timer > timeBetweenWords && !timesup)
        {
			audioSrc.clip = noTouchClips [i];
			audioSrc.Play ();
			timer = 0f;
			i++;
            if (i == noTouchClips.Length)
                timesup = true;
            Debug.Log ("Time is passing");
        }
		if (touch.isNear && timer > timeBetweenTouches)
		{
			audioSrc.clip = nearTouchClips[Random.Range(0,nearTouchClips.Length)];
			audioSrc.Play();
			timer = 0f;
			Debug.Log ("Near");
		}
		if (touch.isTouching && timer > timeBetweenTouches)
        {
			if (touched == false)
				touched = true;
			audioSrc.clip = touchClips[Random.Range(0,touchClips.Length)];
            audioSrc.Play();
            timer = 0f;
			//touch.active = false;
			Debug.Log ("Touch");
        }
		//Debug.Log (timer);
    }
}
