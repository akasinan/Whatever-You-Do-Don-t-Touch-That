using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrackWin : MonoBehaviour
{
    bool gameOver = false;
    public GameObject player;
    public GameObject screen;
    AudioSource turnon;
    VoiceClips vox;
    Animator anim;
    float timer;
    float gameTime = 120f;
    public float restartDelay = 5f;
    float restartTimer;
    public Material[] winlose;
    Renderer rend;
    GameObject screenglow;

    // Use this for initialization
    void Start()
    {
        vox = player.GetComponent<VoiceClips>();
        anim = GetComponent<Animator>();
        rend = screen.GetComponent<Renderer>();
        rend.sharedMaterial = winlose[0];
        turnon = GetComponent<AudioSource>();
        screenglow = GameObject.FindGameObjectWithTag("Screen");
        screenglow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //If 120 seconds passes the game is over.
        //If the object has been touched, the game is over.
        if (timer >= gameTime && vox.touched)
        {
            gameOver = true;
            Lose();
        }
        if (timer >= gameTime && !vox.touched)
        {
            gameOver = true;
            Win();
        }
    }

    void Win()
    {
        turnon.Play();
        screenglow.SetActive(true);
        anim.SetTrigger("GameOver");
    }

    void Lose()
    {
        rend.sharedMaterial = winlose[1];
        turnon.Play();
        screenglow.SetActive(true);
        anim.SetTrigger("GameOver");
    }
}
