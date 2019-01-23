using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderController : MonoBehaviour {
	private float desiredRotation;
	public float rotationSpeed;

	public static List<GameObject> enemyLineup = new List<GameObject>();
	private string nextEnemyName;
	public bool aiOn;

	void Start () {
		desiredRotation = transform.eulerAngles.z;
	}

	void Update () {
		if (aiOn) {
			if (enemyLineup.Count != 0) {
				nextEnemyName = enemyLineup[0].name;
				switch (nextEnemyName) {
				case "LightningSpike":
					desiredRotation = 0f;
					break;
				case "GrasBlade":
					desiredRotation = 90f;
					break;
				case "Waterball":
					desiredRotation = 180f;
					break;
				case "Fireball":
					desiredRotation = 270f;
					break;

				}
			}
		} else {
			// Rotate the defender according to arrow-key inputs
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				desiredRotation -= 90f;
			} else if(Input.GetKeyDown (KeyCode.LeftArrow)){
				desiredRotation += 90f;
			}
		}

		var desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, desiredRotation);
		transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, Time.deltaTime * rotationSpeed);
	}
}
