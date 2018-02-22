using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class DeleteScoreboard : MonoBehaviour {

    public void deleteSb()
    {
        File.Delete(Application.persistentDataPath + "/progressData.dat");  //usowa plik z danymi
        SceneManager.LoadScene(0);                                          //i ponownie wczytuje strone menu
    }
}
