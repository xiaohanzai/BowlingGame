using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIFrame : MonoBehaviour
{
    public TextMeshProUGUI textNum;
    public TextMeshProUGUI textL;
    public TextMeshProUGUI textR;
    public TextMeshProUGUI textScore;

    private int numFirstThrow;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetFrameScore(int numPin)
    {
        if (GameManager.instance.numOfThrow == 1)
        {
            if (numPin == 10)
            {
                textR.text = "X";
                UIManager.instance.ShowStrikeImage();
                textScore.text = numPin.ToString();
            }
            else
            {
                textL.text = numPin.ToString();
                numFirstThrow = numPin;
            }
        }
        else
        {
            if (numPin + numFirstThrow == 10)
            {
                textR.text = "/";
                UIManager.instance.ShowSpareImage();
            }
            else
            {
                textR.text = numPin.ToString();
            }
            textScore.text = (numPin + numFirstThrow).ToString();
        }
    }

    public void Reset()
    {
        textL.text = "";
        textR.text = "";
        textScore.text = "";
    }
}
