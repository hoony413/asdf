using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

/// <summary>
/// 화면 외곽에 둥근 액자. 색상 왜곡. 중앙 초점 맞추기 효과 등.
/// </summary>
public class _VignetteAndChromaticAberration : Preset
{
    /// <summary>
    /// 모드 설정. 심플, 어드밴스드.
    /// </summary>
    const VignetteAndChromaticAberration.AberrationMode Mode = VignetteAndChromaticAberration.AberrationMode.Simple;
    /// <summary>
    /// 둥근 액자 효과. 커질수록!
    /// </summary>
    const float Intensity = 0.375f;
    /// <summary>
    /// 색깔 왜곡. 켜질수록!
    /// </summary>
    const float ChromaticAberration = 0.2f;
    /// <summary>
    /// 모르겠음.
    /// </summary>
    const float AxialAberration = 0.2f;
    /// <summary>
    /// 중앙에서 멀어질수록 흐려지는 크기. 높을수록!
    /// </summary>
    const float Blur = 0f;
    /// <summary>
    /// 흐려지는 세기. 세면 모자이크가 되어버림.
    /// </summary>
    const float BlurSpread = 0.75f;
    /// <summary>
    /// 라이팅 밝기에 따른 효과?? 변화없음
    /// </summary>
    const float LuminanceDependes = 0.25f;
    /// <summary>
    /// 흐려짐 적용 거리 설정?? 변화없음
    /// </summary>
    const float BlurDistance = 2.5f;

    public override void SetData(ePreset presetIndex)
    {
        base.SetData(presetIndex);
        CameraController.instance.DicFilter[FilterPool.eFilter.VignetteAndChromaticAberration].enabled = true;
        Debug.Log("VignetteAndChromaticAberration Changed!");
    }

    public override void BackupDefaultData()
    {
        // TODO: 변수 셋팅.
        VignetteAndChromaticAberration vign = CameraController.instance.DicFilter[FilterPool.eFilter.VignetteAndChromaticAberration] as VignetteAndChromaticAberration;
        if (vign != null)
        {
            vign.mode = Mode;
            vign.intensity = Intensity;
            vign.chromaticAberration = ChromaticAberration;
            vign.axialAberration = AxialAberration;
            vign.blur = Blur;
            vign.blurSpread = BlurSpread;
            vign.luminanceDependency = LuminanceDependes;
            vign.blurDistance = BlurDistance;
            Debug.Log("VignetteAndChromaticAberration Backup!");
        }
    }
}
