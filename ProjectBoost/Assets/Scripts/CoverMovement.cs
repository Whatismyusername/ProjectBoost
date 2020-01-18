using UnityEngine;

public class CoverMovement : MonoBehaviour
{

    [SerializeField] float WillBeCoveredIn;
    float startingTime;
    bool started = false;
    private bool moved = false;
    Vector3 StartingPos;
    Vector3 coveredLocation = new Vector3(0, 15, -13);
    GameObject rocketObj;
    Rocket rocket;

    void Start() 
    {
        rocketObj = GameObject.Find("Rocket Ship");
        rocket = rocketObj.GetComponent<Rocket>();
        StartingPos = transform.position;
        startingTime = Time.time;
    }
    void Update()
    {
        MoveCover();

        IfWinOrLose();
    }

    void MoveCover() {
        if(Time.time - startingTime > WillBeCoveredIn && !moved) {
            if(transform.position.y >= coveredLocation.y) {
                transform.position = coveredLocation;
                moved = true;
            } else {
                transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            }
        }
    }

    void IfWinOrLose() {
        if(rocket.gameStatus != Rocket.Status.InProgress) {
            transform.position = StartingPos;
        }
    }
}
