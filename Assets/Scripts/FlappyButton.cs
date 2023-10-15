using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyButton : MonoBehaviour
{
    public string nextSceneName;

    

 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        transform.position += Vector3.down * 0.1f;
    }
    void OnMouseUp()
    {
        transform.position += Vector3.up * 0.1f;

        if (nextSceneName != "")
        {
            SceneManager.LoadScene(nextSceneName);
            
            
        }
    }
}
