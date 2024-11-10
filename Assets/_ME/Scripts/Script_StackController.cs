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
        Transform _t = Instantiate(prefab_stack, Vector3.zero, Quaternion.identity).transform;
        _t.parent = pai_stack;

        _t.position = t_back.position + Vector3.up * list_t_stack.Count;
        list_t_stack.Add(_t);

        quant_current++;
    }
}