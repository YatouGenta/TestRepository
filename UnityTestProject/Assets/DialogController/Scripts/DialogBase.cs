using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ダイアログ基底クラス
/// </summary>
public class DialogBase : MonoBehaviour
{
    [System.NonSerialized]
    public bool showDialiogWaitFlg = false;

    /// <summary>
    /// ダイアログ表示
    /// </summary>
    /// <param name="data">設定データ</param>
    public virtual IEnumerator Show(DialogData data)
    {
        showDialiogWaitFlg = true;

        //初期化処理
        yield return DialogInitialize(data);

        //閉じる待ち
        while (showDialiogWaitFlg)
        {
            yield return null;
        }

        //終了処理
        yield return DialogFinalize(data);
    }

    //ダイアログ初期化処理
    public virtual IEnumerator DialogInitialize(DialogData data = null) { yield return null; }
    //ダイアログ終了処理
    public virtual IEnumerator DialogFinalize(DialogData data = null) { yield return null; }
}

/// <summary>
/// ダイアログ設定データ基底クラス
/// </summary>
public class DialogData{}

