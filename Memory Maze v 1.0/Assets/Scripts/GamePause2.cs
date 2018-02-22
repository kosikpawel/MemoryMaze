using UnityEngine;
using UnityEngine.UI;

public class GamePause2 : MonoBehaviour {
	private Button startButton;
	public Text t2;

	public void GameStart()
	{
		startButton = gameObject.GetComponent<Button>();
		Destroy(startButton.gameObject);
		Destroy(t2.gameObject);
		Time.timeScale = 1;
	}
}
