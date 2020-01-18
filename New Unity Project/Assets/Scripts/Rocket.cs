using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{

    Rigidbody rigidBody;
    AudioSource audioSource;
    [SerializeField] AudioClip ThrustingSound;
    [SerializeField] AudioClip WinningSound;
    [SerializeField] AudioClip LosingSound;
    
    [SerializeField] ParticleSystem ThrustingParticle;
    [SerializeField] ParticleSystem WinningParticle;
    [SerializeField] ParticleSystem LosingParticle;

    Vector3 ThrustForce = new Vector3(0, 1200f, 0);
    Vector3 Rotation = new Vector3(0, 0, 180f);

    public enum Status { Won, Lost, InProgress };
    public Status gameStatus;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        gameStatus = Status.InProgress;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameStatus == Status.InProgress) {
            Thrust();
            Rotate();
        }

        if(Debug.isDebugBuild){
            OnDebugModeEnter();
        }
        
    }

    private void OnDebugModeEnter() {
        if (Input.GetKey(KeyCode.L)) {
            LoadNextLevel();
        }
    }
    private void Thrust() {
        if (Input.GetKey(KeyCode.Space)) {
            //Thrust
            rigidBody.AddRelativeForce(ThrustForce * Time.deltaTime);
            ThrustingParticle.Play();

        } 
        if (Input.GetKeyDown(KeyCode.Space)) {
            audioSource.PlayOneShot(ThrustingSound);
        }
        else if(Input.GetKeyUp(KeyCode.Space)) {
            audioSource.Stop();
            ThrustingParticle.Stop();
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
        
        if (gameStatus != Status.InProgress) {return;}
        switch(other.gameObject.tag) {
            case "Friendly":
                break;
            case "Respawn":
                break;
            case "Station":
                // Freezes motion
                rigidBody.velocity = new Vector3(0, 0, 0);
                break;
            case "Finish":
                BeginToWin();
                gameStatus = Status.Won;
                break;
            case "ToLevel":
                WinningParticle.Play();
                CheckLevel(other.gameObject.name);
                break;
            default:
                BeginToLose();
                gameStatus = Status.Lost;
                break;
        }
    }

    private void BeginToWin() {
        
        audioSource.Stop();
        audioSource.PlayOneShot(WinningSound);

        WinningParticle.Play();

        Invoke("LoadNextLevel", 1f);

    }

    private void BeginToLose() {
        audioSource.Stop();
        audioSource.PlayOneShot(LosingSound);

        LosingParticle.Play();

        Invoke("LoadFirstLevel", 1f);

    }

    private void LoadNextLevel() {
        int currentSceneIdx = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIdx = currentSceneIdx + 1;

        // Save Highest Level
        if(GameManager.highestLevel < currentSceneIdx + 1) {
            GameManager.highestLevel = currentSceneIdx + 1;
        }
        SceneManager.LoadScene(nextSceneIdx % SceneManager.sceneCountInBuildSettings);
    }

    private void LoadFirstLevel() {
        SceneManager.LoadScene(0);
    }

    private void CheckLevel(string name) {
        string scene = "";
        for(int i = 0; i < name.Length - 7; i++) {
            scene += name[7+i];
        }
        SceneManager.LoadScene(int.Parse(scene));
    }
}
