using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text scoreDisplay;
    public float cameraAngle = 45.0f;

    private Rigidbody rb;
    private int score;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
	}

    private void Update()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");
        var movement = new Vector3(moveHorizontal, 0, moveVertical);
        var cameraTransform = Quaternion.AngleAxis(45.0f, Vector3.up);

        rb.AddForce((cameraTransform * movement) * speed * Time.deltaTime * 60);
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
