using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem; 

public class Bloc : MonoBehaviour
{
    private Logique logique;
    private SpriteRenderer spriteRenderer;
    
    private int IDbloc;
    private Color couleur;

    public void Init(Logique logique, int IDbloc, Color couleur)
    {
        this.logique = logique;
        this.IDbloc = IDbloc;
        this.couleur = couleur;
        spriteRenderer = GetComponent<SpriteRenderer>();
       
       Desactiver();
    }
    public void Desactiver()
    {
        spriteRenderer.color = couleur * 0.3f;
    }
    public void Activer()
    {
        spriteRenderer.color = couleur;
    }

   private void OnMouseDown()
    {
        logique.JouerLumiereetTon(IDbloc);
    }

  
}
