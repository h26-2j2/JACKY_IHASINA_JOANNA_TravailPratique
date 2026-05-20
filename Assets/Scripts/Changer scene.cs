using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Changerscene : MonoBehaviour
{
   public string sceneIntro = "Intro";
   public string Dialogue = "Dialogue";
    public string Fin = "Fin";
    void Update()
    {
    }
    public void DemarrerJeu()
    {
      
        SceneManager.LoadScene("Dialogue");
    }
       public void PasserAujeu()
    {
      
        SceneManager.LoadScene("Niveau1");
    }
     public void FinJeu()
    {
      
        SceneManager.LoadScene("Fin");
    }
}
