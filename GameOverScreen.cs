using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene(2);
    }
    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
