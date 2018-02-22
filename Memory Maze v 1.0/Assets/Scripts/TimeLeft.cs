using UnityEngine;
using UnityEngine.UI;

public class TimeLeft : MonoBehaviour {
	public Text timeL;
	public static float onScreen;
	private int minusTime;
	// Update is called once per frame
	void Update () {
		timeL.text = "" + onScreen.ToString("F1");
		onScreen -= Time.deltaTime;
	}
}
