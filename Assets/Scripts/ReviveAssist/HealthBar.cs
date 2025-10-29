using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject Bar;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateHealth(float health)
    {
        health = Mathf.Clamp(health, 0f, 1f);
        Bar.transform.localScale = new Vector3(health, 1f, 1f);
    }
}
