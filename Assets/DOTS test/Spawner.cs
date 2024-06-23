using Unity.Entities;
using Unity.Mathematics;

/// <summary>
/// ¶¬ƒNƒ‰ƒX
/// </summary>
public struct Spawner : IComponentData
{
	public Entity Prefab;
	public float SpawnRadius;
	public int SpawnCount;
	public uint RandomSeed;
}
