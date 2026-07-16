using UnityEngine;

public class Car : MonoBehaviour
{
    public int PlayerHealth
    {
        get {return playerHealth;}
        set 
        { 
            playerHealth = value;
            if (playerHealth <= 0)
            {
                Death();
            }
        }
    }
    private int playerHealth = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // TODO: add animations here

        TerrainObject TO = other.gameObject.GetComponent<TerrainObject>();
        TakeDamage(TO.damage);
    }

    void TakeDamage(int amount)
    {
        print("player took damage");
        PlayerHealth -= amount;
    }

    void Death()
    {
        print("Player died");
    }
}
