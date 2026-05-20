using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
public class Logique : MonoBehaviour
{
    //Tutoriel de Firnox Utilisé et adapté
    [Header("Setup du Jeu")]
    [SerializeField] private int rangee = 3;
    [SerializeField] private int colonne = 4;
    private int numBlocs;
    private Bloc[] bloc;

    [Header("Objets")]
    [SerializeField] private Bloc blocPrefab;
    [SerializeField] private Transform scene;
    [SerializeField] private GameObject boutonJeu;
    [SerializeField] private GameObject boutonNiveauSuivant;
    [SerializeField] private GameObject texteVictoire;

    [Header("Audio Setup")]
    [SerializeField] private float duree = 0.2f;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip sonVictoire;

    enum ModeDeJeu { Rien, Menu, Ecouter, Jouer }
    private ModeDeJeu modeDejeu = ModeDeJeu.Rien;

    private List<int> niveauBloc;
    private int indexPrecis = 0;
    private int niveauActuel = 0;
    private int[] tailleSequences = { 3, 4, 5};

    void Start()
    {
        numBlocs = rangee * colonne;
        bloc = new Bloc[numBlocs];

        for (int row = 0; row < rangee; row++)
        {
            for (int col = 0; col < colonne; col++)
            {
                int index = (row * colonne) + col;
                bloc[index] = Instantiate(blocPrefab, scene);
                bloc[index].Init(this, index, Color.HSVToRGB((float)index / numBlocs, 0.7f, 0.6f));
                float rangeeDebut = (rangee / 2f) - 0.5f;
                float ColDebut = (-colonne / 2f) + 0.5f;
                bloc[index].transform.localPosition = new Vector3(ColDebut + col, rangeeDebut - row, 0f);
            }
        }

        float scale = 6f / rangee;
        scene.localScale = Vector3.one * scale;
        boutonNiveauSuivant.SetActive(false);
        texteVictoire.SetActive(false);
        modeDejeu = ModeDeJeu.Menu;
        StartCoroutine(MenuAnim());
    }

    private IEnumerator MenuAnim()
    {
        while (modeDejeu == ModeDeJeu.Menu)
        {
            yield return FlashBloc(Random.Range(0, numBlocs));
            yield return new WaitForSeconds(duree);
        }
    }

    private IEnumerator FlashBloc(int index)
    {
        bloc[index].Activer();
        yield return new WaitForSeconds(duree);
        bloc[index].Desactiver();
    }

    public void JouerLumiereetTon(int index)
    {
        if (modeDejeu == ModeDeJeu.Jouer)
        {
            StartCoroutine(FlashBloc(index));

            if (index == niveauBloc[indexPrecis])
            {
                JouerSon(index);
                indexPrecis++;

                if (indexPrecis == niveauBloc.Count)
                {
                    niveauActuel++;
                    audioSource.PlayOneShot(sonVictoire);

                    if (niveauActuel >= tailleSequences.Length)
                    {
                        modeDejeu = ModeDeJeu.Menu;
                        audioSource.PlayOneShot(sonVictoire);
                        boutonNiveauSuivant.SetActive(true);
                        texteVictoire.SetActive(true);
                    }
                    else
                    {
                        StartCoroutine(LancerNiveau());
                    }
                }
            }
            else
            {
                modeDejeu = ModeDeJeu.Menu;
                JouerSonErreur();
                StartCoroutine(RecommencerNiveau());
            }
        }
    }

    private IEnumerator RecommencerNiveau()
    {
        yield return new WaitForSeconds(duree * 4);
        modeDejeu = ModeDeJeu.Menu;
        boutonJeu.SetActive(true);
    }

    private void JouerSonErreur()
    {
        audioSource.pitch = 0.5f;
        double sonJouerMoment = AudioSettings.dspTime;
        audioSource.PlayScheduled(sonJouerMoment);
        audioSource.SetScheduledEndTime(sonJouerMoment + 3 * duree);
    }

    private void JouerSon(int index)
    {
        if (numBlocs > 1)
        {
            audioSource.pitch = Mathf.Lerp(1.0f, 3.0f, index / (numBlocs - 1f));
            double sonJouerMoment = AudioSettings.dspTime;
            audioSource.PlayScheduled(sonJouerMoment);
            audioSource.SetScheduledEndTime(sonJouerMoment + duree);
        }
    }

    public void Lejeu()
    {
        boutonJeu.SetActive(false);
        niveauActuel = 0;
        StartCoroutine(LancerNiveau());
    }

    private IEnumerator LancerNiveau()
    {

        int taille = tailleSequences[niveauActuel];
        niveauBloc = new List<int>();
        for (int i = 0; i < taille; i++)
            niveauBloc.Add(Random.Range(0, numBlocs));

        yield return JouerSequence();
    }

    private IEnumerator JouerSequence()
    {
        modeDejeu = ModeDeJeu.Ecouter;
        yield return new WaitForSeconds(2f);

        foreach (int index in niveauBloc)
        {
            JouerSon(index);
            yield return FlashBloc(index);
            yield return new WaitForSeconds(duree);
        }

        indexPrecis = 0;
        modeDejeu = ModeDeJeu.Jouer;
    }
    
}