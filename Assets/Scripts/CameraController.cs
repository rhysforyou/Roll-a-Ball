using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public float smoothTime = 0.3f;

    private Vector3 offset;
    private Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start ()
    {
        offset = transform.position - player.transform.position;
	}

    private void LateUpdate()
    {
        var playerRigidbody = player.GetComponent<Rigidbody>();
        var targetPosition = player.transform.position + playerRigidbody.velocity * 0.4f + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
