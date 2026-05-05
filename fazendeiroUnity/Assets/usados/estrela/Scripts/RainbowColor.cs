using System.Collections;
using UnityEngine;

public class RainbowColor : MonoBehaviour
{
    public Material mt;
    public Color32[] colors;
    void Start()
    {
        mt = transform.GetComponent<MeshRenderer>().material;
        colors = new Color32[7]{
            new Color32(255, 0, 0, 255), //vermelho
            new Color32(255, 165, 0, 255), //laranja
            new Color32(255, 255, 0, 255), //amarelo
            new Color32(0, 255, 0, 255), //verde
            new Color32(0, 0, 255, 255), //azul
            new Color32(75, 0, 130, 255), //indigo
            new Color32(238, 130, 238, 255), //violeta
        };
        StartCoroutine(Ciclo());
    }

    public IEnumerator Ciclo(){
        int cor0 = 0;
        int corf = 0;
        cor0 = Random.Range(0, colors.Length);
        corf = Random.Range(0, colors.Length);
        while(true){
            for(float interpolant = 0f; interpolant < 1f; interpolant += 0.01f){
                mt.color = Color.Lerp(colors[cor0], colors[corf], interpolant);
                yield return null;
            }
            cor0 = corf;
            corf = Random.Range(0, colors.Length);
        }
    }
}
