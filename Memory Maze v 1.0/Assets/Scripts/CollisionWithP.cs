using UnityEngine;

public class CollisionWithP : MonoBehaviour {

	public GameManager gameManager;
	//Podczas kolizji z punktem wysylamy informacje za pomoca flagi do GameManager
	//Punkt traci mozliwosc kolizji
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.name == "Player")
		{
			gameObject.SetActive(false);
			GameManager.flagOnPoint = true;
		}
	}
}
