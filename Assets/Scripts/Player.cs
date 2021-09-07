using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public Transform graundCheckTransform = null;
    [SerializeField] private LayerMask playerField;
    private bool jumpKeyWasPressed;
    private float gorizontalInput;
    private Rigidbody rigidbodyComponent;
    private int superJumpsRemaning;


    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            // Debug.Log("Space Key Down");
            jumpKeyWasPressed = true;
        }

        gorizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        rigidbodyComponent.velocity = new Vector3(gorizontalInput, rigidbodyComponent.velocity.y, 0);

        if (Physics.OverlapSphere(graundCheckTransform.position,0.1f, playerField).Length == 0 )
        {
            return;
        }
       
        if (jumpKeyWasPressed)
        {
            float jumpPower = 5f;
            if (superJumpsRemaning > 0)
            {
                jumpPower *= 1.5f;
                superJumpsRemaning--;
            }
            // Debug.Log("Space Key Down");
            rigidbodyComponent.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            Destroy(other.gameObject);
            superJumpsRemaning++;
        }
    }
}
