using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ChargerScene(string nomScene)
    {
        Debug.Log("LAAAAAAAAAAAAAAAAAA");
        SceneManager.LoadScene(nomScene);
        SceneManager.UnloadScene("Menu Principal");
    }

    // Méthode pour quitter le jeu
    public void QuitterJeu()
    {
        // Quitter l'application
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
