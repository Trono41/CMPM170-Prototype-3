using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerHealth : MonoBehaviour
{
    public InputAction ThrowAction;
    public InputAction MoveAction;

    public float ThrowStrengthBase = 1.0f;
    public float ThrowMaxStrength = 2.0f;
    public float ThrowRampTime = 1.0f;
    public float ThrowAngle = 15.0f;
    public GameObject HealthPackPrefab;
    public float MoveSpeed = 1.0f;

    private float throwStrength = 0f;
    private bool isThrowing = false;

    public RectTransform ThrowStrengthBar;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ThrowAction.Enable();
        MoveAction.Enable();

        ThrowStrengthBar.gameObject.SetActive(false);
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (HealthPackPrefab && !HealthPackPrefab.IsPrefabDefinition())
        {
            HealthPackPrefab = null;
        }
    }
#endif

    // Update is called once per frame
    void Update()
    {
        if (isThrowing)
        {
            ThrowStrengthBar.sizeDelta = new Vector2(ThrowStrengthBar.sizeDelta.x, 52f *
                (throwStrength - ThrowStrengthBase) /
                (ThrowMaxStrength - ThrowStrengthBase));

            throwStrength = Mathf.Min(ThrowMaxStrength,
                throwStrength + (ThrowMaxStrength - ThrowStrengthBase) * (Time.deltaTime / ThrowRampTime));
        }

        var throwClicked = ThrowAction.IsPressed();

        if (throwClicked && !isThrowing)
        {
            ThrowStrengthBar.gameObject.SetActive(true);
            isThrowing = true;
            throwStrength = ThrowStrengthBase;
        }
        else if (!throwClicked && isThrowing)
        {
            ThrowStrengthBar.gameObject.SetActive(false);
            throwHealthPack(throwStrength);
            throwStrength = 0f;
            isThrowing = false;
        }

        var moveAmount = MoveAction.ReadValue<float>();
        transform.Translate(transform.right * (moveAmount * MoveSpeed * Time.deltaTime));
    }

    private void throwHealthPack(float strength)
    {
        var rot = Quaternion.AngleAxis(ThrowAngle, transform.right) *
                  transform.rotation; // may need to change the order of this rotation
        var medpack = Instantiate(HealthPackPrefab, transform.position, rot);
        var rb = medpack.GetComponent<Rigidbody>();
        rb.AddForce(rot * Vector3.forward * strength, ForceMode.Impulse);
    }
}