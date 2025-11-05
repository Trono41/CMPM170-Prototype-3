using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TagScript : MonoBehaviour
{
    public GameObject activeCharacter;
    public GameObject reserveCharacter1;
    public GameObject reserveCharacter2;
    public InputAction tagToR1;
    public InputAction tagToR2;

    public RawImage UISlot1;
    public RawImage UISlot2;

    private Rigidbody activeRB;

    void Start()
    {
        activeRB = activeCharacter.GetComponent<Rigidbody>();
        tagToR1.Enable();
        tagToR2.Enable();
        UISlot1.color = reserveCharacter1.GetComponent<Renderer>().material.color;
        UISlot2.color = reserveCharacter2.GetComponent<Renderer>().material.color;
        reserveCharacter1.SetActive(false);
        reserveCharacter2.SetActive(false);
    }

    void Update()
    {
        if (tagToR1.triggered)
            SwapCharacter(ref activeCharacter, ref reserveCharacter1, UISlot1);

        if (tagToR2.triggered)
            SwapCharacter(ref activeCharacter, ref reserveCharacter2, UISlot2);
    }

    void SwapCharacter(ref GameObject active, ref GameObject reserve, RawImage UISlot)
    {
        var activePos = active.transform.position;
        var reserveRB = reserve.GetComponent<Rigidbody>();

        reserve.SetActive(true);
        reserve.GetComponent<PlayerController>().enabled = true;
        reserveRB.position = new Vector3(activePos.x-2, 5, activePos.z);
        reserveRB.AddForce(Vector3.right * 2f, ForceMode.Impulse);

        var temp = active;
        active = reserve;
        reserve = temp;

        reserve.GetComponent<PlayerController>().enabled = false;
        reserve.SetActive(false);
        activeRB = active.GetComponent<Rigidbody>();
        UISlot.color = reserve.GetComponent<Renderer>().material.color;
    }
}

