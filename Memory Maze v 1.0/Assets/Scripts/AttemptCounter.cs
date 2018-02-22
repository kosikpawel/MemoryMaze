using UnityEngine;
using UnityEngine.UI;

public class AttemptCounter : MonoBehaviour {
	public Text scoreText;
	// Update is called once per frame
	void Update () {
		scoreText.text = "Attempt " + GameManager.attemptCounter;
	}
}
