using UnityEngine;

public class CompassRotation : MonoBehaviour {

    public float offset = 0;            //do recznego poprawiania dokladnosci kompasu
    Vector3 difference;                 //do obliczen
    Vector3 import;                     //idiotyzm ktorego nie chcialo mi sie poprawiac xd do importu danych z _GM
    bool test = true;                          //do sprawdzanie czy pobrano dane z GM

    void FixedUpdate()
    {
        if (test) return;     //sprawdza czy poprano dane

        //obliczenia
        difference = import - transform.position; 
        difference.Normalize();
        //Obliczanie kata
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //Debug.Log("nonono");
        //Ustawianie rotacji na obliczony kat
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

    }


    public void CompassAction(Vector3 pointPos)
    {
        import = pointPos;
        test = false;
    }
}
