using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {
	private Transform spawnPos;
	public float timeBtwnSpwnsMax;
	public float timeBtwnSpwnsMin;
	public float timeBtwnSpwns;
	public float startDifficultyIncreaser;
	private float difficultyIncreaser;

	private float timeUntilSpawn;

	public GameObject[] attackers;

	// Use this for initialization
	void Start () {
		spawnPos = gameObject.transform;
		timeBtwnSpwns = timeBtwnSpwnsMax;
		timeUntilSpawn = timeBtwnSpwns;
		difficultyIncreaser = startDifficultyIncreaser;
	}

	// Update is called once per frame
	void Update () {
		// Counts down time until next Enemy Spawn
		timeUntilSpawn -= Time.deltaTime;

		// Spawns Enemy after timer has run out
		if (timeUntilSpawn <= 0) {

			// The further the player goes, the slower the difficulty increases
			if (timeBtwnSpwns <= 0.65f)
				difficultyIncreaser = startDifficultyIncreaser / 8;
			else if (timeBtwnSpwns <= 0.70f)
				difficultyIncreaser = startDifficultyIncreaser / 7;
			else if (timeBtwnSpwns <= 0.75f)
				difficultyIncreaser = startDifficultyIncreaser / 6;
			else if (timeBtwnSpwns <= 0.80f)
				difficultyIncreaser = startDifficultyIncreaser / 5;
			else if (timeBtwnSpwns <= 0.85f)
				difficultyIncreaser = startDifficultyIncreaser / 4;
			else if (timeBtwnSpwns <= 0.90f)
				difficultyIncreaser = startDifficultyIncreaser / 3;
			else if (timeBtwnSpwns <= 1f)
				difficultyIncreaser = startDifficultyIncreaser / 2;

			Debug.Log ("Time between spawns: " + timeBtwnSpwns);
			Debug.Log ("Score: " + ScoreController.scoreValue);

			// Increases the difficulty by reducing the time between spawns by how high your score is
			timeBtwnSpwns -= difficultyIncreaser;
			// Time between spawns cannot be lower than the minimum time between spawns
			if (timeBtwnSpwns < timeBtwnSpwnsMin)
				timeBtwnSpwns = timeBtwnSpwnsMin;

			// Instantiate a random gameobject from the attackers array
			GameObject attackerToInstatiate = attackers [Random.Range (0, attackers.Length)];
			Instantiate (attackerToInstatiate, spawnPos);
			DefenderController.enemyLineup.Add (attackerToInstatiate);
			// Reset the timer for next spawn
			timeUntilSpawn = timeBtwnSpwns;
		}
	}
}
