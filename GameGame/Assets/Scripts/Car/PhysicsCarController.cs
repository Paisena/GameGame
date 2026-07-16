using Unity.Mathematics;
using UnityEngine;
// taken from https://www.youtube.com/watch?v=DVHcOS1E5OQ
public class PhysicsCarControlller : MonoBehaviour
{
    public float driftFactor = 0.95f;
    public float AccerlerationFactor = 30.0f;
    public float TurnFactor = 3.5f; 
    public float MaxSpeed = 20;

    public float TurnAngleMax = 50;
    public float TurnAngleMin = -50;
    public float LeftRightSpeed = 1;

    private float accerlerationInput = 0;
    private float steeringInput = 0;
    private float rotationAngle = 0;
    private float velocityVsUP = 0;

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

        //KillOrthogonalVelocity();

        //ApplySteering();
    }

    void ApplyEngineForce()
    {

        // THINGS TO ADD: 
        // slow down harder when braking EX: braking when moving upwards
        // Slow down when going in another direction EX: slow down up and down when only pressing left or right
        velocityVsUP = Vector2.Dot(transform.up, carRigidBody2D.linearVelocity);

        if (velocityVsUP > MaxSpeed && accerlerationInput > 0)
            return;

        if (velocityVsUP < -MaxSpeed * 0.5f && accerlerationInput < 0)
            return;

        if (carRigidBody2D.linearVelocity.sqrMagnitude > MaxSpeed && accerlerationInput > 0)
            return;

        if (accerlerationInput == 0 && steeringInput == 0)
            carRigidBody2D.linearDamping = Mathf.Lerp(carRigidBody2D.linearDamping, 3.0f, Time.fixedDeltaTime * 3);
        else
            carRigidBody2D.linearDamping = 1;


        Vector2 HorizontalForceVector = transform.right * steeringInput * AccerlerationFactor;
        print($"Steerinninpug: {steeringInput} carRigidBody2D.linearVelocityX: {carRigidBody2D.linearVelocityX}");
        if ((steeringInput > 0 && carRigidBody2D.linearVelocityX < 0) || steeringInput < 0 && carRigidBody2D.linearVelocityX > 0)
        {
            // accerlerating in opposite direction of movement, add more force
            HorizontalForceVector.x += 10 * steeringInput;
        }

        carRigidBody2D.AddForce(HorizontalForceVector, ForceMode2D.Force);

        Vector2 VerticalForceVector = transform.up * accerlerationInput * AccerlerationFactor;

        if ((accerlerationInput > 0 && carRigidBody2D.linearVelocityY < 0) || accerlerationInput < 0 && carRigidBody2D.linearVelocityY > 0)
        {
            // accerlerating in opposite direction of movement, add more force
            VerticalForceVector.y += 10 * accerlerationInput;
        }

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

        carRigidBody2D.linearVelocity = fowardVelocity + rightVelocity * driftFactor;
    }
}
