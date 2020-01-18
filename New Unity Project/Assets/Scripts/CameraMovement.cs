using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    Vector3 offset = new Vector3(0, 5f, -30f);
    void Start()
    {
        player = GameObject.Find("Rocket Ship");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
