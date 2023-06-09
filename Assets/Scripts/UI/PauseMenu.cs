using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pMenu;
    public GameObject oMenu;
    public GameObject dotUI;
    public static bool isPaused;
    AudioSource pm_AudioSource;
    [SerializeField] Button _exitGame;

    public static PauseMenu Instance = null;
    
    void Awake()
    {
        // If there is not already an instance of PauseMenu, set it to this.
		if (Instance == null)
		{
			Instance = this;
		}
		//If an instance already exists, destroy whatever this object is to enforce the singleton.
		else if (Instance != this)
		{
			Destroy(gameObject);
		}

		//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
		DontDestroyOnLoad (gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        pMenu.SetActive(false);
        oMenu.SetActive(false);
        isPaused = false;
        pm_AudioSource = GetComponent<AudioSource>();
        _exitGame.onClick.AddListener(QuitToMM);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Delete))
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
        pm_AudioSource.Play();
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
        pm_AudioSource.Stop();
    }

    public void OpenOptions()
    {
        oMenu.SetActive(true);
    }

    public void CloseOptions()
    {
        oMenu.SetActive(false);
    }

    public void QuitToMM()
    {
        pMenu.SetActive(false);
        oMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        pm_AudioSource.Stop();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        ScenesManager.Instance.LoadMainMenu();
    }
}
