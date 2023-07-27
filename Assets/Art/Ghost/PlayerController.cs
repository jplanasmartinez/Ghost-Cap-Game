using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float HorizontalMove;
    public float VerticalMove;
    private Vector3 PlayerInput;

    public CharacterController player;

    public float PlayerSpeed;
    private Vector3 MovePlayer;

    public Camera MainCamera;
    private Vector3 CamForward;
    private Vector3 CamRight;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMove = Input.GetAxis("Horizontal");
        VerticalMove = Input.GetAxis("Vertical");

        PlayerInput = new Vector3(HorizontalMove, 0, VerticalMove);
        PlayerInput = Vector3.ClampMagnitude(PlayerInput, 1);

        CamDirection();

        MovePlayer = PlayerInput.x * CamRight + PlayerInput.z * CamForward;

        player.transform.LookAt(player.transform.position + MovePlayer);

        player.Move(MovePlayer * PlayerSpeed * Time.deltaTime);
    }

    void CamDirection()
    {
        CamForward = MainCamera.transform.forward;
        CamRight = MainCamera.transform.right;

        CamForward.y = 0;
        CamRight.y = 0;

        CamForward = CamForward.normalized;
        CamRight = CamRight.normalized;
    }

}
