using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text scoreDisplay;

    private Rigidbody rb;
    private int score;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");
        var movement = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(movement * speed);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            score++;
            RedrawScore();
        }
    }

    private void RedrawScore() {
        scoreDisplay.text = "Score: " + score;
    }
}
