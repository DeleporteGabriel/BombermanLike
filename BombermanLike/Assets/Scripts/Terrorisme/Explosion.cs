using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float durability = 0;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyExplosion", 1);
    }

    private void Update()
    {
        durability += Time.deltaTime;
    }

    private void DestroyExplosion()
    {
        Destroy(gameObject);
    }
}
