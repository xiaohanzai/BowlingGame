using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int numOfThrow;
    public GameObject ballPrefab;

    public GameObject secondCamera;
    public Transform changePointTransform;

    private void Awake()
    {
        // Ensure there's only one instance of GameManager
        if (instance == null)
        {
            instance = this; // Set the instance to this object if it's null
            DontDestroyOnLoad(gameObject); // Optional: Keep GameManager alive between scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Strike()
    {
        numOfThrow = 0;
        PrepareForThrow();
    }

    public void PrepareForThrow()
    {
        if (ScoreManager.instance.currentFrame == 10)
        {
            return;
        }

        if (numOfThrow == 2)
        {
            numOfThrow = 0;
            ScoreManager.instance.FinishFrame();
        }

        if (numOfThrow < 2)
        {
            Instantiate(ballPrefab, transform.position, Quaternion.identity);
            numOfThrow++;
        }
    }

    public void StartGame()
    {
        numOfThrow = 0;
        ScoreManager.instance.Reset();
        UIManager.instance.Reset();
        secondCamera.SetActive(false);
        if (FindObjectOfType<BallController>() != null)
        {
            Destroy(FindObjectOfType<BallController>().gameObject);
        }
        PrepareForThrow();
    }
}
