using System;
using UnityEngine;

public class HealthPack : MonoBehaviour {
    public float HealAmount = 25f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.TryGetComponent(out Healable healable)) {
            healable.HealthBar.AddHealth(HealAmount);
        }

        Destroy(gameObject);
    }
}
