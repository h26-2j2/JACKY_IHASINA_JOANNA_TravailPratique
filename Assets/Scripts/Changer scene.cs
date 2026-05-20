using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Changerscene : MonoBehaviour
{
   public string sceneIntro = "Intro";
   public string Dialogue = "Dialogue";
    public string Dialogue2 = "Dialogue2";
    public string Dialogue3 = "Dialogue3";
     public string Niveau1 = "Niveau1";
    public string Niveau2 = "Niveau2";
    public string Niveau3 = "Niveau3";
    public string Fin = "Fin";
    void Update()
    {
    }
     public void Intro()
    {
      
        SceneManager.LoadScene("Intro");
    }
    public void DemarrerJeu()
    {
      
        SceneManager.LoadScene("Dialogue");
    }
       public void PasserAujeu()
    {
      
        SceneManager.LoadScene("Niveau1");
    }
     public void DialogueDeux()
    {
      
        SceneManager.LoadScene("Dialogue02");
    }
         public void NiveauDeux()
    {
      
        SceneManager.LoadScene("Niveau2");
    }
           public void DialogueTrois()
    {
      
        SceneManager.LoadScene("Dialogue03");
    }
           public void Niveautrois()
    {
      
        SceneManager.LoadScene("Niveau3");
    }
     public void FinJeu()
    {
      
        SceneManager.LoadScene("Fin");
    }
}
