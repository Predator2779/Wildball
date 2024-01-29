using System.Collections.Generic;
using EditorExtension;
using UnityEngine;

#if UNITY_EDITOR
[ExecuteAlways]
public class LightSettings : MonoBehaviour
{
    [SerializeField] private Transform[] _objs;
    [SerializeField] private string[] _names;
    [SerializeField] private List<Light> _lights;

    [EditorButton("Get All Light")]
    public void GetLights()
    {
        foreach (var obj in _objs)
            GetLight(obj);

        print("Done.");
    }

    [EditorButton("Switch Lights")]
    public void SwitchLight()
    {
        foreach (var light in _lights)
        {
            if (light.enabled)
                light.enabled = false;
            else
                light.enabled = true;
        }

        print("Done.");
    }

    [EditorButton("Remove Lights")]
    public void RemoveLights()
    {
        foreach (var light in _lights) DestroyImmediate(light);

        print("Done.");
    }

    [EditorButton("Clear Lights")]
    public void ClearLights() => _lights.Clear();

    [EditorButton("Set Baked")]
    public void SetBaked()
    {
        if (_lights != null)
            foreach (var light in _lights)
            {
                if (light.gameObject.isStatic && light.TryGetComponent(out Light pointLight))
                    pointLight.lightmapBakeType = LightmapBakeType.Baked;
            }

        print("Done.");
    }

    private void GetLight(Transform t)
    {
        if (t.TryGetComponent(out Light component) /* && IsCorrectName(t.name)*/)
            _lights.Add(component);

        var count = t.childCount;

        if (count < 1) return;

        for (int i = 0; i < count; i++)
        {
            var child = t.GetChild(i);

            GetLight(child);
        }
    }

    // private void GetAllChilds(GameObject go)
    // {
    //     print($"go.name: {go}");
    //
    //     _gObjs.Add(go);
    //
    //     var count = go.transform.childCount;
    //
    //     if (count < 1) return;
    //
    //     for (int i = 0; i < count; i++)
    //     {
    //         var child = go.transform.GetChild(i);
    //
    //         GetAllChilds(child.gameObject);
    //     }
    // }

    private bool IsCorrectName(string nameObj, int num)
    {
        foreach (var name in _names)
            for (int i = 1; i <= num; i++)
                if (nameObj == $"{name} ({i})")
                    return true;

        return false;
    }
}
#endif