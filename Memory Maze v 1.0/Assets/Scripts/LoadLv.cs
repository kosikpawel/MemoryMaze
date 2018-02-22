using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLv : MonoBehaviour {
	public int levelIndex;
	public void Load()
	{
		SceneManager.LoadScene(levelIndex);
	}
}
