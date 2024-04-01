using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public UIFrame[] frames;
    public GameObject finishCanvas;
    public TextMeshProUGUI totalScoreText;

    public GameObject strikeImage;
    public GameObject spareImage;

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

    public void SetScoreOnCurrentFrame(int numPin)
    {
        frames[ScoreManager.instance.currentFrame].SetFrameScore(numPin);
    }

    public void FinishGame()
    {
        finishCanvas.SetActive(true);
        totalScoreText.text = "Total Score: " + ScoreManager.instance.totalScore.ToString();
    }

    public void ShowStrikeImage()
    {
        strikeImage.SetActive(true);
        Invoke("HideImages", 2f);
    }

    public void ShowSpareImage()
    {
        spareImage.SetActive(true);
        Invoke("HideImages", 2f);
    }

    public void HideImages()
    {
        strikeImage.SetActive(false);
        spareImage.SetActive(false);
    }

    public void Reset()
    {
        finishCanvas.SetActive(false);
        strikeImage.SetActive(false);
        spareImage.SetActive(false);
        for (int i = 0; i < frames.Length; i++)
        {
            frames[i].textNum.text = (i + 1).ToString();
            frames[i].Reset();
        }
    }
}
