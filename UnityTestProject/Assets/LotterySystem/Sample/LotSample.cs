using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 抽選サンプルデータ
/// </summary>
public class LotSample : MonoBehaviour
{
    //抽選設定データ
    [SerializeField]
    private List<LotData> lotDataList = new List<LotData>();
    //画面表示用のテキスト
    [SerializeField]
    private Text dispText = null;

    private int lotCount = 0;

    //一点狙いが果たして何回ででるか
    public void OnClickLotDemoButton(int selectIndex)
    {
        int tempCount = 0;
        int lotIndex = -1;
        while (selectIndex != lotIndex)
        {
            tempCount++;
            List<float> lotFloatProbabilityList = new List<float>();
            for (int i = 0; i < lotDataList.Count; i++)
            {
                lotFloatProbabilityList.Add(lotDataList[i].probability);
            }

            int index = LotterySystem.Lottery(lotFloatProbabilityList);

            if (index == -1)
            {
                //不正値
                dispText.text = "うまく抽選できませんでした。\n設定を再度確認の上もう一度試してください";
                break;
            }
            lotIndex = index;
        }
        //抽選結果を元にテキスト変えとく
        dispText.text = tempCount + "回目の抽選で\n" + "確率" + lotDataList[selectIndex].probability + "%の\n<size=80>" + lotDataList[selectIndex].lotName + "</size>\nがでました！";

    }

    //抽選ボタン
    public void OnClickLotButton()
    {
        lotCount++;
        List<float> lotFloatProbabilityList = new List<float>();
        for(int i = 0; i < lotDataList.Count; i++)
        {
            lotFloatProbabilityList.Add(lotDataList[i].probability);
        }

        int index = LotterySystem.Lottery(lotFloatProbabilityList);

        if(index == -1)
        {
            //不正値
            dispText.text = "うまく抽選できませんでした。\n設定を再度確認の上もう一度試してください";
        }
        else
        {
            //抽選結果を元にテキスト変えとく
            dispText.text = lotCount + "回目の抽選\n" + "確率" + lotDataList[index].probability + "%の\n<size=80>" + lotDataList[index].lotName + "</size>\nがでました！";
        }
    }
}

[System.Serializable]
public class LotData
{
    //名前表示用
    public string lotName;
    //確率
    public float probability;

}