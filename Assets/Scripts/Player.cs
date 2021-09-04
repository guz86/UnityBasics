using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            // Debug.Log("Space Key Down");
            GetComponent<Rigidbody>().AddForce(Vector3.up *3, ForceMode.VelocityChange);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.down * 3, ForceMode.VelocityChange);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.right * 3, ForceMode.VelocityChange);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.left * 3, ForceMode.VelocityChange);
        }
    }
}
