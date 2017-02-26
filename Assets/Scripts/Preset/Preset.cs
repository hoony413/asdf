using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Preset : MonoBehaviour
{
    public enum ePreset
    {
        Bloom,
        Blur,
        ColorCorrectionsCurve,
        ConstrastEnhance,
        CreaseShading,
        DefaultPreset,
        DepthOfField,
        EdgeDetection,
        Fisheye,
        GrayScale,
        SepiaTone,
        TiltShift,
        ToneMapping,
        VignetteAndChromaticAberration,
        MAX
    }

    [HideInInspector]
    public static ePreset currentIndex = ePreset.DefaultPreset;

    public virtual void SetData(ePreset presetIndex)
    {
        currentIndex = presetIndex;
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
