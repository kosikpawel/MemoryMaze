using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

public class MenuDataServer : MonoBehaviour
{
    public GameObject currentMenuPage;          //referencja do aktualnie wyswietlanego canvasa
    //private GameObject menu;                    

    private ProgressData dataToLoad;            //referencja do skryptu 
    private bool avalable = false;              //do sprawdzania czy dane sa dostepne
    


    void Awake()
    {
        //menu = currentMenuPage;

        //jeżeli istnieje plik z zapisanymi danymi to otworz go, pobierz z niego dane
        //i ustaw że dane sa dostepne do pobrania
        if (File.Exists(Application.persistentDataPath + "/progressData.dat")) 
        {
            BinaryFormatter bf = new BinaryFormatter();

            FileStream file = File.Open(Application.persistentDataPath + "/progressData.dat", FileMode.Open);

            dataToLoad = (ProgressData)bf.Deserialize(file);
            file.Close();
            avalable = true;
        }
    }
    // metoda zwraca string postaci "2 / 2" dla danego lvl jezeli dane sa niedostepne zwraca null
    public string ScoreLoadedText(int levelNumber)
    {
        if (avalable)
        {
            String fullText = "";
            if(dataToLoad.attemptsS[levelNumber] != 0)
            {
                fullText += "sc: " + dataToLoad.attemptsS[levelNumber].ToString();// + " / " + dataToLoad.minimalS[levelNumber].ToString();
            }
            return fullText;
        }

        return null;
    }

    //metodami bo jak zaczynalem mialem troche inny pomysl a dziala i jest ciekawe :P
    //metoda zmieniajaca zmienna przechowujaca referencje do aktaualnie wyswietlanej strony menu
    public void SetCurrentMenuPage(GameObject newOne)
    {
        currentMenuPage = newOne;
    }
    //metoda zwracajaca referencje do aktualnie wyswietlanej strony menu
    public GameObject LoadCurrentMenuPage()
    {
        return currentMenuPage;
    }

}