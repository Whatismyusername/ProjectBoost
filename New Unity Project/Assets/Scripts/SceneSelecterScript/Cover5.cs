using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cover5 : MonoBehaviour
{
    bool MoveUp = false;
    private Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.highestLevel >= 5) {
            MoveUp = true;
        }

        destination = new Vector3(transform.position.x, 56, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(MoveUp && transform.position != destination) {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z);
        }
        if(transform.position.y >= destination.y) {
            transform.position = destination;
            MoveUp = false;
        }
    }
}