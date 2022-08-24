using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;

    public float previousHealth;
    public float maxHealth;
    public float health;
    public int scores;


    private void Awake()
    {
        if (manager == null)
            manager = this;

    }
    private void Update()
    {
        Gameover();
    }
    public void Gameover()
    {
        if (health <= 0)
        {
            AudioManager.audioManager.PlaySound(AudioManager.audioManager.gameOver);
            SceneManager.LoadScene(3);
        }
    }



}
