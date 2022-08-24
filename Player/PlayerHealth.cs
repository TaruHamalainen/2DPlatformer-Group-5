using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] Text playerScoreText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Image[] healthPoints;
    [SerializeField] Transform afterPoisonPosition;







    private void Start()
    {
        scoreText.text = "" + GameManager.manager.scores;
    }
    private void Update()
    {
        UpdateHealthBar();
    }
    public void UpdateHealthBar()
    {
        for (int i = 0; i < healthPoints.Length; i++)
        {
            healthPoints[i].enabled = !DisplayeyHealthPoint(GameManager.manager.health, i);
        }
    }
    public bool DisplayeyHealthPoint(float _health, int pointNumber)
    {
        return ((pointNumber * 10) >= _health);
    }
    public void UpdateScores(int scores)
    {
        GameManager.manager.scores += scores;
        scoreText.text = "" + GameManager.manager.scores;
    }
    public void TakeDamage(float damageAmount)
    {
        if (GameManager.manager.health > 0)
        {
            AudioManager.audioManager.PlaySound(AudioManager.audioManager.playerHurt);
            GameManager.manager.health -= damageAmount;
        }

    }
    public void Heal()
    {
        if (GameManager.manager.health < GameManager.manager.maxHealth)
        {
            AudioManager.audioManager.PlaySound(AudioManager.audioManager.heal);
            GameManager.manager.health += 10;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Heal"))
        {
            Heal();
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Item"))
        {
            AudioManager.audioManager.PlaySound(AudioManager.audioManager.score);
            UpdateScores(1);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Cleared"))
        {
            SceneManager.LoadScene(4);
        }
        if (other.gameObject.CompareTag("Poison"))
        {
            SceneManager.LoadScene(2);
        }
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            TakeDamage(10);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("FireFly"))
        {
            TakeDamage(other.collider.GetComponent<FireFly>().damageAmount);
        }
        if (other.gameObject.CompareTag("PatrolEnemy"))
        {
            if (transform.position.y > other.transform.position.y + other.transform.localScale.y)
            {

                other.gameObject.GetComponent<PatrollingEnemy>().Die();
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * 3f, ForceMode2D.Impulse);

            }
            else
                TakeDamage(other.gameObject.GetComponent<PatrollingEnemy>().damageAmount);
        }
        if (other.gameObject.CompareTag("ShootingEnemy"))
        {
            TakeDamage(other.collider.GetComponent<ShootingEnemy>().damageAmount);
        }

    }

}
