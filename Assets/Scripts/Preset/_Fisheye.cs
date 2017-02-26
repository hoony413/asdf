using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

/// <summary>
/// 어안렌즈.
/// </summary>
public class _Fisheye : Preset
{
    /// <summary>
    /// x축 왜곡률. 1정도가 적당..
    /// </summary>
    const float strength_x = 0.05f;
    /// <summary>
    /// y축 왜곡률. 1정도가 적당..
    /// </summary>
    const float strength_y = 0.05f;
    public override void SetData(ePreset presetIndex)
    {
        base.SetData(presetIndex);
        CameraController.instance.DicFilter[FilterPool.eFilter.Fisheye].enabled = true;
        Debug.Log("Fisheye Changed!");
    }

    public override void BackupDefaultData()
    {
        // TODO: 변수 셋팅.
        Fisheye fisheye = CameraController.instance.DicFilter[FilterPool.eFilter.Fisheye] as Fisheye;
        if (fisheye != null)
        {
            fisheye.strengthX = strength_x;
            fisheye.strengthY = strength_y;
            Debug.Log("Fisheye Backup!");
        }
    }
}
