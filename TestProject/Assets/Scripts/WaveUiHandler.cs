using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveUiHandler : MonoBehaviour
{
    public WaveHandler waveSystem;
    public Text waveText;
    private void Awake()
    {
        waveSystem.OnWaveStarted += OnWaveStarted;
    }

    private void OnWaveStarted(object sender, WaveEventArgs e)
    {
        waveText.text = e.wave.ToString();
    }
}
