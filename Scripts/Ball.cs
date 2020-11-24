
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush =15f ;
    [SerializeField] float randomFactor = 0.2f;
    [SerializeField] AudioClip[] ballSound;
   
    // cached references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2d;
    TrailRenderer trailRenderer;
    
    Vector2 paddleToBallVector;
    bool hasStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2d = GetComponent<Rigidbody2D>();
        


    }
    private void LoadBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }
 

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LoadBallToPaddle();
            LaunchOnClick();
        }
    }

    private void LaunchOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidBody2d.velocity = new Vector2(xPush, yPush);
            trailRenderer = GetComponent<TrailRenderer>();

        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));
        if (hasStarted)
        {
            AudioClip clip = ballSound[UnityEngine.Random.Range(0, ballSound.Length)];

           myAudioSource.PlayOneShot(clip);
            myRigidBody2d.velocity += velocityTweak;
        }
    }
}
