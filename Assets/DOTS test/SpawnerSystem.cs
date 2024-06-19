using Unity.Entities;
using Unity.Transforms;
using Unity.Burst;

[BurstCompile]
public partial struct SpawnerSystem : ISystem
{
	public void OnCreate(ref SystemState state) { }
	public void OnDestroy(ref SystemState state) { }

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		foreach(RefRW<Spawner> spawner in SystemAPI.Query<RefRW<Spawner>>())
		{
			ProcessSpawner(ref state, spawner);
		}
	}

	private void ProcessSpawner(ref SystemState state, RefRW<Spawner> spawner)
	{
		// スポーン時間の値を確認する
		if (spawner.ValueRO.NextSpawnTime < SystemAPI.Time.ElapsedTime)
		{
			// スポナーの持つプレファブから、エンティティを生成する
			Entity newEntity = state.EntityManager.Instantiate(spawner.ValueRO.Prefab);

			state.EntityManager.SetComponentData(newEntity, LocalTransform.FromPosition(spawner.ValueRO.SpawnPosition));

			spawner.ValueRW.NextSpawnTime = (float)SystemAPI.Time.ElapsedTime + spawner.ValueRO.SpawnInterval;
		}
	}
}