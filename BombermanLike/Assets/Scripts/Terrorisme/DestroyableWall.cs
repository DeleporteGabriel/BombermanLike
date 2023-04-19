using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableWall : MonoBehaviour
{
    [SerializeField]
    private PowerUpGiver _prefabPowerUp;

    private ScoreManager _myScore;

    private void Start()
    {
        if (FindObjectOfType<ScoreManager>() != null)
        {
            _myScore = FindObjectOfType<ScoreManager>();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Explosion>() != null)
        {
            if (Random.Range(0, 6) < 1)
            {
                var powerUp = Instantiate(_prefabPowerUp);
                powerUp.transform.position = transform.position;
                if (Random.Range(0, 4) < 1)
                {
                    powerUp.powerUpGiven = 1;
                }
                else
                {
                    powerUp.powerUpGiven = 0;
                }
            }
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (_myScore != null)
        {
            _myScore.score++;
            _myScore.scoreText.text = "cibles restantes : " + (_myScore.maxScore - _myScore.score).ToString();
        }
    }
}
