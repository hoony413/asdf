using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

/// <summary>
/// 명도를 좀더 선명하게 해줌.
/// </summary>
public class _ConstrastEnhance : Preset
{
    /// <summary>
    /// 선명도 조절해줌.
    /// </summary>
    const float Intensity = 0.5f;
    /// <summary>
    /// 0에서 낮아질수록 극선명해짐. 0 이상부터는 점점 흐릿해짐.
    /// </summary>
    const float Threshold = 0f;
    /// <summary>
    /// 진한것들 근처에 좀 밝게 해주는 효과. -5 ~ 5까지...
    /// </summary>
    const float BlurSpread = 1f;

    public override void SetData(ePreset presetIndex)
    {
        base.SetData(presetIndex);
        CameraController.instance.DicFilter[FilterPool.eFilter.ContrastEnhance].enabled = true;
        Debug.Log("ContrastEnhance Changed!");
    }

    public override void BackupDefaultData()
    {
        // TODO: 변수 셋팅.
        ContrastEnhance constrast = CameraController.instance.DicFilter[FilterPool.eFilter.ContrastEnhance] as ContrastEnhance;
        if (constrast != null)
        {
            constrast.intensity = Intensity;
            constrast.threshold = Threshold;
            constrast.blurSpread = BlurSpread;
            Debug.Log("ContrastEnhance Backup!");
        }
    }
}
