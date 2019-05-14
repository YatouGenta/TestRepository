using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GatyaMasterData : ScriptableObject
{	
	public List<Sheet> sheets = new List<Sheet> ();

	[System.SerializableAttribute]
	public class Sheet
	{
		public string name = string.Empty;
		public List<Param> list = new List<Param>();
	}

	[System.SerializableAttribute]
	public class Param
	{
		
		public int index;
		public string itemName;
		public int Rarity;
		public float probability;
	}
    /// <summary>
    /// IDを指定してガチャデータを取得
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public GatyaMasterData.Param GetGatyaMasterParam(int index)
    {
        foreach(Param p in sheets[0].list)
        {
            if(p.index == index)
            {
                return p;
            }
        }
        return null;
    }
}

