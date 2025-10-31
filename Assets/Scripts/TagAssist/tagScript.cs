using UnityEngine;
using UnityEngine.InputSystem;

public class TagScript : MonoBehaviour
{
    public GameObject activeCharacter;
    public GameObject reserveCharacter1;
    public GameObject reserveCharacter2;
    public InputAction tagToR1;
    public InputAction tagToR2;

    private Rigidbody activeRB;

    void Start()
    {
        activeRB = activeCharacter.GetComponent<Rigidbody>();
        tagToR1.Enable();
        tagToR2.Enable();
    }

    void Update()
    {
        if (tagToR1.triggered)
            SwapCharacter(ref activeCharacter, ref reserveCharacter1);

        if (tagToR2.triggered)
            SwapCharacter(ref activeCharacter, ref reserveCharacter2);
    }

    void SwapCharacter(ref GameObject active, ref GameObject reserve)
    {
        var activePos = active.transform.position;
        var reserveRB = reserve.GetComponent<Rigidbody>();

        reserve.SetActive(true);
        reserveRB.position = new Vector3(activePos.x-2, activePos.y + 5, activePos.z);
        reserveRB.AddForce(Vector3.right * 2f, ForceMode.Impulse);

        var temp = active;
        active = reserve;
        reserve = temp;

        reserve.SetActive(false);
        activeRB = active.GetComponent<Rigidbody>();
    }
}

