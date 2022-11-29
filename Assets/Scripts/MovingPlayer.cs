using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlayer : MonoBehaviour
{
    double gravity = 0f;

    [SerializeField]
    CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        
        gravity -= 9.81 * Time.deltaTime;
        characterController.Move(new Vector3(0, (float)gravity, 0));
        if (characterController.isGrounded) gravity = 0;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            //r1.AddForce(new Vector2(1, 1));
            //r1.velocity = new Vector2(0, 10);
            characterController.Move(new Vector3(0, 5, 0));

            //Debug.Log("Start is called");
        }
    }
}
