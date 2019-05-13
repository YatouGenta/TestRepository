using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ダイアログプレハブを取得するクラス
/// </summary>
public class DialogSelector
{
    //ダイアログの種類
    //Resoucesのプレハブと同じ名前にする
    public enum DialogType
    {
        TwoButtonDialog,
    }
    /// <summary>
    /// ダイアログの種類を指定しResoucesから対象のプレハブを返す
    /// </summary>
    public DialogBase GetDialog(DialogType type)
    {
        Debug.Log("Dialog/" + type.ToString());
        GameObject dialog = (GameObject)Resources.Load("Dialog/" + type.ToString());
        return dialog.GetComponent<DialogBase>();
    }

}
