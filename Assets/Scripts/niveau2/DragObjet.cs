using UnityEngine;
using UnityEngine.EventSystems;


public class DragObject : MonoBehaviour
{
    private Vector3 positionInitiale;
    Collider2D collider2D;
    public int id = 0; 
    public bool estAuBonEndroit = false; 

    void Start(){
        positionInitiale = transform.position; 
        collider2D = GetComponent<Collider2D>();//On doit désactiver le collider de l'objet pendant le glisser-déposer pour que le raycast puisse détecter la zone de dépôt
    }

public void AuDebutDeplacer(BaseEventData eventData)
{
    PointerEventData pointerData = eventData as PointerEventData;
    if (pointerData != null)
    {
        collider2D.enabled = false;
        Vector3 positionCurseur = new Vector3(pointerData.position.x, pointerData.position.y, Camera.main.WorldToScreenPoint(transform.position).z);
        transform.position = Camera.main.ScreenToWorldPoint(positionCurseur);
    }
}


    public void AuDeplacer(BaseEventData eventData)
    {
         PointerEventData pointerData = eventData as PointerEventData;
    if (pointerData != null)
    {
        Vector3 positionCurseur = Camera.main.ScreenToWorldPoint(pointerData.position);
        positionCurseur.z = transform.position.z;
        transform.position = positionCurseur;
    }
}
    public void AuFinDeplacer(BaseEventData eventData)
    {
        if (estAuBonEndroit== false)
        {
            collider2D.enabled = true; 
        transform.position = positionInitiale;
        }else{
            //collider2D.enabled = false;
            //gameObject.SetActive(false);
        }
    }
}