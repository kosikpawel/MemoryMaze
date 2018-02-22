using UnityEngine;

public class szachMat : MonoBehaviour {
    public Transform player;
	// Use this for initialization
	void Start () {
        transform.position = player.position;
	}
}
