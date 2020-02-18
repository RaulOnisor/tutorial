using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ball : MonoBehaviour
{
    
    public float speed = 5f;

    public GameManager manager;
    public int basicScore = 1;
    public int specialScore = 5;
    Vector3 screenHeight;
    float currentScreenHeight;
    float scoreMultiplierRatio = 4;
    float maxScoreMultiplaier;
   
    void Start()
    {
        screenHeight = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));
        currentScreenHeight = screenHeight.y;
        maxScoreMultiplaier = currentScreenHeight / scoreMultiplierRatio;
        manager = (GameManager)FindObjectOfType(typeof(GameManager));
    }

    void Update()
    {
        transform.Translate(-Vector3.up * Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="catcher")
        {

            if(transform.position.y>maxScoreMultiplaier)
            {
                manager.IncreaseScore(basicScore);
            }
            else
            {
                manager.IncreaseScore(specialScore);
            }
            Destroy(this.gameObject);
        }
        if(collision.gameObject.tag=="killZone")
        {
            Scene cs = SceneManager.GetActiveScene();
            SceneManager.LoadScene(cs.name);
        }
    }
}
