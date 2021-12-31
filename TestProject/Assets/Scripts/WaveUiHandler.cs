using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class WaveUiHandler : MonoBehaviour
{
    public WaveHandler waveSystem;
    public Text waveText;
    public Text waveOverText;
    public Text waveOverQuote;
    public GameObject waveOverScreen;

    private string[] quotes = 
      { "We each survive in our own way." ,
        "They feel no fear, why should you?" ,
        "Organize before they rise!" ,
        "Use your head: cut off theirs" ,
        "No place is safe, only safer." ,
        "The zombie may be gone, but the threat lives on" ,
        "Hesitate and it will be the end of you." ,
        "It was only the beggining." ,
        "Keep calm and aim for the head." };
    private void Awake()
    {
        waveSystem.OnWaveStarted += OnWaveStarted;
        waveSystem.OnWaveEnded += OnWaveEnded;
    }

    private void OnWaveEnded(object sender, WaveEventArgs e)
    {
        waveOverScreen.SetActive(true);
        int previousWave = e.wave;
        waveOverText.text = "Wave " + previousWave + " survived";
        waveOverQuote.text = quotes[Random.Range(0, quotes.Length)];
        waveOverScreen.GetComponent<Animator>().Play("WaveOver");
    }

    private void OnWaveStarted(object sender, WaveEventArgs e)
    {
        waveText.text = e.wave.ToString();
    }
}
