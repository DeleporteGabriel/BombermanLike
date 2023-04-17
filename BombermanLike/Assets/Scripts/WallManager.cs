using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    [SerializeField]
    private int _wallNumber;
    [SerializeField]
    private List<DestroyableWall> _mesWalls;
    

    // Start is called before the first frame update
    void Start()
    {
        _wallNumber = Mathf.Clamp(_wallNumber, 0, _mesWalls.Count);

        //spawn des murs
        for (int i = 0; i < _wallNumber; i++)
        {
            var myWall = Random.Range(0, _mesWalls.Count);
            _mesWalls[myWall].gameObject.SetActive(true);
            _mesWalls.Remove(_mesWalls[myWall]);
           
        }
    }
}
