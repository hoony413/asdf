using UnityEngine;
using System.Collections;

public class _GrayScale : Preset
{
    public override void SetData(ePreset presetIndex)
    {
        base.SetData(presetIndex);
        CameraController.instance.DicFilter[FilterPool.eFilter.Grayscale].enabled = true;
        Debug.Log("Gray Changed!");
    }

    public override void BackupDefaultData()
    {
        // TODO: 변수 셋팅.
        Debug.Log("Gray Backup!");
    }
}
