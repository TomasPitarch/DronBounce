using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
   static Dictionary<string,AudioSource> AudioDictionary;


    private void Start()
    {
        AudioDictionary = new Dictionary<string, AudioSource>();
        var listOfSounds = GetComponentsInChildren<AudioSource>();

        foreach (var val in listOfSounds)
        {
            AudioDictionary.Add(val.name, val);
        }
    }
    internal static void Play(string selectSound)
    {
        var SoundFounded = AudioDictionary[selectSound];

        if (SoundFounded != null)
        {
            SoundFounded.Play();
        }
    }
}
