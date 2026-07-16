using Unity.Mathematics;
using UnityEngine;
// taken from https://www.youtube.com/watch?v=DVHcOS1E5OQ
public class PhysicsCarControlllerV2 : MonoBehaviour
{
    public float driftFactor = 0.95f;
    public float AccerlerationFactor = 30.0f;
    public float TurnFactor = 3.5f; 
    public float MaxSpeed = 20;

    public float TurnAngleMax = 50;
    public float TurnAngleMin = -50;
    public float LeftRightSpeed = 1;
    public float CarDrag = 15;
    public enum WhichDirection
    {
        Up,
        Right,
        Stopped
    }

    private float accerlerationInput = 0;
    private float steeringInput = 0;
    private float rotationAngle = 0;
    private float velocityVsUP = 0;
    private float velocityVsRight = 0;

    [SerializeField] private Rigidbody2D carRigidBody2D;

    void Awake()
    {
        carRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        ApplyEngineForce();

        // KillOrthogonalVelocity();

        //ApplySteering();
    }

    void ApplyEngineForce()
    {
        // if going up or down and left is pressed

        // THINGS TO ADD: 
        // Slow down when going in another direction EX: slow down up and down when only pressing left or right
        

        if (accerlerationInput == 0 && steeringInput == 0)
            carRigidBody2D.linearDamping = Mathf.Lerp(carRigidBody2D.linearDamping, 9.0f, Time.fixedDeltaTime * 3);
        else
            carRigidBody2D.linearDamping = CarDrag;


        Vector2 HorizontalForceVector = transform.right * steeringInput * AccerlerationFactor * 3;
        if ((steeringInput > 0 && carRigidBody2D.linearVelocityX < 0) || steeringInput < 0 && carRigidBody2D.linearVelocityX > 0)
        {
            // accerlerating in opposite direction of movement, add more force
            HorizontalForceVector.x += 10 * steeringInput;
        }

        velocityVsRight = Vector2.Dot(transform.right, carRigidBody2D.linearVelocity);     

        if (velocityVsRight > MaxSpeed && steeringInput > 0)
        {
            print("maxspeed hit for x1");
            HorizontalForceVector.x = 0;
        }

        if (velocityVsRight < -MaxSpeed && steeringInput < 0)
        {
            print("maxspeed hit for x2");
            HorizontalForceVector.x = 0;
        }

        if (carRigidBody2D.linearVelocity.sqrMagnitude > MaxSpeed && steeringInput != 0)
        {
            print("maxspeed hit for x3");
            HorizontalForceVector.x = 0;
        }

        if (steeringInput != 0 && steeringInput != 0)
        {
            //HorizontalForceVector *= 1.2f;
        }

        carRigidBody2D.AddForce(HorizontalForceVector, ForceMode2D.Force);


        Vector2 VerticalForceVector = transform.up * accerlerationInput * AccerlerationFactor;

        if ((accerlerationInput > 0 && carRigidBody2D.linearVelocityY < 0) || accerlerationInput < 0 && carRigidBody2D.linearVelocityY > 0)
        {
            // accerlerating in opposite direction of movement, add more force
            VerticalForceVector.y += 10 * accerlerationInput;
        }
        velocityVsUP = Vector2.Dot(transform.up, carRigidBody2D.linearVelocity);     

        if (velocityVsUP > MaxSpeed && accerlerationInput > 0)
        {
            print("maxspeed hit for y1");
            VerticalForceVector.y = 0;
        }

        if (velocityVsUP < -MaxSpeed * 0.5f && accerlerationInput < 0)
        {
            print("maxspeed hit for y2");
            VerticalForceVector.y = 0;
        }

        if (carRigidBody2D.linearVelocity.sqrMagnitude > MaxSpeed && accerlerationInput != 0)
        {
            print("maxspeed hit for y3");
            VerticalForceVector.y = 0;
        }

        if (accerlerationInput != 0 && steeringInput != 0)
        {
            VerticalForceVector *= 2f;
        }
        print($"VForce: {VerticalForceVector}");
        print($"Hforce: {HorizontalForceVector}");
        print($"velo{carRigidBody2D.linearVelocity}");

        carRigidBody2D.AddForce(VerticalForceVector, ForceMode2D.Force);
        //print(carRigidBody2D.linearVelocityX);
    }

    void ApplySteering()
    {
        // rotationAngle -= steeringInput * TurnFactor;

        // rotationAngle = Mathf.Clamp(rotationAngle, TurnAngleMin, TurnAngleMax);
        // carRigidBody2D.MoveRotation(rotationAngle);
        // if (accerlerationInput == 0)
        // {
        //     Vector3 newPosition = new Vector3(transform.position.x + steeringInput * LeftRightSpeed, transform.position.y, transform.position.z);
        //     transform.position = newPosition;
        //     return;
        // }
        

    }

    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        accerlerationInput = inputVector.y;
    }

    void KillOrthogonalVelocity()
    {
        Vector2 fowardVelocity = transform.up * Vector2.Dot(carRigidBody2D.linearVelocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(carRigidBody2D.linearVelocity, transform.right);

        carRigidBody2D.linearVelocity =  rightVelocity + fowardVelocity * driftFactor;
    }
}
