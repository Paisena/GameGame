using UnityEngine;

public class Terrain : MonoBehaviour
{
    [SerializeField] float MovementSpeed = 1.0f;
    [SerializeField] int DespawnYPosition = 1000;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveTerrain();

        CheckDespawnPosition();
    }

    void MoveTerrain()
    {
        gameObject.transform.Translate(MovementSpeed * Time.deltaTime * -transform.up);
    }

    void CheckDespawnPosition()
    {
        if (this.transform.position.y <= DespawnYPosition)
        {
            DeleteTerrain();
        }
    }

    void DeleteTerrain()
    {
        Destroy(this.gameObject);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        print("something hit");
        if (other.gameObject.CompareTag("Player"))
        {
            print("player hit!");
            DeleteTerrain();
        }
    }
}
