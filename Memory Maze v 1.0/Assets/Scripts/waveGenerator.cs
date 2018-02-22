using UnityEngine;

public class waveGenerator : MonoBehaviour {

    public int iloscFal = 10;
    public float czasMiedzyFalami = 4f;     
    public GameObject wave;
    //public GameObject fisrtWave;
    public float firstWaveSpeed = 1.7f;
    //public waveAction firstWave;
    public bool firstWaveFlag = true;

    float time;
    Vector3 spawnPoint;
    bool wymuszenie = true;


	void Start () {
        //kopia pozycji na ktorej znajduje sie generator (musi być bo sie zbuguje)
        spawnPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z); 
    }

	void Update () {
		//zliczanie czasu od ostatniej fali
		time += 1f * Time.deltaTime;
        //tworzy okreslona ilosc fal z okreslonymi odstepami
        //wymuszenie powoduje ze pierwsza fala jest puszczana na samym poczatka
        //tz. nie trzeba czekac przez czasMiedzyFalami na pierwsza fale
        if ((iloscFal > 0 && time > czasMiedzyFalami) || wymuszenie)
        {
            //klonuje object wavw w miejscu spawnPoint, ignorujac wszelkie rotacje
            Instantiate(wave, spawnPoint, Quaternion.identity, transform);
            if (firstWaveFlag)
            {
                waveAction firstWave;
                firstWave = this.GetComponentInChildren<waveAction>();
                firstWave.speed *= firstWaveSpeed;
                firstWaveFlag = false;
            }
            iloscFal--;
            time = 0;
            //wymuszenie zadziala tylko raz przy pierwszym obrocie Update pozniej bedzie false caly czas
            wymuszenie = false;
        }
	}
}
