using UnityEngine;
using UnityEngine.InputSystem;

public class DeplacementPlatformer : MonoBehaviour
{
    private Rigidbody2D rb;
Animator anim;
SpriteRenderer sprite;
    public InputAction actionMarche;
    public float accelerationMarche;
    public float vitesseXMax;
    public float vitesseXActuelle;

    public float vitesseYMax;

    public void OnEnable()
    {
        actionMarche.Enable();
    }

    public void OnDisable()
    {
        actionMarche.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }
void Update()
    { 
        float velociteX = Mathf.Abs(rb.linearVelocityX);
        

        if (velociteX > 0.1f)
            anim.SetFloat("vitesse", velociteX);
        else
            anim.SetFloat("vitesse", 0); 
    }
    void FixedUpdate()
    {

        float axeMarche = actionMarche.ReadValue<float>();
        rb.linearVelocityX += axeMarche * accelerationMarche * Time.fixedDeltaTime;
        rb.linearVelocityX = Mathf.Clamp(rb.linearVelocityX, -vitesseXMax, vitesseXMax);
        
    
        if (axeMarche > 0)
            sprite.flipX = false; 
        else if (axeMarche < 0)
            sprite.flipX = true;
    }
}
