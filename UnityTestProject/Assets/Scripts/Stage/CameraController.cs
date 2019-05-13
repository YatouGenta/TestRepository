using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステージカメラの動作クラス
/// </summary>
public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject player = null;

    private Vector3 offset;

    void Start()
    {
        //プレイヤーとカメラ間の距離を取得してそのオフセット値を計算し、格納します。
        offset = transform.position - player.transform.position;
    }

    void Update()
    {
        //カメラの transform 位置をプレイヤーのものと等しく設定します。ただし、計算されたオフセット距離によるずれも加えます。
        transform.position = new Vector3(player.transform.position.x + offset.x, transform.position.y, transform.position.z);
    }
}
