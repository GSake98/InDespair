using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseMusic : MonoBehaviour
{
    private AudioSource player;
    public float fadeInMultiplier = 2f;
    public float fadeOutMultiplier = 0.5f;

    void Start()
    {
        player = GetComponent<AudioSource>();
        player.volume = 0;
    }

    void Update()
    {
        if (SaveScript.enemiesChasing > 0)
        {
            if (player.isPlaying != true)
            {
                player.Play();
            }
            if (player.volume < 0.35f)
            {
                player.volume += fadeInMultiplier * Time.deltaTime;
            }
        }
        else if (SaveScript.enemiesChasing == 0)
        {
            if (player.volume > 0.0f)
            {
                player.volume -= fadeOutMultiplier * Time.deltaTime;
            }
            if (player.volume == 0)
            {
                if (player.isPlaying == true)
                {
                    player.Stop();
                }
            }
        }

        ChaseMusicStoppedAndResumed();
    }

    void ChaseMusicStoppedAndResumed()
    {
        if (Time.timeScale == 0)
        {
            player.Pause();
        }
        else if (Time.timeScale == 1)
        {
            player.UnPause();
        }
    }
}
