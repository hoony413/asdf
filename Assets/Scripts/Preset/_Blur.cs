using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

/// <summary>
/// 흐리기 효과.
/// </summary>
public class _Blur : Preset
{
    /// <summary>
    /// 흐리기의 세기. 0 ~ 2
    /// </summary>
    const int Downsample = 1;
    /// <summary>
    /// 흐리기의 세기2. 높으면 모자이크처럼 됨. 0 ~ 10
    /// </summary>
    const float BlurSize = 3;
    /// <summary>
    /// 흐리기의 세기3. 
    /// </summary>
    const int BlurIterations = 2;

    public override void SetData(ePreset presetIndex)
    {
        base.SetData(presetIndex);
        CameraController.instance.DicFilter[FilterPool.eFilter.BlurOptimized].enabled = true;
        Debug.Log("BlurOptimized Changed!");
    }

    public override void BackupDefaultData()
    {
        // TODO: 변수 셋팅.
        BlurOptimized blur = CameraController.instance.DicFilter[FilterPool.eFilter.BlurOptimized] as BlurOptimized;
        if (blur != null)
        {
            blur.downsample = Downsample;
            blur.blurSize = BlurSize;
            blur.blurIterations = BlurIterations;

            Debug.Log("BlurOptimized Backup!");
        }
    }
}