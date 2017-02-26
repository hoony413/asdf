using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

/// <summary>
/// 대상과의 거리에 따라 초점 흐릿하게 보이는 효과
/// </summary>
public class _DepthOfField : Preset
{
    public override void SetData(ePreset presetIndex)
    {
        base.SetData(presetIndex);
        CameraController.instance.DicFilter[FilterPool.eFilter.DepthOfField].enabled = true;
        Debug.Log("DepthOfField Changed!");
    }

    public override void BackupDefaultData()
    {
        // TODO: 변수 셋팅.
        DepthOfField depth = CameraController.instance.DicFilter[FilterPool.eFilter.DepthOfField] as DepthOfField;
        if (depth != null)
        {
            Debug.Log("DepthOfField Backup!");
        }
    }
}
