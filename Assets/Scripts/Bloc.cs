using System;
using UnityEngine;

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
    public void activer()
    {
        spriteRenderer.color = couleur;
    }

   public void OnMouseDown()
    {
        //logique
        //jouer lumiereson
    }

  
}
