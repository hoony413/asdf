using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

/// <summary>
/// 외곽선 컨트롤.
/// </summary>
public class _CreaseShading : Preset
{
    /// <summary>
    /// 외곽선. 높을수록 검은색 외곽선. 낮을 수록 흰색 외곽선. 0에서 멀어질수록 외곽선이 굵어짐.
    /// </summary>
    const float Intensity = 0.5f;
    /// <summary>
    /// 외곽선의 부드러운 정도.
    /// </summary>
    const int Softness = 1;
    /// <summary>
    /// 외곽선의 퍼짐 정도.
    /// </summary>
    const float Spread = 1f;

    public override void SetData(ePreset presetIndex)
    {
        base.SetData(presetIndex);
        CameraController.instance.DicFilter[FilterPool.eFilter.CreaseShading].enabled = true;
        Debug.Log("CreaseShading Changed!");
    }

    public override void BackupDefaultData()
    {
        // TODO: 변수 셋팅.
        CreaseShading crease = CameraController.instance.DicFilter[FilterPool.eFilter.CreaseShading] as CreaseShading;
        if (crease != null)
        {
            crease.intensity = Intensity;
            crease.softness = Softness;
            crease.spread = Spread;
            Debug.Log("CreaseShading Backup!");
        }
    }
}
