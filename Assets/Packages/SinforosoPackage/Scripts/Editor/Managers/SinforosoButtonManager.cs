using System.Reflection;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MonoBehaviour), true)]
public class SinforosoButtonManager : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        MonoBehaviour _componente = (MonoBehaviour)target;
        MethodInfo[] _metodos = _componente.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        foreach (MethodInfo _metodo in _metodos)
        {
            var _atributos = _metodo.GetCustomAttributes(typeof(SinforosoButton), false);

            if (_atributos.Length > 0)
            {
                if (GUILayout.Button(_metodo.Name))
                {
                    _metodo.Invoke(_componente, null);
                }
            }
        }
    }
}