using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource collisionPlayer;
    public AudioSource bouncepadPlayer;

    public AudioClip[] collisionSounds;
    public AudioClip[] bouncepadSounds;

    public void PlayCollisonSound()
    {
        int randomIndex = Random.Range(0, collisionSounds.Length);
        collisionPlayer.clip = collisionSounds[randomIndex];
        collisionPlayer.Play();
    }

    public void PlayBouncepadSound()
    {
        int randomIndex = Random.Range(0, bouncepadSounds.Length);
        bouncepadPlayer.clip = bouncepadSounds[randomIndex];
        bouncepadPlayer.Play();
    }
}
