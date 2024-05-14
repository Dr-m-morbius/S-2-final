using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class titlescreen : MonoBehaviour
{
    public int startingScene;

    public void OnPlayButtonPressed()
    {
        SceneManager.LoadScene(startingScene);
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }

}