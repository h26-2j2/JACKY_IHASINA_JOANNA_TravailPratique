using UnityEngine;

public class pluieobj : MonoBehaviour
{
    public Vector2 size;
    private SpriteRenderer spriteRenderer;
    float vitesse;
    float vitesseRot;
    public float tauxRedux = 0.05f;
    public bool estTombe = true;
   public void FinTestTombe()
    {
        estTombe = false;
    }

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (!spriteRenderer) spriteRenderer = gameObject.AddComponent<SpriteRenderer>();


        if (CompareTag("cartes")) vitesse = Random.Range(-0.01f, -0.02f);
        else if (CompareTag("tasses")) vitesse = Random.Range(-0.02f, -0.035f);
        else if (CompareTag("patisseries")) vitesse = Random.Range(-0.01f, -0.025f);
        else vitesse = Random.Range(-0.01f, -0.04f);

        vitesseRot = Random.Range(0.05f, 0.8f);
    }

    void Update()
    {
        if (!estTombe) return;

        float nouvellePositionY = transform.position.y + vitesse;
        float nouvellePositionX = transform.position.x;

        transform.Rotate(0, 0, vitesseRot);

        if (nouvellePositionY < -6.5f)
        {
            nouvellePositionY = 6.5f;
            nouvellePositionX = Random.Range(-8f, 8f);
        }
        transform.position = new Vector2(nouvellePositionX, nouvellePositionY);
    }


}
