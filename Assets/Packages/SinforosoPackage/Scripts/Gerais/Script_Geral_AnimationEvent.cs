using UnityEngine;
using UnityEngine.Events;

public class Script_Geral_AnimationEvent : MonoBehaviour
{
    [SerializeField] UnityEvent[] evento;

    public void Call_Evento(int _index)
    {
        evento[_index]?.Invoke();
    }
}