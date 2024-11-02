using UnityEngine;

public class Script_Geral_TamanhoChange : MonoBehaviour
{
    [SerializeField] float tamanhoOffset;

    void Update()
    {
        transform.localScale += tamanhoOffset * Time.deltaTime * Vector3.one;
    }
}