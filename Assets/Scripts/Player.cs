using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float force = 3f;
	public float maxVelocity = 3f;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		var horizontalInput = Input.GetAxis("Horizontal");
		Debug.Log(horizontalInput);

		if (rb.velocity.magnitude <= maxVelocity) {
            rb.AddForce(new Vector3(horizontalInput * force, 0, 0));
        }

	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Bomba"))
		{
			Destroy(gameObject);
		}
	}
}
