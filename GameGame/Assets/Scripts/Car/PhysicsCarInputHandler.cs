using UnityEngine;

public class PhysicsCarInputHandler : MonoBehaviour
{
    PhysicsCarControlller physicsCarControlller;

    void Awake()
    {
        physicsCarControlller = GetComponent<PhysicsCarControlller>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = Vector2.zero;

        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");
        physicsCarControlller.SetInputVector(inputVector);
    }
}
