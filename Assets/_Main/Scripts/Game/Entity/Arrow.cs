using OttomanDisc;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private IMotor motor;
    private Rigidbody rb;

    private void Awake()
    {
        motor = this.GetComponent<IMotor>();
        rb = this.GetComponent<Rigidbody>();
        
        // whilst held we want to move the arrow with the player
        rb.isKinematic = true; 
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Loose()
    {
        // once released turns physics back on for arrow
        rb.isKinematic = false; 
        motor.Move(Vector3.right);

        Debug.Log("Arrow loosed");
    }
}
