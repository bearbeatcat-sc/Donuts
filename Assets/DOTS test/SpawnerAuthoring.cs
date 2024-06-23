using Unity.Entities;
using UnityEngine;

/// <summary>
/// ゲームオブジェクトをEntityに変換する
/// </summary>
public class SpawnerAuthoring : MonoBehaviour
{
	public GameObject prefab = null;
	public float spwanRate = 0.0f;
	public int spwanCount = 10;
	public uint RandomSeed = 100;
}

public class SpawnerBaker : Baker<SpawnerAuthoring>
{
	public override void Bake(SpawnerAuthoring authoring)
	{
		var data = new Spawner()
		{
			Prefab = GetEntity(authoring.prefab, TransformUsageFlags.Dynamic),
			SpawnRadius = authoring.spwanRate,
			SpawnCount = authoring.spwanCount,
			RandomSeed = authoring.RandomSeed
		};

		AddComponent(GetEntity(TransformUsageFlags.None), data);
	}
}