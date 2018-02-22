using UnityEngine;
using UnityEngine.UI;

public class GamePause3 : MonoBehaviour {
	public Button startButton3;
	public Text t3;
	public GameObject tutorial3;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.name == "Player")
		{
			startButton3.gameObject.SetActive(true);
			t3.gameObject.SetActive(true);
			Time.timeScale = 0;
		}
	}
	public void StartGame3 ()
	{
		Time.timeScale = 1;
		Destroy(startButton3.gameObject);
		Destroy(t3.gameObject);
		Destroy(tutorial3.gameObject);
	}
}
