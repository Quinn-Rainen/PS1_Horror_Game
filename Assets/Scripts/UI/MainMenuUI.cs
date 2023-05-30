using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] Button _newGame;
    AudioSource mm_AudioSource;

    void Start()
    {
        _newGame.onClick.AddListener(StartNewGame);
        mm_AudioSource = GetComponent<AudioSource>();
        mm_AudioSource.Play();
    }

    private void StartNewGame()
    {
        mm_AudioSource.Stop();
        ScenesManager.Instance.LoadNewGame();
    }
}
