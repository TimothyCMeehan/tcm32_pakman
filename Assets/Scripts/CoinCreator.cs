using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCreator : MonoBehaviour {

	public Rigidbody coin;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < 10; i++) {
			Vector3 pos = new Vector3 (Random.Range (-13f, 13f), 0.6f, Random.Range (-14.5f, 14.5f));
			//Vector3 rotation = new Vector3 (90.0f, 90.0f, 45.0f);
			Rigidbody coinClone = (Rigidbody)Instantiate (coin, pos, transform.rotation);
		}
	}

}
