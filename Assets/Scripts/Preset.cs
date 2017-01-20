using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Preset : MonoBehaviour
{
    public enum ePreset
    {
        Default,
        GrayScale,
        SepiaTone,
        MAX
    }

    [HideInInspector]
    public ePreset index;
    public static ePreset currentIndex = ePreset.Default;

    public virtual void SetData(ePreset presetIndex)
    {
        index = presetIndex;
        ResetAllPreset();
    }

    public virtual void BackupDefaultData()
    {

    }

    public static void ResetAllPreset()
    {
        if (CameraController.instance.DicFilter.Count <= 0)
            return;

        using (Dictionary<FilterPool.eFilter, MonoBehaviour>.Enumerator e = CameraController.instance.DicFilter.GetEnumerator())
        {
            while(e.MoveNext())
            {
                KeyValuePair<FilterPool.eFilter, MonoBehaviour> pair = e.Current;
                pair.Value.enabled = false;
            }
        }
    }
}
