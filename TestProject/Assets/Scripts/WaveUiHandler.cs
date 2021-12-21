using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveUiHandler : MonoBehaviour
{
    public WaveHandler waveSystem;
    public Text waveText;
    public GameObject waveOverScreen;
    private void Awake()
    {
        waveSystem.OnWaveStarted += OnWaveStarted;
        waveSystem.OnWaveEnded += OnWaveEnded;
    }

    private void OnWaveEnded(object sender, WaveEventArgs e)
    {
        waveOverScreen.SetActive(true);
        waveOverScreen.GetComponent<Animator>().Play("WaveOver");
    }

    private void OnWaveStarted(object sender, WaveEventArgs e)
    {
        waveText.text = e.wave.ToString();
    }
}
