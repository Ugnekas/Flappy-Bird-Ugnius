using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pipe : MonoBehaviour
{
    public static float speed; //static reiskia negalesim pakeisti vertes, visiems objektams bus vienoda
    public float screenStartX;
    public float screenEndX;
    public int score;
    public TMP_Text scoreText;

    

    // Start is called before the first frame update
    void Start()
    {
        screenStartX = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0.5f)).x - 1;
        screenEndX = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0.5f)).x + 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < screenStartX)
        {
            var heightOffset = Random.Range(-2, 4);
            transform.position = new Vector3(screenEndX, heightOffset);
            
        }
    }

    
}
