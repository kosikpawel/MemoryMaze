using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitToMenu : MonoBehaviour {
	public void QuitToM ()
	{
		SceneManager.LoadScene(0);
	}
}
