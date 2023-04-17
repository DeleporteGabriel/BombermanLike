using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyExplosion", 1);
    }

    private void DestroyExplosion()
    {
        Destroy(gameObject);
    }
}
