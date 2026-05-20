using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Trouver4 : MonoBehaviour
{
    public TMP_Text textePoints;
    private int compteur = 0;
    private int totalObjectifs = 4;
    public string nomScene;
    public GameObject boutonSuivant;
    public GameObject felicitations;

    void Start()
    {
            boutonSuivant.SetActive(false);
            felicitations.SetActive(false);
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
                    boutonSuivant.SetActive(true);
                    felicitations.SetActive(true);
            }
        }
    }
}