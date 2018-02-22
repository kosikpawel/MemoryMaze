using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hookToPlayer : MonoBehaviour {
    public Transform player;
    Vector3 follow;
	void Update () {
        follow = new Vector3(player.position.x, player.position.y, -1f);
        transform.position = follow;
	}
}
