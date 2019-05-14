using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 抽選機能クラス
/// </summary>
public class LotterySystem
{
    /// <summary>
    /// 抽選
    /// </summary>
    /// <param name="lotCandidateList">確率リスト、必ずしも合計が100ではなくても抽選は可能</param>
    /// <returns></returns>
    public static int Lottery(List<float> lotCandidateList)
    {
        //List何も入ってない場合は不正値
        if(lotCandidateList.Count == 0)
        {
            return -1;
        }
        //そもそも一個だけしか入ってなかったらもはやそれを返してあげればよさそう
        else if(lotCandidateList.Count == 1)
        {
            return 0;
        }


        float tempGCD = -1;

        //渡された数値全てを対象に最大公約数を計算
        for(int i = 0; i < lotCandidateList.Count - 1; i++)
        {
            if (tempGCD == -1)
            {
                tempGCD = lotCandidateList[i];
            }
            //0が返ってきたらこれ以上割り切れないので失敗として-1を返す
            else if(tempGCD == 0)
            {
                return -1;
            }
            tempGCD = GetGCD(tempGCD, lotCandidateList[i + 1]);
        }
        //候補の中で小数があれば全て整数化
        int magnification = 1;
        for (int i = 0; i < lotCandidateList.Count; i++)
        {
            float tempLot = lotCandidateList[i] * magnification;
            while(tempLot - (int)tempLot != 0)
            {
                tempLot *= 10;
                magnification *= 10;
            }
        }
        for (int i = 0; i < lotCandidateList.Count; i++)
        {
            lotCandidateList[i] *= magnification;
        }

        //全ての最大公約数で候補全て割り抽選インデックスリストを作成
        List<int> lotIndexList = new List<int>();
        for (int i = 0; i < lotCandidateList.Count; i++)
        {
            int count = (int)lotCandidateList[i] / (int)tempGCD;
            for(int j = 0; j < count; j++)
            {
                lotIndexList.Add(i);
            }
        }

        //インデックスリストのカウント数からランダムで数値を取得しインデックスを返す
        return lotIndexList[UnityEngine.Random.Range(0, lotIndexList.Count)];
    }

    /// <summary>
    /// 最大公約数を計算する
    /// </summary>
    /// <param name="a">数値１</param>
    /// <param name="b">数値２</param>
    private static int GetGCD(float a, float b)
    {
        //aもしくはbが０の場合は割り切れないので０を返す
        if(a < 0 || b < 0)
        {
            return 0;
        }

        int aInt = (int)a;
        int bInt = (int)b;

        //aもしくはbが小数であれば整数になるまで直す
        while (a % aInt != 0 || b % bInt != 0)
        {
            if (a - aInt != 0 || b - bInt != 0)
            {
                a *= 10;
                b *= 10;
            }
            aInt = (int)a;
            bInt = (int)b;
        }

        //bがaより大きい場合にはaとbを入れ替え
        if (bInt > aInt)
        {
            int x;
            x = aInt;
            aInt = bInt;
            bInt = x;
        }

        while (true)
        {
            int r = aInt % bInt;

            // 割り切れたら終了
            if (r == 0)
            {
                return bInt;
            }
            else
            {
                // 割る数に使っていた数を割られる数に設定
                aInt = bInt;

                // 余りを割る数に設定
                bInt = r;
            }
        }
    }

}

