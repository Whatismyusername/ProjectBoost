using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle2 : MonoBehaviour
{

    private Vector3 startingPos;
    private Vector3 DisplacementVector = new Vector3(0f, 7f, 0f);
    private float DisplacementFactor;
    private float secondsInBetween = 15f;
    private float period;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        period = Time.time / secondsInBetween * 2 * Mathf.PI;
        
        DisplacementFactor = Mathf.Sin(period);
        transform.position = startingPos + DisplacementVector * DisplacementFactor;
    }
}
