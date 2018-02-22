using UnityEngine;

public class waveAction : MonoBehaviour {
    public float speed = 20f;
    public float range = 650f;
    
    Vector3 grown;

    void Update()
    {
        //grown jest obliczany tutaj nie w starcie bo sie bugowalo
        grown = new Vector3(speed, speed, 0f);
        //powieksza
        transform.localScale += (grown * Time.deltaTime);

        //kiedy fala bedzie miala x = range zniknie
        if (transform.localScale.x > range)
        {
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
