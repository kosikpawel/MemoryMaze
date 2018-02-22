using UnityEngine;

public class ButtonsControls : MonoBehaviour {
	private static bool rightStaticBool, leftStaticBool, upStaticBool, downStaticBool;
	private float speedV = 0, speedH = 0;

	public float speed;
	public Rigidbody2D rb;

	void Start() {
		rightStaticBool = false; leftStaticBool = false; upStaticBool = false; downStaticBool = false;
	}

	void Update () {
		if (rightStaticBool) {
			speedH = speed;
		}
		else if (leftStaticBool) {
			speedH = -speed;
		}
		else {
			speedH = 0;
		}
		if (upStaticBool) {
			speedV = speed;
		}
		else if (downStaticBool) {
			speedV = -speed;
		}
		else {
			speedV = 0;
		}
		rb.velocity = new Vector2(speedH, speedV);
	}

	public void rightMove() {
		rightStaticBool ^= true;
	}
	public void lefttMove() {
		leftStaticBool ^= true;
	}
	public void upMove() {
		upStaticBool ^= true;
	}
	public void downtMove() {
		downStaticBool ^= true;
	}
}
