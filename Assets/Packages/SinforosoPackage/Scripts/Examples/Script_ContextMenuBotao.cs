using System.Reflection;
using UnityEditor;
using UnityEngine;

public class Script_ContextMenuBotao : MonoBehaviour //dentro da classe pq senn da conflito de namespace
{
    #region context menu bonito
#if UNITY_EDITOR
    [CustomEditor(typeof(Script_ContextMenuBotao))]
    public class ContextMenuButton : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            Script_ContextMenuBotao _componente = (Script_ContextMenuBotao)target;
            MethodInfo[] _metodos = typeof(Script_ContextMenuBotao).GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (MethodInfo _metodo in _metodos)
            {
                var _atributos = _metodo.GetCustomAttributes(typeof(ContextMenu), false);

                if (_atributos.Length > 0)
                {
                    var _contextMenu = _atributos[0] as ContextMenu;

                    if (GUILayout.Button(_contextMenu.menuItem))
                    {
                        _metodo.Invoke(_componente, null);
                    }
                }
            }
        }
    }
#endif
    #endregion
}