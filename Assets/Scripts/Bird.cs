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

    public GameObject[] birds;


    public TMP_Text scoreText;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Pipe.speed = speed;

        if (birds.Length < 2)
        {
            Debug.LogError("You need to assign at least 2 bird GameObjects in the Inspector.");
            return;
        }

        // Choose a random index within the range of the 'birds' array
        int randomIndex = Random.Range(0, birds.Length);

        // Activate the selected bird and deactivate the others
        for (int i = 0; i < birds.Length; i++)
        {
            birds[i].SetActive(i == randomIndex);
        }

    }

    void Update()
    {
        

        if ( Input.GetKeyDown(KeyCode.Mouse0))
        {
            rb.velocity = Vector2.up * jumpSpeed;
            
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
    }
}
