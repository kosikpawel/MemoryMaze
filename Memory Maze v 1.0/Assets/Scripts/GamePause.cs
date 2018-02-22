using UnityEngine;
using UnityEngine.UI;

public class GamePause : MonoBehaviour {
	 public Text t1;
	 public Text t2;
	 public Transform player; 	
	 private Button startButton;
	 public Button startButton2;

	private void Start()
	{
		// 2. Po dwoch sekundach wracamy gracza na start i zatrzymujemy czas plus wlaczamy button2 i text2
		Time.timeScale = 0;
		Invoke("StartPause", 2);
		Invoke("PositionForSure", 2);
	}
	public void StopPause ()
	{
        // 1. Gra jest zatrzymana i jak klikniemy start usuwamy button1 i text1
        playerMovement.movementFlag = false;
        startButton = gameObject.GetComponent<Button>();
		Destroy(startButton.gameObject);
		Destroy(t1.gameObject);
		Time.timeScale = 1;
	}
	public void StartPause()
	{
		// 3. Button2 wylacza button2 i text2 gra idzie do przodu
		Time.timeScale = 0;
		playerMovement.movementFlag = true;
		startButton2.gameObject.SetActive(true);
		t2.gameObject.SetActive(true);
	}
	void PositionForSure()
	{
		player.position = new Vector3(0.5f, 6.5f, 0);
	}
}
