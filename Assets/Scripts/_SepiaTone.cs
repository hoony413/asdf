using UnityEngine;
using System.Collections;

public class _SepiaTone : Preset
{
    public override void SetData(ePreset presetIndex)
    {
        base.SetData(presetIndex);
        CameraController.instance.DicFilter[FilterPool.eFilter.SepiaTone].enabled = true;
        Debug.Log("Sepia Changed!");
    }

    public override void BackupDefaultData()
    {
        Debug.Log("Sepia Backup!");
    }
}
