using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    Rigidbody rigidBody;
    AudioSource audioSource;

    Vector3 ThrustForce = new Vector3(0, 1200f, 0);
    Vector3 Rotation = new Vector3(0, 0, 180f);
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
    }

    private void Thrust() {
        if (Input.GetKey(KeyCode.Space)) {
            //Thrust
            rigidBody.AddRelativeForce(ThrustForce * Time.deltaTime);
        } 
        if (Input.GetKeyDown(KeyCode.Space)) {
            audioSource.Play();
        }
        else if(Input.GetKeyUp(KeyCode.Space)) {
            audioSource.Stop();
        }
    }

    private void Rotate() {
        if (Input.GetKey(KeyCode.A)) {
            rigidBody.freezeRotation = true;
            //Turn left
            transform.Rotate(Rotation * Time.deltaTime);
            rigidBody.freezeRotation = false;
        } else if (Input.GetKey(KeyCode.D)) {
            rigidBody.freezeRotation = true;
            //Turn Right
            transform.Rotate(-Rotation * Time.deltaTime);
            rigidBody.freezeRotation = false;
        }
    }

    private void OnCollisionEnter(Collision other) {
        
        switch(other.gameObject.tag) {
            case "Friendly":
                break;
            case "Respawn":
                break;
            case "Station":
                // Freezes motion
                rigidBody.velocity = new Vector3(0, 0, 0);
                break;
            default:
                Debug.Log("DEAD");
                break;
        }
    }

    private void fixRotation() {
        if (transform.position.z != 0) {
            transform.position = new Vector3 (transform.position.x, transform.position.y, 0f);
        }
    }
}
