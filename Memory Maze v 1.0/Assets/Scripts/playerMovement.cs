using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerMovement : MonoBehaviour {

	public float speed;
	private Rigidbody2D rb;
	public static bool movementFlag = true;
	public Button speedUP;

    private Camera cameraInfo;

    float xCam;
    float yCam;
    float xHalf;
    float yHalf;
    public Vector2 movement;
    public Vector3 joyPos;
    float speedUp = 1;
    float joyTime = 0;
    



    private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
        cameraInfo = GetComponentInChildren<Camera>();
        xCam = cameraInfo.pixelWidth;
        yCam = cameraInfo.pixelHeight;
        xHalf = xCam*13 /16;   // punkt odniesienia 
        yHalf = yCam*2 / 5;     // punkt odniesienia
        joyPos = new Vector3(xHalf, yHalf, 0);
        //speed /= 10;
    }

    void FixedUpdate() {
        joyTime += Time.deltaTime;
        float xFix = 0f;
        float yFix = 0f;
        float pitagoras;
        float temp;
        if (Input.touchCount > 0)
        {
            
            var touch = Input.touches[0];
            if (touch.position.x > xCam / 2)
            {
                if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                {
                    xFix = touch.position.x - xHalf;
                    yFix = touch.position.y - yHalf;
                    pitagoras = (xFix * xFix) + (yFix * yFix);
                    temp = speed / Mathf.Sqrt(pitagoras);

					xFix *= temp * 1/10; // xFix = xFix * temp;
                    yFix *= temp * 1/10;
                    rb.velocity = movement = new Vector2(xFix, yFix) * speedUp;
                }
			}
            
        }
    }

    public void SpeedUpOn()
    {
        speedUp = 1.4f;
		StartCoroutine(WaitForButton());
		StartCoroutine(SpeedOff());
		speedUP.gameObject.SetActive(false);
	}

    public void ButtonUP()
    {
		speedUP.gameObject.SetActive(true);
    }
	private IEnumerator WaitForButton()
	{
		yield return new WaitForSeconds(4);
		ButtonUP();
	}

	private IEnumerator SpeedOff()
	{
		yield return new WaitForSeconds(2);
		speedUp = 1f;
	}
    public void SpeedUpReseter()
    {
        StopAllCoroutines();
        speedUP.gameObject.SetActive(true);
        speedUp = 1f;
    }
}


