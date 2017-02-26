using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class _GrayScale : Preset
{
    const float RampOffset = 0f;

    public override void SetData(ePreset presetIndex)
    {
        base.SetData(presetIndex);
        CameraController.instance.DicFilter[FilterPool.eFilter.Grayscale].enabled = true;
        Debug.Log("Gray Changed!");
    }

    public override void BackupDefaultData()
    {
        // TODO: 변수 셋팅.
        Grayscale gray = CameraController.instance.DicFilter[FilterPool.eFilter.Grayscale] as Grayscale;
        if (gray != null)
        {
            gray.rampOffset = RampOffset;
            Debug.Log("Gray Backup!");
        }
    }
}
