using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

/// <summary>
/// クラスをシリアライズ化しバイナリー化してデータを保存する
/// </summary>
public class ClassDataFomater
{
    /// <summary>
    /// クラスをバイナリーにして対象パスへ保存する
    /// </summary>
    /// <typeparam name="T">対象のクラス種類</typeparam>
    /// <param name="path">保存パス</param>
    /// <param name="obj">対象のクラスオブジェクト</param>
    public static void Seialize<T>(string path, T obj)
    {
        using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, obj);
        }
    }

    /// <summary>
    /// バイナリーにしたデータを復元する
    /// </summary>
    /// <typeparam name="T">対象のクラス</typeparam>
    /// <param name="path">保存パス</param>
    /// <returns></returns>
    public static T Deserialize<T>(string path)
    {
        T obj;
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            BinaryFormatter f = new BinaryFormatter();
            obj = (T)f.Deserialize(fs);
        }
        return obj;
    }

    /// <summary>
    /// 指定パスにデータが存在するかどうかをチェックする
    /// </summary>
    /// <typeparam name="T">対象のクラス</typeparam>
    /// <param name="path">保存パス</param>
    /// <returns></returns>
    public static bool DataCheack(string path)
    {
        return System.IO.File.Exists(path);
    }

}

