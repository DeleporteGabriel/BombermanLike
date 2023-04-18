using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableWall : MonoBehaviour
{
    [SerializeField]
    private PowerUpGiver _prefabPowerUp;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Explosion>() != null)
        {
            if (Random.Range(0, 6) < 1)
            {
                var powerUp = Instantiate(_prefabPowerUp);
                powerUp.transform.position = transform.position;
                powerUp.powerUpGiven = Random.Range(0, 2);
            }
            Destroy(gameObject);
        }
    }
}
