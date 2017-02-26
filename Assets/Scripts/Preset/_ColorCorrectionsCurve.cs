using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

/// <summary>
/// 색깔을 좀더 생기있게 바꿔줌.
/// </summary>
public class _ColorCorrectionsCurve : Preset
{
    public override void SetData(ePreset presetIndex)
    {
        base.SetData(presetIndex);
        CameraController.instance.DicFilter[FilterPool.eFilter.ColorCorrectionCurves].enabled = true;
        Debug.Log("ColorCorrectionCurves Changed!");
    }

    public override void BackupDefaultData()
    {
        // TODO: 변수 셋팅.
        ColorCorrectionCurves color = CameraController.instance.DicFilter[FilterPool.eFilter.ColorCorrectionCurves] as ColorCorrectionCurves;
        if (color != null)
        {
            Debug.Log("ColorCorrectionCurves Backup!");
        }
    }
}
