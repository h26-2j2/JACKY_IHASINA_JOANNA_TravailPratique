using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Trouver4 : MonoBehaviour
{
    public TMP_Text textePoints; 
    private int compteur = 0;
    private int totalObjectifs = 4;
    public string nomScene;

    void Start()
    {

        textePoints.text = "Objets acquis : 0";
    }

    public void VerifierObjet(GameObject objetslogique)
    {
        if (objetslogique.CompareTag("objet"))
        {
            compteur++;
            
    
            textePoints.text = "Objets acquis : " + compteur;

            if (compteur >= totalObjectifs)
            {
                SceneManager.LoadScene(nomScene); 
            }
        }
    }
}