using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public int currentLife;
    [SerializeField]
    private int _maxLife;
    // Start is called before the first frame update
    void Start()
    {
        currentLife = _maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
