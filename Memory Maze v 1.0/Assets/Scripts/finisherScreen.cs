using UnityEngine;
using UnityEngine.UI;

public class finisherScreen : MonoBehaviour {
    private Image finisherImage;
    private float duration = 0.6f;
    private float timer;
    private Color start = Color.clear;
    private Color end = Color.white;
    // Use this for initialization
    void Start () {
        finisherImage = GetComponent<Image>();
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if(timer < duration)
        {
            float lerp = Mathf.PingPong(timer, duration) / duration;
            finisherImage.color = Color.Lerp(start, end, lerp);
            timer += Time.deltaTime;
        }
    }
}
