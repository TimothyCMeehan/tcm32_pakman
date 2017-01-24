using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public float speed;
	public Rigidbody pacman;
	public int score;
	public int lives;
	public Text scoreDisplay;
	public Text livesDisplay;
	private Vector3 startPos;

	// Use this for initialization
	void Start () {
		pacman = GetComponent<Rigidbody> ();
		score = 0;
		lives = 3;
		startPos = transform.position;
		scoreDisplay.text = "Score: " + score;
		livesDisplay.text = "Lives: " + lives;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		//Input.GetKey()
		if (transform.position.x < -13.5f) {
			Vector3 newPos = new Vector3 ((transform.position.x + 27.0f),transform.position.y,transform.position.z);
			transform.position = newPos;
		}
		else if (transform.position.x > 13.5f) {
			Vector3 newPos = new Vector3 ((transform.position.x - 27.0f),transform.position.y,transform.position.z);
			transform.position = newPos;
		}

		Vector3 move = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		pacman.AddForce (move * speed);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Coin")) {
			other.gameObject.SetActive (false);
			score++;
			scoreDisplay.text = "Score: " + score;
		}

		if (other.gameObject.CompareTag ("Ghost")) {
			lives--;
			livesDisplay.text = "Lives: " + lives;
			transform.position = startPos;
		}

	}
}
