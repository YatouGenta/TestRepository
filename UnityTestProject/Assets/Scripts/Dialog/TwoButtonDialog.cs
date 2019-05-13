using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// 2ボタン式ダイアログ
/// </summary>
public class TwoButtonDialog : AnimationDiadlogBase
{
    //Yesボタン
    [SerializeField]
    public Button yesButton = null;
    //Noボタン
    [SerializeField]
    public Button noButton = null;

    //タイトルText
    [SerializeField]
    private Text titleText = null;
    //内容Text
    [SerializeField]
    private Text contentText = null;

    public override IEnumerator DialogInitialize(DialogData data = null)
    {
        if(data != null)
        {
            TwoButtonDialogData dData = (TwoButtonDialogData)data;
            //表示物を変更
            titleText.text = dData.title;
            contentText.text = dData.content;

            //ボタンイベント登録
            if(dData.yesAction != null)
            {
                yesButton.onClick.AddListener(dData.yesAction);
            }
            if (dData.noAction != null)
            {

                noButton.onClick.AddListener(dData.noAction);
            }
        }
        return base.DialogInitialize(data);
    }

    public void OnClickClose()
    {
        showDialiogWaitFlg = false;
    }
}

public class TwoButtonDialogData : DialogData
{
    public string title;
    public string content;
    
    public UnityAction yesAction;
    public UnityAction noAction;
}
