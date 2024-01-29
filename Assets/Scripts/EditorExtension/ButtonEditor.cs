using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace EditorExtension
{
#if UNITY_EDITOR

    /// <summary>
    /// Draw button in Inspector
    /// </summary>
    [CustomEditor(typeof(Object), true, isFallback = false)]
    [CanEditMultipleObjects]
    public class ButtonEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            foreach (var target in targets)
            {
                var mis = target.GetType().GetMethods().Where(m => m.GetCustomAttributes().Any(a => a.GetType() == typeof(EditorButton)));
                if (mis != null)
                {
                    foreach (var mi in mis)
                    {
                        if (mi != null)
                        {
                            var attribute = (EditorButton)mi.GetCustomAttribute(typeof(EditorButton));
                            if (GUILayout.Button(attribute.Name))
                            {
                                mi.Invoke(target, null);
                            }
                        }
                    }
                }
            }
        }
    }

#endif
}