using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_StackController : MonoBehaviour
{
    [SerializeField] GameObject prefab_stack;
    [SerializeField] List<Transform> list_t_stack;
    [SerializeField] float followSpeed;
    [SerializeField] Transform pai_stack;
    [SerializeField] Transform t_back;

    int quant_current = 0;
    int quant_max = 3;

    void Start()
    {
        Script_GameManager.instance.Txt_Stack_Set(quant_current, quant_max);
    }

    void Update()
    {
        for (int i = 0; i < list_t_stack.Count; i++)
        {
            Vector3 _targetPos = t_back.position + Vector3.up * i;
            float _individualSpeed = followSpeed / (i + 1);

            list_t_stack[i].position = Vector3.Lerp(list_t_stack[i].position, _targetPos, _individualSpeed * Time.deltaTime);
            list_t_stack[i].eulerAngles = t_back.eulerAngles;
        }
    }

    [SinforosoButton]
    public void Stack_Create()
    {
        if (quant_current < quant_max)
        {
            Transform _t = Instantiate(prefab_stack, Vector3.zero, Quaternion.identity).transform;
            _t.parent = pai_stack;

            _t.position = t_back.position + Vector3.up * list_t_stack.Count;
            list_t_stack.Add(_t);

            quant_current++;
            Script_GameManager.instance.Txt_Stack_Set(quant_current, quant_max);
        }
        else
        {
            Debug.Log("ja esta carregando a quantidade maxima");
        }        
    }

    public void Call_ThrowRoutine()
    {
        if (quant_current == 0) return;
        StartCoroutine(ThrowRoutine());
    }

    IEnumerator ThrowRoutine()
    {
        for (int i = list_t_stack.Count - 1; i >= 0; i--)
        {
            list_t_stack[i].gameObject.SetActive(false);

            Script_GameManager.instance.Player_Money_Set(10);
            
            yield return new WaitForSeconds(0.1f);

            Destroy(list_t_stack[i].gameObject, 0.1f * list_t_stack.Count + (0.1f * i));
        }

        list_t_stack.Clear();
        Quant_Current_Reset();
    }

    public void Quant_Current_Reset()
    {
        quant_current = 0;
        Script_GameManager.instance.Txt_Stack_Set(quant_current, quant_max);
    }

    public void Quant_Max_Increment()
    {
        quant_max++;
        Script_GameManager.instance.Txt_Stack_Set(quant_current, quant_max);
    }
}