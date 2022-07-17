using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteUnmute : MonoBehaviour
{
    public void _MuteUnmute()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Audio");
        obj.GetComponent<AudioSource>().mute = !obj.GetComponent<AudioSource>().mute;
    }
}
