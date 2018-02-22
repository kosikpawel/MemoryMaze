using UnityEngine;
using UnityEngine.UI;

public class LoadScorData : MonoBehaviour {
    
    public MenuDataServer server;                               //referencja do servera menu
    public Text scoreText;                                      //referencja do wyswietlania tekstu
    private int level;                                          //zmienna na indeks levelu
    private string fullText;                                    //zmienna w ktorej tworzony bedzie tekst
    private LoadLv myParent;                                    //referencja do skryptu znajdujacego sie w rodzicu obiektu
    

    void Start()
    {
        myParent = this.GetComponentInParent<LoadLv>();         //lokalizuje rodzica
        level = myParent.levelIndex;                            //pobiera index levelu od rodzica
        fullText = "LVL " + level.ToString();                   //tworzy text dla level=1 -> LVL 1
        if (server.ScoreLoadedText(level) != null)              //jezeli funkcja moze zwrocic jakies dane
        {
            fullText += "\n" + server.ScoreLoadedText(level);   // uzupelnia stworzony text o wynik w nim osiagnienty np 2/2
        }
           
        scoreText.text = fullText;                              //wyswietla utworzony text na ekranie
    }
}
