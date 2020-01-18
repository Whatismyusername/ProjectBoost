using UnityEngine;

public class Level06Obs1 : MonoBehaviour
{

    private Vector3 DisplacementVector = new Vector3(0, 5, 0);
    [SerializeField] float DisplacementFactor;
    private float secondsInBetween = 2f;
    private float period;
    private Vector3 StartingPos;
    // Start is called before the first frame update
    void Start()
    {
        StartingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        period = Time.time / secondsInBetween * 2 * Mathf.PI;

        DisplacementFactor = Mathf.Sin(period) / 2 + 0.5f;
        transform.position = StartingPos + DisplacementVector * DisplacementFactor;
    }
}
