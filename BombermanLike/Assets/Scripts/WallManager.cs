using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    [SerializeField]
    private int _wallNumber;
    [SerializeField]
    private GameObject _wallPrefab;
    [SerializeField]
    private Transform _rangeMin, _rangeMax;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _wallNumber; i++)
        {
            var tempX = Random.Range(_rangeMin.position.x, _rangeMax.position.x);
            var tempY = Random.Range(_rangeMin.position.y, _rangeMax.position.y);
            var monInstance = Instantiate(_wallPrefab, transform);

            monInstance.transform.position = new Vector3(tempX, tempY, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
