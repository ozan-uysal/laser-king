using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this; 
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    public void UpdateScore()
    {
        score++;
        text.text = score.ToString();
    }
    public void LowerScore()
    {
        if (score <= 0) { return; }

        score--;
        text.text = score.ToString();
    }

}
