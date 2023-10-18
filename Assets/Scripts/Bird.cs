using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bird : MonoBehaviour
{
    public float jumpSpeed;
    public float rotateScale;
    public float speed;
    public int score;
    public GameObject endScreen;

    public GameObject yellowBird;
    public GameObject redBird;
    public GameObject blueBird;
    public GameObject flash;



    public TMP_Text scoreText;
    Rigidbody2D rb;

    public AudioSource scoreSource;
    public AudioSource deathSound;
    public AudioSource jumpSound;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Pipe.speed = speed;

        ChooseBird();

        scoreSource = GetComponent<AudioSource>();
        deathSound = GetComponent<AudioSource>();
        jumpSound = GetComponent<AudioSource>();
    }

    public void ChooseBird()
    {
        var rnd = Random.Range(0f, 1f);
        if (rnd < 0.33f)
        {
            yellowBird.SetActive(true);
        }
        else if (rnd < 0.66)
        {
            redBird.SetActive(true);
        }
        else
        {
            blueBird.SetActive(true);
        }
    }

    void Update()
    {
        

        if ( Input.GetKeyDown(KeyCode.Mouse0))
        {
            rb.velocity = Vector2.up * jumpSpeed;
            jumpSound.Play();
            
        }

        transform.eulerAngles = new Vector3(0, 0, rb.velocity.y * rotateScale);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }

    void Die()
    {
        //var currentScene = SceneManager.GetActiveScene().name;
        //SceneManager.LoadScene(currentScene);

        Pipe.speed = 0;
        jumpSpeed = 0;
        Invoke("ShowMenu", 1f);

        PlayerPrefs.SetInt("score", score);
        flash.SetActive(true);

        deathSound.Play();
    }

    void ShowMenu()
    {
        endScreen.SetActive(true);
        scoreText.gameObject.SetActive(false);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score++;
        scoreText.text = score.ToString();
        scoreSource.Play();
    }
}
