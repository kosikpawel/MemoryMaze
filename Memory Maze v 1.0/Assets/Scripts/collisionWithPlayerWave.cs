using UnityEngine;

public class collisionWithPlayerWave : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            gameObject.SetActive(false);
        }
    }
}
