using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int score, maxScore;

    [SerializeField]
    private WallManager _myWalls;
    public TextMeshProUGUI scoreText;

    [SerializeField]
    private TextMeshProUGUI _timerText;

    [SerializeField]
    private float _timerLeft;

    private void Start()
    {
        maxScore = _myWalls.wallNumber;
        scoreText.text = "cibles restantes : " + (maxScore - score).ToString();
    }

    private void Update()
    {
        if (score >= maxScore)
        {
            SceneManager.LoadScene("SceneVictoire");
        }

        _timerLeft -= Time.deltaTime;
        _timerText.text = Mathf.Floor(_timerLeft).ToString();

        if (_timerLeft <= 0)
        {
            SceneManager.LoadScene("SceneVictoire");
        }
    }
}
