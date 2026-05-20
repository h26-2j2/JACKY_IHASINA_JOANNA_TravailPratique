using UnityEngine;
using UnityEngine.EventSystems;

public class DragObject : MonoBehaviour
{
    private Vector3 positionInitiale;
    Collider2D collider2D;
    public int id = 0; // Identifiant de l'objet (Permet d'associer un objet à une zone de dépôt spécifique si nécessaire)
    public bool estAuBonEndroit = false; // Indique si l'objet est déposé au bon endroit

    void Start(){
        positionInitiale = transform.position; // Enregistre la position initiale de l'objet
        collider2D = GetComponent<Collider2D>();//On doit désactiver le collider de l'objet pendant le glisser-déposer pour que le raycast puisse détecter la zone de dépôt
    }

    public void AuDebutDeplacer(BaseEventData eventData)
    {
        PointerEventData pointerData = eventData as PointerEventData;
        if (pointerData != null)
        {
            Vector3 positionCurseur = Camera.main.ScreenToWorldPoint(pointerData.position);
            transform.position = positionCurseur; // Place l'objet à la position du curseur au début du glisser
            collider2D.enabled = false; // Désactive le collider pour permettre la détection de la zone de dépôt
        }

    }

    public void AuDeplacer(BaseEventData eventData)
    {
         PointerEventData pointerData = eventData as PointerEventData;
        if (pointerData != null)
        {
            Vector3 positionCurseur = Camera.main.ScreenToWorldPoint(pointerData.position);
            transform.position = positionCurseur; // Place l'objet à la position du curseur au début du glisser
        }
    }

    public void AuFinDeplacer(BaseEventData eventData)
    {
        // Optionnel : Ajouter une logique pour réinitialiser la position ou effectuer d'autres actions
        if (estAuBonEndroit== false)
        {
            transform.position = positionInitiale; // Réinitialise la position si l'objet n'est pas déposé au bon endroit
            collider2D.enabled = true; // Réactive le collider une fois le glisser-déposer terminé pour permettre les interactions à nouveau
        }else{
            // Logique pour gérer le cas où l'objet est déposé au bon endroit (par exemple, désactiver l'objet ou le rendre non interactif)
            //collider2D.enabled = false; // Désactive le collider pour éviter les interactions supplémentaires
            //gameObject.SetActive(false); // Désactive l'objet une fois qu'il est déposé au bon endroit
        }
    }
}