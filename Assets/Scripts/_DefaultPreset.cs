using UnityEngine;
using System.Collections;

public class _DefaultPreset : Preset
{
    public override void SetData(ePreset presetIndex)
    {
        base.SetData(presetIndex);
        Debug.Log("Default Changed!");
    }

    public override void BackupDefaultData()
    {
        // TODO: 변수 셋팅.
        Debug.Log("Default Backup!");
    }
}
