using UnityEngine;
using UnityEngine.SceneManagement;


public class Changerscene : MonoBehaviour
{
   public string sceneIntro = "Intro";
   public string Dialogue = "Dialogue";

    public void DemarrerJeu()
    {
        Debug.Log("Button clicked! Attempting to load scene: Dialogue");
        SceneManager.LoadScene("Dialogue");
    }
    
}
