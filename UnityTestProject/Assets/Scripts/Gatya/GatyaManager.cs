using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
/// <summary>
/// ガチャ管理クラス
/// </summary>
public class GatyaManager : MonoBehaviour
{
    //保存データ
    private GatyaUserData userData;

    //ポイント表示用Text
    [SerializeField]
    private Text pointText = null;
    //加算分ポイント数
    [SerializeField]
    private int addPoint = 1000;
    //ガチャを引くためのポイント数
    [SerializeField]
    private int gatyaPoint = 100;

    private void Start()
    {
        //データロード
        if(ClassDataFomater.DataCheack(UnityEngine.Application.persistentDataPath + "/GatyaData"))
        {
            userData = ClassDataFomater.Deserialize<GatyaUserData>(UnityEngine.Application.persistentDataPath + "/GatyaData");
        }
        //なければここで作成
        else
        {
            userData = new GatyaUserData();
        }
        //表示物更新
        pointText.text = userData.point.ToString();
    }

    public void OnClickPointButton()
    {
        //ポイント獲得後セーブ
        userData.point += addPoint;
        pointText.text = userData.point.ToString();
        ClassDataFomater.Seialize<GatyaUserData>(UnityEngine.Application.persistentDataPath + "/GatyaData", userData);
        //ポイント獲得した旨をダイアログで表示
        TwoButtonDialogData data = new TwoButtonDialogData();
        data.title = "ポイントを獲得";
        data.content = addPoint + " ポイントを獲得しました！";
        StartCoroutine(DialogManager.instance.DialogShow(DialogSelector.DialogType.TwoButtonDialog, data));
    }
    public void OnClickGatyaButton()
    {
        if(userData.point < gatyaPoint)
        {
            //ガチャポイントたりない
            TwoButtonDialogData data = new TwoButtonDialogData();
            data.title = "ポイント不足";
            data.content = addPoint + " ポイントが足りません。\nポイントを獲得するボタンを押してポイントを獲得してください。";
            StartCoroutine(DialogManager.instance.DialogShow(DialogSelector.DialogType.TwoButtonDialog, data));

        }
        else
        {
            //ポイントがあったらガチャを引く
            userData.point -= gatyaPoint;
            pointText.text = userData.point.ToString();
            ClassDataFomater.Seialize<GatyaUserData>(UnityEngine.Application.persistentDataPath + "/GatyaData", userData);

            TwoButtonDialogData data = new TwoButtonDialogData();
            data.title = "ガチャを引きました";
            data.content = addPoint + " 処理はまだ作ってないよ";
            StartCoroutine(DialogManager.instance.DialogShow(DialogSelector.DialogType.TwoButtonDialog, data));
        }

    }
}
/// <summary>
/// ガチャ情報保存用クラス
/// </summary>
[Serializable]
public class GatyaUserData
{
    //所持ガチャポイント
    public int point = 1000;
    //UR獲得数
    public int uRCount = 0;
    //SR獲得数
    public int sRCount = 0;
    //R獲得数
    public int rCount = 0;
    //N獲得数
    public int nRCount = 0;

}

