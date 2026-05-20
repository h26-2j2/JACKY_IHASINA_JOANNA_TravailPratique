using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour
{
    public bool accepteObjet = true; // Indique si la zone de dépôt accepte les objets
    public int id = 0; // Identifiant de la zone de dépôt (Permet d'associer une zone de dépôt à un objet spécifique si nécessaire)

    public void AuDeposer(BaseEventData eventData)
    {
        PointerEventData pointerData = eventData as PointerEventData;
        if (pointerData != null)
        {
            GameObject objetGlisse = pointerData.pointerDrag; // Récupère l'objet en train d'être glissé
            if (objetGlisse != null)
            {
                // Logique pour gérer le dépôt de l'objet (par exemple, vérifier si c'est le bon objet, le placer dans la zone, etc.)
                Debug.Log("Objet déposé : " + objetGlisse.name);

                // Récupère le script DragObject attaché à l'objet glissé pour accéder à ses propriétés et méthodes pour être plus optimisé que de faire plusieurs GetComponent<DragObject>() dans le code
                DragObject dragObject = objetGlisse.GetComponent<DragObject>();

                // Si la zone de dépôt accepte les objets et que l'objet glissé a le même identifiant que la zone de dépôt,
                // alors on considère que l'objet est déposé au bon endroit
                if (accepteObjet && dragObject != null && dragObject.id == id)
                {
                    // Logique pour gérer le dépôt de l'objet (par exemple, vérifier si c'est le bon objet, le placer dans la zone, etc.)
                    Debug.Log("Objet déposé : " + objetGlisse.name);

                    // La zone de dépôt n'accepte plus d'objets après le dépôt réussi. Cela empêche de déposer plusieurs objets dans la même zone.
                    accepteObjet = false;

                    // Logique pour gérer le cas où l'objet est déposé au bon endroit
                    Debug.Log("L'objet a été déposé au bon endroit !");
                    dragObject.estAuBonEndroit = true; // Indique que l'objet est déposé au bon endroit (donc ne sera pas réinitialisé à sa position initiale dans la méthode OnEndDrag du script DragObject)

                    // Place l'objet à la position de la zone de dépôt (optionnel, dépend du comportement souhaité)
                    objetGlisse.transform.position = transform.position;

                    // Fait de l'objet glissé un enfant de la zone de dépôt pour qu'il suive les mouvements de la zone de dépôt si elle se déplace
                    // (optionnel, dépend du comportement souhaité)
                    objetGlisse.transform.SetParent(this.transform);
                }
            }
        }
    }
}