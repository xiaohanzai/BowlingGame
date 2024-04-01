using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int totalScore;
    public int currentFrameScore;
    public int currentFrame;

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
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FinishFrame()
    {
        PitController.instance.ResetAllPins();
        totalScore += currentFrameScore;
        currentFrameScore = 0;
        currentFrame++;
        if (currentFrame == 10)
        {
            UIManager.instance.FinishGame();
        }
    }

    public void SetFrameScore(int numPinsFallen)
    {
        currentFrameScore += numPinsFallen;
        UIManager.instance.SetScoreOnCurrentFrame(numPinsFallen);
        if (currentFrameScore == 10 && GameManager.instance.numOfThrow == 1 || GameManager.instance.numOfThrow == 2)
        {
            GameManager.instance.Strike();
            FinishFrame();
        }
        else
        {
            GameManager.instance.PrepareForThrow();
        }
    }

    public void Reset()
    {
        totalScore = 0;
        currentFrame = 0;
        currentFrameScore = 0;
    }
}
