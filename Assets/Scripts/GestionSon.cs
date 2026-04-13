using UnityEngine;

public class GestionSon : MonoBehaviour
{
    public AudioSource maSource; 
    public void ToggleMusique()
    {
        if (maSource.isPlaying)
        {
            maSource.Pause(); 
          
        }
        else
        {
            maSource.Play();
        }
    }
}

