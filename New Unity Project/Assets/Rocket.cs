using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    Rigidbody rigidBody;
    private Vector3 ThrustForce = new Vector3(0, 1500, 0);
    private Vector3 Rotation = new Vector3(0, 0, 100);
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        OnUserInput();
    }

    private void OnUserInput() {
        if (Input.GetKey(KeyCode.Space)) {
            //Thrust
            rigidBody.AddRelativeForce(ThrustForce * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A)) {
            //Turn left
            transform.Rotate(Rotation * Time.deltaTime);

        } else if (Input.GetKey(KeyCode.D)) {
            //Turn Right
            transform.Rotate(-Rotation * Time.deltaTime);
        }
        
    }
}
