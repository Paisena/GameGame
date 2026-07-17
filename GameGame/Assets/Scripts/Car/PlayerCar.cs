using UnityEngine;
using UnityEngine.UI;

public class PlayerCar : MonoBehaviour
{
    public float Health = 3.0f;
    [SerializeField] Slider slider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        print("something hit");
        if (other.gameObject.CompareTag("Terrain"))
        {
            print("player hit!");
            Health -= 1.0f;
        }
    }
}
