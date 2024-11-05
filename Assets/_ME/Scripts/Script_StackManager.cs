using System.Collections.Generic;
using UnityEngine;

public class Script_StackManager : MonoBehaviour
{
    [SerializeField] bool test;
    [SerializeField] GameObject prefab_stack;
    [SerializeField] List<Transform> list_t_stack;
    [SerializeField] float moveSpeed;
    [SerializeField] float followSpeed;
    [SerializeField] Transform pai_stack;
    [SerializeField] Transform t_back;

    void Update()
    {
        if (test)
        {
            float _h = Input.GetAxisRaw("Horizontal");
            transform.position += new Vector3(_h, 0, 0) * Time.deltaTime;
        }        

        for (int i = 0; i < list_t_stack.Count; i++)
        {
            Vector3 _targetPos = t_back.position + Vector3.up * i;
            float _individualSpeed = followSpeed / (i + 1);
            list_t_stack[i].position = Vector3.Lerp(list_t_stack[i].position, _targetPos, _individualSpeed * Time.deltaTime);
            list_t_stack[i].eulerAngles = t_back.eulerAngles;
        }
    }

    [SinforosoButton]
    void Stack_Create()
    {
        Transform _t = Instantiate(prefab_stack, Vector3.zero, Quaternion.identity).transform;
        _t.parent = pai_stack;

        _t.position = t_back.position + Vector3.up * list_t_stack.Count;
        list_t_stack.Add(_t);
    }
}