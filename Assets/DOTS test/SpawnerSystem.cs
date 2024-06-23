using Unity.Entities;
using Unity.Transforms;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;

public partial struct SpawnerSystem : ISystem
{
	public void OnCreate(ref SystemState state)
		=> state.RequireForUpdate<Spawner>();

	public void OnDestroy(ref SystemState state) { }

	public void OnUpdate(ref SystemState state)
	{
		var config = SystemAPI.GetSingleton<Spawner>();

		// Prefab�̃C���X�^���X��
		var instances = state.EntityManager.Instantiate(
			config.Prefab, config.SpawnCount, Allocator.Temp);

		var rand = new Random(config.RandomSeed);

		foreach (var entity in instances)
		{
			// �e�R���|�[�l���g�ւ̃A�N�Z�T�𓾂�
			var xform = SystemAPI.GetComponentRW<LocalTransform>(entity);

			xform.ValueRW = LocalTransform.FromPositionRotation
				(rand.NextFloat3() * config.SpawnRadius, rand.NextQuaternionRotation());
		}

		state.Enabled = false;
	}
}