using System.Collections;
using UnityEngine;

public class Partner : MonoBehaviour
{
    [SerializeField] float tick = 0.1f;
    [SerializeField] float tickAmount = 1f;
    [SerializeField] bool CanTimerRun = true;
    public float Attraciton = 100.0f;

    private void OnEnable()
    {
        KCListener.OnWordTyped += WordTyped;
    }

    private void OnDisable()
    {
        KCListener.OnWordTyped -= WordTyped;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(LowerAttractionTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseAttraction(float amount)
    {
        Attraciton += amount;
    }

    public void DecreaseAttraction(float amount)
    {
        Attraciton -= amount;
    }


    IEnumerator LowerAttractionTimer()
    {
        // Timer for generating new words during gameplay
        do
        {
            yield return new WaitForSeconds(tick);
            DecreaseAttraction(tickAmount);

        } while (CanTimerRun);
    }

    private void WordTyped()
    {
        IncreaseAttraction(10);
    }
}
