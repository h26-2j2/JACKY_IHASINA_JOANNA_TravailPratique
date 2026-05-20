using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class DropZone : MonoBehaviour
{
    public int nombreRequis = 4;
    private int nbrMis = 0;
    public int id = 0;
        public AudioClip BonEndroit;
    private AudioSource audioSource;
     public TMP_Text compteur;

void Start()
    {
        audioSource = GetComponent<AudioSource>();
        compteur.text = $"0 / {nombreRequis}";
    }
    public void AuDeposer(BaseEventData eventData)
    {
        PointerEventData pointerData = eventData as PointerEventData;
        if (pointerData != null)
        {
            GameObject objetGlisse = pointerData.pointerDrag;
            if (objetGlisse != null)
            {
                DragObject dragObject = objetGlisse.GetComponent<DragObject>();
                if (dragObject != null && dragObject.id == id)
                {
                    audioSource.PlayOneShot(BonEndroit);
                    nbrMis++;
                    dragObject.estAuBonEndroit = true;
                    objetGlisse.transform.position = transform.position;
                    objetGlisse.transform.SetParent(this.transform);
                    compteur.text = $"{nbrMis} / {nombreRequis}";
                    VerifierVictoire();
                }
            }
        }
    }

    void VerifierVictoire()
    {
        foreach (DropZone zone in FindObjectsOfType<DropZone>())
        {
            if (zone.nbrMis < zone.nombreRequis) return;
        }
    }
}