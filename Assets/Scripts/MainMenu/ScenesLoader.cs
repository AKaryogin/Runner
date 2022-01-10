using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesLoader : MonoBehaviour
{
    public void LoadLevelOne()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void LoadLevelTwo()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
