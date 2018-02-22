using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//obsluga plikow
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManager : MonoBehaviour {
    public float[] timeForPlayer;                         //Czas jaki dostaje gracz na przejscie z punktu A do danego punktu
    public Vector3[] pointsPosition;                      //Miejsca gdzie maja zespawnowac sie kolejne bramki 53 51 88 18
    public GameObject point;                              //Referancja do gameObject bramka
    public GameObject waveGenerator;                      //Referancja do gameObject generatorFal
    public GameObject pointGhost;
    public CompassRotation compassIns;                    //referencja do skryptu obracajacego tlem jak kompas
    public Transform playerPos;                           //Referencja do Transform gracza

    public static bool flagOnPoint = false;               //Flaga bedzie true gdy dotrzemy do pierwszego punktu
	public static float attemptCounter = 1f;              //Podejscie gracza w danym levelu 

	private int pointNumber = 1;                          //Licznik z numerem aktualnie szukanej bramki               
    private int arraySize;                                //Liczba pozycji zapisanych w tablicy pointsPosition
    private Vector3 startPos;                             //Pozycja startowa gracza
    private float tempCounter = 1f;                       //Tymczasowy licznik
    private int i = 0;                                    //Iterator do obslugi tablicy
    private float howMuchTime = 0f;                       //Czas jaki uplyna w grze, potrzebne by dobrze dzialal if przy sprawdzaniu czy skonczyl sie czas 
	private float mainTime = 0;                           //Glowny czas w grze

    private float finishTimer = 0;
    private float finishTime = 0.7f;
    private bool finishSequence = false;
    int y;
    public Button startButton;
	public bool wantSumStart;
    public GameObject soundManager;
    private SoundManager soundManagerScript;
    public GameObject finisherCanvas;

    // Use this for initialization
    void Start () {
        for (int ij = 0; ij < timeForPlayer.Length; ij++ )
		{
			timeForPlayer[ij] += 10;
		}
		//Gra na poczatku zapauzowana dopoki nie nacisniemy start
		if (wantSumStart)
		{
			Time.timeScale = 0;
			startButton.gameObject.SetActive(true);
		}
        //Pozycja startowa gracza tam go cofniemy
        startPos = playerPos.transform.position;
        //Spawnuje pierwsza bramke
        Instantiate(soundManager, pointsPosition[0], Quaternion.identity, transform);
        soundManagerScript = this.GetComponentInChildren<SoundManager>();
        Instantiate(point, pointsPosition[0], Quaternion.identity, transform);
        Instantiate(waveGenerator, pointsPosition[0], Quaternion.identity, transform);
        compassIns.CompassAction(pointsPosition[0]);    //przeslanie danych o pierwszej bramce do kompaso-tla
        //oblicza rozmiar tablicy pointsPosition
        arraySize = pointsPosition.Length;
		//Wysylamy czas do punktu do UI
		TimeLeft.onScreen = timeForPlayer[i];
        int y = SceneManager.GetActiveScene().buildIndex;
    }
	void FixedUpdate () { 
        mainTime += Time.fixedDeltaTime;
        //Gdy dotrzemy do ostatniego punktu zapisujemy gre i wracamy do menu glownego
        if (finishSequence) ///
        {
            finishTimer += Time.deltaTime;
            if(finishTimer >= finishTime)
            {				
                attemptCounter = 1;
                SceneManager.LoadScene(0);
            }
        }
        else if (i == pointsPosition.Length)
        {
			attemptCounter--;
            SaveProgress();
            Instantiate(finisherCanvas, pointsPosition[0], Quaternion.identity, transform);
            finishSequence = true;
        }
        //flagOnPoint = true gdy dotrzemy do cheakpointu false gdy gracz wroci na pozycje startowa
        else if (flagOnPoint == true)
		{
            soundManagerScript.pointSound();
            Debug.Log(mainTime - howMuchTime);
			flagOnPoint = false;
			i++;
			//howMuchTime by dzialalo resetowanie gdy przechodzimy przez kolejne punkty
			howMuchTime = mainTime;
			tempCounter = 1f;
            //spownuje kolejne bramki 
            if (pointNumber < arraySize)
            {
                Instantiate(pointGhost, pointsPosition[pointNumber-1], Quaternion.identity, transform);
                Instantiate(point, pointsPosition[pointNumber], Quaternion.identity, transform);
                Instantiate(waveGenerator, pointsPosition[pointNumber], Quaternion.identity, transform);
				//przeslanie danych o kolejnych bramkach do kompaso-tla
				compassIns.CompassAction(pointsPosition[pointNumber]);     
				pointNumber++;
            }
            ResetPlayerPos();
		}
		//Cofamy gracza jesli skonczy mu sie czas np co 5, 10, 15 sekund
		else if (i < timeForPlayer.Length && mainTime - howMuchTime >= (timeForPlayer[i] * tempCounter))
		{
			tempCounter++;
			ResetPlayerPos();
        }
	}
	//Wywolujemy gdy graczowi skonczy sie czas, powrot na start
	public void ResetPlayerPos()
	{
		if (i != pointsPosition.Length)
		{
            soundManagerScript.resetSound();
            //Wysylamy czas do punktu do UI
            TimeLeft.onScreen = timeForPlayer[i];
			attemptCounter++;
			playerPos.transform.position = startPos;
			//Pauza gry przy starcie resecie itp
			if(wantSumStart)
			{
				Time.timeScale = 0;
				startButton.gameObject.SetActive(true);
			}
		}
	}
    public void ResetPlayerPosButton()
    {
        soundManagerScript.resetSound();
        //Wysylamy czas do punktu do UI
        tempCounter = 1f;
		howMuchTime = mainTime;
        TimeLeft.onScreen = timeForPlayer[i];
        attemptCounter++;
        playerPos.transform.position = startPos;
		//Pauza gry przy starcie resecie itp
		if (wantSumStart)
		{
			Time.timeScale = 0;
			startButton.gameObject.SetActive(true);
		}
	}
	//Przycisk moze wywolac tylko funkcjie void wiec potrzebny jest wrapper
	//A wrapper function is a subroutine in a software library or a computer program whose main purpose is to 
	//Call a second subroutine
	public void Wrapper()
	{
		Time.timeScale = 1;
		startButton.gameObject.SetActive(false);
	}
	public void SaveProgress()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        BinaryFormatter bf = new BinaryFormatter();

        if (File.Exists(Application.persistentDataPath + "/progressData.dat"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/progressData.dat", FileMode.Open);
            ProgressData dataToSave = new ProgressData();
            dataToSave = (ProgressData)bf.Deserialize(file);
            file.Close();
            if ( dataToSave.attemptsS[index] > attemptCounter || dataToSave.attemptsS[index] == 0) {
                dataToSave.attemptsS[index] = (int)attemptCounter;
                
                File.Delete(Application.persistentDataPath + "/progressData.dat");

                file = File.Create(Application.persistentDataPath + "/progressData.dat");
                bf.Serialize(file, dataToSave);
                file.Close();
            }
        }
        else
        {
            FileStream file = File.Create(Application.persistentDataPath + "/progressData.dat");
            ProgressData dataToSave = new ProgressData();
            dataToSave.attemptsS[index] = (int)attemptCounter;
            bf.Serialize(file, dataToSave);
            file.Close();
        }
    }
    public void MenuAttemptsRestart()
    {
        attemptCounter = 1;
    }
}
[Serializable]
public class ProgressData
{
    public int[] attemptsS = new int [100];
}
