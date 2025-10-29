using System;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject Bar;
    public Gradient HealthGradient;
    public float Health = 100f;
    public float MaxHealth = 100f;
    
    private Renderer _healthBarRenderer;
    private float _shownHealth = float.NaN;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _healthBarRenderer = Bar.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        if (Mathf.Approximately(_shownHealth, Health)) return;
        
        var percentage = Health / MaxHealth;
        Bar.transform.localScale = new Vector3(percentage, 1f, 1f);
        Bar.transform.localPosition = new Vector3(-0.5f + percentage / 2f, 0f, 0f);
        _healthBarRenderer.material.color = HealthGradient.Evaluate(percentage);
        _shownHealth = Health;
    }

    public void UpdateHealth(float health)
    {
        Health = Mathf.Clamp(health, 0f, MaxHealth);
        UpdateHealthBar();
    }
}
