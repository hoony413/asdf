using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

/// <summary>
/// 전반적인 톤조절
/// </summary>
public class _ToneMapping : Preset
{
    /// <summary>
    /// 타입 설정. 타입별로 약간씩 차이 있음. 전반적으로 사진이 좀 어두워짐.
    /// </summary>
    const Tonemapping.TonemapperType Type = Tonemapping.TonemapperType.Photographic;
    /// <summary>
    /// 적용할 텍스쳐 사이즈
    /// </summary>
    const Tonemapping.AdaptiveTexSize Size = Tonemapping.AdaptiveTexSize.Square256;
    /// <summary>
    /// 노출 정도. 높을수록 밝아짐.
    /// </summary>
    const float Exposure = 1.5f;
    /// <summary>
    /// 미들그레이... 잘 모르겠음.
    /// </summary>
    const float MiddelGray = 0.4f;
    /// <summary>
    /// 화이트... 잘 모르겠음.
    /// </summary>
    const float White = 2f;
    /// <summary>
    /// 적용 속도??
    /// </summary>
    const float AdaptionSpeed = 1.5f;

    public override void SetData(ePreset presetIndex)
    {
        base.SetData(presetIndex);
        CameraController.instance.DicFilter[FilterPool.eFilter.Tonemapping].enabled = true;
        Debug.Log("Tonemapping Changed!");
    }

    public override void BackupDefaultData()
    {
        // TODO: 변수 셋팅.
        Tonemapping tone = CameraController.instance.DicFilter[FilterPool.eFilter.Tonemapping] as Tonemapping;
        if (tone != null)
        {
            tone.type = Type;
            tone.adaptiveTextureSize = Size;
            tone.exposureAdjustment = Exposure;
            tone.middleGrey = MiddelGray;
            tone.white = White;
            tone.adaptionSpeed = AdaptionSpeed;
            Debug.Log("Tonemapping Backup!");
        }
    }
}
