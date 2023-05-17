using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public GameObject pMenu;
    public GameObject oMenu;
    public GameObject dotUI;
    public AudioMixer audioMixer;
    public static bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        pMenu.SetActive(false);
        oMenu.SetActive(false);
        isPaused = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                ResumeGame();
            } else {
                PauseGame();
            }

        }
        
    }

    public void PauseGame()
    {
        pMenu.SetActive(true);
        dotUI.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        isPaused = true;
        AudioListener.volume = 0;
    }

    public void ResumeGame()
    {
        pMenu.SetActive(false);
        oMenu.SetActive(false);
        dotUI.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        isPaused = false;
        AudioListener.volume = 1;
    }

    public void OpenOptions()
    {
        oMenu.SetActive(true);
    }

    public void CloseOptions()
    {
        oMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
