using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AudioData", menuName = "ScriptableObjects/AudioData", order = 1)]
public class Audio : ScriptableObject
{
    // Start is called before the first frame update
    public AudioClip m_buttonClic;
    public AudioClip m_pageTurnSingle;
    public AudioClip m_portal;
    public AudioClip m_death;
    public AudioClip m_deathHero;
}
