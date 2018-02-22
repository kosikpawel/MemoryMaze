using UnityEngine;

public class LevelSelectPages : MonoBehaviour {
    //public Vector3 nextPagePos;
    public GameObject nextMenuPage;             //podana w oknie unity referencja do oczekiwanej nastepnej strony menu (canvasa)
    public MenuDataServer server;               //referencja do serveraMenu
    public GameObject currentPage;              //aktualnie wyswietlana strona
    
    
    public void TeleportToPage()
    {
        currentPage = server.LoadCurrentMenuPage();     //pobiera z servera referencje aktualnie wyswietlanej strony
        currentPage.SetActive(false);                   //wylacza ja
        nextMenuPage.SetActive(true);                   //wlacza nastepna
        server.SetCurrentMenuPage(nextMenuPage);        //ustawia nowa strone na aktualna w serverze
    }
}
