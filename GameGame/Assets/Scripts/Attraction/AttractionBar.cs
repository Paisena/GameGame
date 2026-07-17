using System;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Slider))]
public class AttractionBar : MonoBehaviour
{
    [SerializeField] Partner partner;
    [SerializeField] Slider slider;
    void Awake()
    {
        partner = FindAnyObjectByType<Partner>();
        slider = GetComponent<Slider>();
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

    private void UpdateSlider()
    {
        slider.value = partner.Attraciton;
    }

}
