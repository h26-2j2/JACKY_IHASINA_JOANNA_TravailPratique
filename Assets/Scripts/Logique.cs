using UnityEngine;
using System.Collections;
public class Logique : MonoBehaviour
{
    [Header("Setup du Jeu")]
    [SerializeField] private int rangee = 3;
    [SerializeField] private int colonne = 4;
    private int numBlocs;
    private Bloc[] bloc;

    [Header("Objets")]
    [SerializeField] private Bloc blocPrefab;
    [SerializeField] private Transform scene;

    [Header("Audio Setup")]
    [SerializeField] private float duree = 0.2f;


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
                bloc[index].Init(this, index, Color.HSVToRGB((float)index / numBlocs, 0.8f, 0.9f));
                float rangeeDebut = (rangee / 2f) - 0.5f;
                float ColDebut = (-colonne / 2f) + 0.5f;
                bloc[index].transform.localPosition = new Vector3(ColDebut + col, rangeeDebut - row, 0f);

            }
        }

        float scale = 6f / rangee;
        scene.localScale = Vector3.one * scale;
    }

    private IEnumerator FlashBloc(int index)
    {
        bloc[index].Activer();
        yield return new WaitForSeconds(duree);
        bloc[index].Desactiver();
    }
    public void JouerLumiereetTon(int index)
    {
        StartCoroutine(FlashBloc(index));
    }
}
