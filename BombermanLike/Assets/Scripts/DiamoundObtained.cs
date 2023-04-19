using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamoundObtained : MonoBehaviour
{
    public PlayerPowerUpA myPlayer;
    public SpriteRenderer myDiamound;
    [SerializeField]
    private float _liveSpan;

    private void Start()
    {
        Invoke("DestroyObject", _liveSpan);
    }
    void Update()
    {

        transform.position = myPlayer.transform.position;
        transform.position += new Vector3(0, 0, 6);
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
