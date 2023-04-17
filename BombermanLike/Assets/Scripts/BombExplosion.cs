using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    public PlayerMovement monPlayer;
    [SerializeField]
    private GameObject _monExplosion;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Exploded", 2);
    }

    private void Exploded()
    {
        monPlayer.currentBomb -= 1;
        var decalage = 0.8f;
        Instantiate(_monExplosion, transform.position, Quaternion.identity);
        Instantiate(_monExplosion, new Vector3(transform.position.x + decalage, transform.position.y, 0), Quaternion.identity);
        Instantiate(_monExplosion, new Vector3(transform.position.x - decalage, transform.position.y, 0), Quaternion.identity);
        Instantiate(_monExplosion, new Vector3(transform.position.x, transform.position.y + decalage, 0), Quaternion.identity);
        Instantiate(_monExplosion, new Vector3(transform.position.x, transform.position.y - decalage, 0), Quaternion.identity);
        Destroy(gameObject);
    }
}
