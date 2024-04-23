using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraQuarterView : MonoBehaviour
{
    [SerializeField]
    float offsetY = 4;
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x-10, (float)(player.transform.position.y+9.5), player.transform.position.z-10);
    }
}
