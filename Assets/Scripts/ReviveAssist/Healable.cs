using UnityEngine;

public class Healable : MonoBehaviour {
    public float HealthLossPerSecond = 1f;

    public HealthBar HealthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.UpdateHealth(HealthBar.Health - HealthLossPerSecond * Time.deltaTime);
    }
}
