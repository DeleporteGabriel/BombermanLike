using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    public PlayerMovement monPlayer;
    [SerializeField]
    private GameObject _monExplosion;
    public int explosionLenght;
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
        for (int i = 0; i < explosionLenght; i++)
        {
            //explosion vers la droite
            Instantiate(_monExplosion, new Vector3(transform.position.x + decalage * (i + 1), transform.position.y, 0), Quaternion.identity);
            //explosion vers la gauche
            Instantiate(_monExplosion, new Vector3(transform.position.x - decalage * (i + 1), transform.position.y, 0), Quaternion.identity);
            //explosion vers le bas
            Instantiate(_monExplosion, new Vector3(transform.position.x, transform.position.y + decalage * (i + 1), 0), Quaternion.identity);
            //explosion vers le haut
            Instantiate(_monExplosion, new Vector3(transform.position.x, transform.position.y - decalage * (i + 1), 0), Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
