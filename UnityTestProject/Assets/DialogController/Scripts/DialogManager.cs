using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ダイアログ表示非表示を管理するクラス
/// </summary>
public class DialogManager : MonoBehaviour
{
    //シングルトン処理
    public static DialogManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    //ダイアログ表示しているときの背景オブジェクト
    [SerializeField]
    public GameObject backgroundObject = null;
    //ダイアログ生成箇所オブジェクト
    [SerializeField]
    private GameObject contentArea = null;
    //ダイアログ生成リスト
    private List<DialogBase> showDialogList = new List<DialogBase>();

    private DialogSelector dialogSelector;



    private void Start()
    {
        backgroundObject.SetActive(false);
        dialogSelector = new DialogSelector();
    }

    /// <summary>
    /// ダイアログを表示する
    /// </summary>
    public IEnumerator DialogShow(DialogSelector.DialogType type, DialogData data = null)
    {
        DialogBase dialog = dialogSelector.GetDialog(type);
        Debug.Log("ダイアログ = " + dialog);
        if (dialog != null)
        {

            //ダイアログがひとつも表示されていなければ背景を表示する
            if (showDialogList.Count == 0)
            {
                backgroundObject.SetActive(true);
            }

            //対象ダイアログを生成
            DialogBase targetDialog = DialogBase.Instantiate<DialogBase>(dialog);
            targetDialog.transform.SetParent(contentArea.transform, false);
            showDialogList.Add(targetDialog);
            //ダイアログ表示開始
            yield return targetDialog.Show(data);

            //表示が終わったらダイアログを破棄
            showDialogList.Remove(targetDialog);
            Destroy(targetDialog.gameObject);
            if (showDialogList.Count == 0)
            {
                backgroundObject.SetActive(false);
            }
        }
    }
}
