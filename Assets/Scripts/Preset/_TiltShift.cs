using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

/// <summary>
/// 위아래로 약간 초점 흐리게 해주는 효과.
/// </summary>
public class _TiltShift: Preset
{
    /// <summary>
    /// 모드 설정. 틸트쉬프트는 가운데를 또렷하게. 아이리스는 위아래를 또렷하게.
    /// </summary>
    const TiltShift.TiltShiftMode Mode = TiltShift.TiltShiftMode.TiltShiftMode;
    /// <summary>
    /// 퀄리티 설정. 노말만 쓰자.
    /// </summary>
    const TiltShift.TiltShiftQuality Quality = TiltShift.TiltShiftQuality.Normal;
    /// <summary>
    /// 흐려짐의 세기. 1 ~ 15
    /// </summary>
    const float BlurArea = 1f;
    /// <summary>
    /// 흐려짐의 방향 세기. 1 ~ 25
    /// </summary>
    const float MaxBlurSize = 5f;
    /// <summary>
    /// 잘 모르겠음. 0 ~ 1
    /// </summary>
    const int DownSample = 0;

    public override void SetData(ePreset presetIndex)
    {
        base.SetData(presetIndex);
        CameraController.instance.DicFilter[FilterPool.eFilter.TiltShift].enabled = true;
        Debug.Log("TiltShift Changed!");
    }

    public override void BackupDefaultData()
    {
        // TODO: 변수 셋팅.
        TiltShift tilt = CameraController.instance.DicFilter[FilterPool.eFilter.TiltShift] as TiltShift;
        if (tilt != null)
        {
            tilt.mode = Mode;
            tilt.quality = Quality;
            tilt.blurArea = BlurArea;
            tilt.maxBlurSize = MaxBlurSize;
            tilt.downsample = DownSample;
            Debug.Log("TiltShift Backup!");
        }
    }
}
