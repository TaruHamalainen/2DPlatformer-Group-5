using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public void BackToMenu(int levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
