using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerController : MonoBehaviour {
	public float moveSpeedMin;
	public float moveSpeedMax;
	private float moveSpeed;

	private float defenderRotation;
	private string attackerName;

	// Use this for initialization
	void Awake () {
		moveSpeed = moveSpeedMin + ScoreController.scoreValue * 5;
		if (moveSpeed > moveSpeedMax)
			moveSpeed = moveSpeedMax;
		
		GetComponent<Rigidbody2D> ().AddForce (Vector2.left * moveSpeed);
		attackerName = gameObject.name;
	}

	void OnTriggerEnter2D(Collider2D collider){
		defenderRotation = collider.transform.eulerAngles.z;

		// Check if the Defender is rotated correctly and add 1 to the Score if so
		if ((defenderRotation > 315 || defenderRotation < 45) && attackerName == "LightningSpike(Clone)")
			ScoreController.scoreValue++;
		else if ((defenderRotation > 45 && defenderRotation < 135) && attackerName == "GrasBlade(Clone)") {
			ScoreController.scoreValue++;
		} else if ((defenderRotation > 135 && defenderRotation < 225) && attackerName == "Waterball(Clone)") {
			ScoreController.scoreValue++;
		} else if ((defenderRotation > 225 && defenderRotation < 315) && attackerName == "Fireball(Clone)") {
			ScoreController.scoreValue++;
			// When it is not rotated correctly, reset the score
		} else
			ScoreController.scoreValue = 0;

		DefenderController.enemyLineup.RemoveAt (0);
		Destroy (gameObject);
	}
}
