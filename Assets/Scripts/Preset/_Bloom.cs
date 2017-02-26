using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

/// <summary>
/// 뽀샤시 효과.
/// </summary>
public class _Bloom : Preset
{
    /// <summary>
    /// 낮을수록 뽀샤시해짐. 최대 1.5 
    /// </summary>
    const float Threshold = 0.25f;
    /// <summary>
    /// 뽀샤시의 밝기가 밝아짐. 높을수록. 최대 2.5
    /// </summary>
    const float Intensity = 0.75f;

    /// <summary>
    /// 뽀샤시 안쪽으로 흐려지는 크기. 높을수록. 최대 5.5
    /// </summary>
    const float BlurSize = 1;
    /// <summary>
    /// 뽀샤시 흐리기를 안쪽으로 퍼지게 해줌. 높을수록. 최대 4
    /// </summary>
    const int BlurIterations = 1;

    public override void SetData(ePreset presetIndex)
    {
        base.SetData(presetIndex);
        CameraController.instance.DicFilter[FilterPool.eFilter.BloomOptimized].enabled = true;
        Debug.Log("BloomOptimized Changed!");
    }

    public override void BackupDefaultData()
    {
        // TODO: 변수 셋팅.
        BloomOptimized bloom = CameraController.instance.DicFilter[FilterPool.eFilter.BloomOptimized] as BloomOptimized;
        if (bloom != null)
        {
            bloom.threshold = Threshold;
            bloom.intensity = Intensity;
            bloom.blurSize = BlurSize;
            bloom.blurIterations = BlurIterations;

            Debug.Log("BloomOptimized Backup!");
        }
    }
}