using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    public PlayerMovement monPlayer;
    [SerializeField]
    private GameObject _monExplosion;
    public int explosionLenght;

    public WallManager myWalls;

    private float durability = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), 0);
        Invoke("Exploded", 2);
    }

    private void Update()
    {
        durability += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Explosion>() != null)
        {
            //vérifie si l'explosion n'existait pas AVANT la bombe, si c'est le cas faut pas exploser frame 1
            if (collision.gameObject.GetComponent<Explosion>().durability < durability)
            {
                Exploded();
            }
        }
    }

    private void Exploded()
    {
        //Activation de la bombe
        monPlayer.currentBomb = Mathf.Clamp(monPlayer.currentBomb - 1, 0, monPlayer.maxBomb);

        var stopUp = false;
        var stopDown = false;
        var stopRight = false;
        var stopLeft = false;

        Instantiate(_monExplosion, transform.position, Quaternion.identity);
        for (int i = 0; i < explosionLenght; i++)
        {
            //explosion vers la droite
            if (stopRight == false)
            {
                Instantiate(_monExplosion, new Vector3(transform.position.x + (i + 1), transform.position.y, 0), Quaternion.identity);
                foreach (Transform child in myWalls.transform)
                {
                    if (child.position.x == transform.position.x + (i + 1) && (child.position.y == transform.position.y) && (child.CompareTag("isWall") == true))
                    {
                        stopRight = true;
                    }
                }
            }
            //explosion vers la gauche
            if (stopLeft == false)
            {
                Instantiate(_monExplosion, new Vector3(transform.position.x - (i + 1), transform.position.y, 0), Quaternion.identity);
                foreach (Transform child in myWalls.transform)
                {
                    if (child.position.x == transform.position.x - (i + 1) && (child.position.y == transform.position.y) && (child.CompareTag("isWall") == true))
                    {
                        stopLeft = true;
                    }
                }
            }
            //explosion vers le bas
            if (stopDown == false)
            {
                Instantiate(_monExplosion, new Vector3(transform.position.x, transform.position.y + (i + 1), 0), Quaternion.identity);
                foreach (Transform child in myWalls.transform)
                {
                    if (child.position.x == transform.position.x && (child.position.y == transform.position.y + (i + 1)) && (child.CompareTag("isWall") == true))
                    {
                        stopDown = true;
                    }
                }
            }
            //explosion vers le haut
            if (stopUp == false)
            {
                Instantiate(_monExplosion, new Vector3(transform.position.x, transform.position.y - (i + 1), 0), Quaternion.identity);
                foreach (Transform child in myWalls.transform)
                {
                    if (child.position.x == transform.position.x && (child.position.y == transform.position.y - (i + 1)) && (child.CompareTag("isWall") == true))
                    {
                        stopUp = true;
                    }
                }
            }
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //detruire la bombe si dans un mur
        if (collision.gameObject.tag == "isWall")
        {
            monPlayer.currentBomb = Mathf.Clamp(monPlayer.currentBomb - 1, 0, monPlayer.maxBomb);
            Destroy(gameObject);
        }
    }
}
