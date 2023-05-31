using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource musicFutur;
    public AudioSource musicPast;

    public void Fpriority() {
        musicFutur.mute = false;
        musicPast.mute = true;
    }
    public void Ppriority() {
        musicFutur.mute = true;
        musicPast.mute = false;
    }
}
