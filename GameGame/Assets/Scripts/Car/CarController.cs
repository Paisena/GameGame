using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CarController : MonoBehaviour
{
    
    [SerializeField] List<Transform> CarPositions;
    [SerializeField] int positionIndex = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerInput();

        UpdateCarPosition();        
    }

    private void CheckPlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && positionIndex > 0)
        {
            positionIndex -= 1;
        }    
        else if (Input.GetKeyDown(KeyCode.RightArrow) && positionIndex < CarPositions.Count-1)
        {
            positionIndex += 1;
        }
    }

    private void UpdateCarPosition()
    {
        // will need to update to add animation later

        gameObject.transform.position = CarPositions[positionIndex].position;
    }

    

}
