using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

/// <summary>
/// 사물의 외곽 잡아주는 기능.
/// </summary>
public class _EdgeDetection : Preset
{
    /// <summary>
    ///  Roberts Cross 뭐시기가 외곽선이 굵음.
    /// </summary>
    const EdgeDetection.EdgeDetectMode Mode = EdgeDetection.EdgeDetectMode.SobelDepthThin;
    /// <summary>
    /// 텍스쳐 색깔 날려버림. 흰색과 검은색만 남음.
    /// </summary>
    const float EdgesOnly = 0f;

    public override void SetData(ePreset presetIndex)
    {
        base.SetData(presetIndex);
        CameraController.instance.DicFilter[FilterPool.eFilter.EdgeDetection].enabled = true;
        Debug.Log("EdgeDetection Changed!");
    }

    public override void BackupDefaultData()
    {
        // TODO: 변수 셋팅.
        EdgeDetection edge = CameraController.instance.DicFilter[FilterPool.eFilter.EdgeDetection] as EdgeDetection;
        if (edge != null)
        {
            edge.mode = Mode;
            edge.edgesOnly = EdgesOnly;
            Debug.Log("EdgeDetection Backup!");
        }
    }
}
