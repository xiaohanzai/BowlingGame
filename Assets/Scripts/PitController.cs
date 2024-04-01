using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitController : MonoBehaviour
{
    public static PitController instance;

    public GameObject[] pins;
    public AudioSource audioSource;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            bool playStrikeAudio = false;
            foreach (var pin in pins)
            {
                if (pin.activeInHierarchy && pin.GetComponent<Pin>().playStrikeAudio)
                {
                    playStrikeAudio = true;
                }
            }
            if (playStrikeAudio)
            {
                audioSource.Play();
            }
            Destroy(other.gameObject);
            Invoke("CheckPins", 0.5f);
        }
    }

    public void CheckPins()
    {
        int numFallen = 0;
        foreach (var pin in pins)
        {
            if (pin.activeInHierarchy && pin.GetComponent<Pin>().CheckIsFallen())
            {
                pin.SetActive(false);
                numFallen++;
            }
        }

        ScoreManager.instance.SetFrameScore(numFallen);
        GameManager.instance.secondCamera.SetActive(false);
    }

    public void ResetAllPins()
    {
        foreach (var pin in pins)
        {
            pin.GetComponent<Pin>().ResetToStartPosition();
        }
    }
}
