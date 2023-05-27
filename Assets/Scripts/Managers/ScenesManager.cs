using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance;
    
    private void Awake()
    {
        Instance = this;
    }

    public enum Scene
    {
        MainMenu,
        Level01
    }

    public void LoadScene(Scene scene)
    {
        SceneCleanup();
        SceneManager.LoadScene(scene.ToString());
    }

    public void LoadNewGame()
    {
        SceneCleanup();
        SceneManager.LoadScene(Scene.Level01.ToString());
    }

    // alter these two when each of their scenes are created

    public void LoadLevel02()
    {
        SceneCleanup();
        SceneManager.LoadScene(Scene.Level01.ToString());
    }

    public void LoadLevel03()
    {
        SceneCleanup();
        SceneManager.LoadScene(Scene.Level01.ToString());
    }

    public void LoadNextScene()
    {
        SceneCleanup();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMainMenu()
    {
        SceneCleanup();
        SceneManager.LoadScene(Scene.MainMenu.ToString());
    }

    public void SceneCleanup()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("GM");
        if (gm != null) {
            Destroy(gm);
        }
    }
}
