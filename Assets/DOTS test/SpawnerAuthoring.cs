﻿using Unity.Entities;
using UnityEngine;

/// <summary>
/// ゲームオブジェクトをEntityに変換する
/// </summary>
public class SpawnerAuthoring : MonoBehaviour
{
	public GameObject prefab = null;
	public float spwanRate = 0.0f;
}

public class SpawnerBaker : Baker<SpawnerAuthoring>
{
	public override void Bake(SpawnerAuthoring authoring)
	{
		var entity = GetEntity(TransformUsageFlags.None);
		AddComponent(entity, new Spawner
		{
			Prefab = GetEntity(authoring.prefab, TransformUsageFlags.Dynamic),
			SpawnPosition = authoring.transform.position,
			NextSpawnTime = 0.0f,
			SpawnInterval = authoring.spwanRate
		});
	}
}