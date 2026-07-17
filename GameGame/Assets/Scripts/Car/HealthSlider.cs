using System;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Slider))]
public class HealthSlider : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] PlayerCar player;

    void Awake()
    {
        slider = GetComponent<Slider>();    
        player = FindAnyObjectByType<PlayerCar>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSlider();
    }

    void UpdateSlider()
    {
        slider.value = player.Health;
    }
}
