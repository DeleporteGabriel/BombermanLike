using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    public int wallNumber;
    [SerializeField]
    private List<DestroyableWall> _mesWalls;
    
    void Start()
    {
        wallNumber = Mathf.Clamp(wallNumber, 0, _mesWalls.Count);

        //spawn des murs
        for (int i = 0; i < wallNumber; i++)
        {
            var myWall = Random.Range(0, _mesWalls.Count);
            _mesWalls[myWall].gameObject.SetActive(true);
            _mesWalls.Remove(_mesWalls[myWall]);
           
        }
    }
}
