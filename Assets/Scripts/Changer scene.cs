using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Changerscene : MonoBehaviour
{
   public string sceneIntro = "Intro";
   public string Dialogue = "Dialogue";
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
}
