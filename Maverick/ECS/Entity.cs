using System.Collections.Specialized;

namespace Maverick.ECS
{
	public class Entity
	{
		public readonly int id;
		BitVector32 components = new(); //	TODO: use a bit array because only 32 components are allowed now

		public Entity()
		{
			id = Manager.Instance.GetNextEntityID();
			Manager.Instance.AddEntity(this);
		}

		public Entity AddComponent<T>(T component) where T : struct
		{
			if (TryAddComponent(component) == false)
				throw new Exception($"Entity already has component of type {typeof(T)}");

			//	If it was true, then the call would have succeeded, so return this for method chaining
			return this;
		}

		public bool TryAddComponent<T>(T component) where T : struct
		{
			if (HasComponent<T>())
				return false;

			Manager.Instance.AddComponent(id, component);

			components[Manager.Instance.GetComponentID<T>()] = true;

			return true;
		}

		public bool HasComponent<T>() where T : struct =>
			components[Manager.Instance.GetComponentID<T>()];	//	TODO: maybe a quick multiple component check using HiBitSet

		public ref T GetComponent<T>() where T : struct
		{
			if (HasComponent<T>())
				return ref Manager.Instance.GetComponent<T>(id);
			else
				throw new Exception($"Entity does not have component of type {typeof(T)}");
		}

		public void SetComponent<T>(T component) where T : struct
		{
			if (TrySetComponent(component) == false)
				throw new Exception($"Entity does not have component of type {typeof(T)}");
		}

		public bool TrySetComponent<T>(T component) where T : struct
		{
			if (HasComponent<T>() == false)
				return false;

			Manager.Instance.SetComponent(id, component);
			return true;
		}

		//public readonly int id;
		//readonly BitArray components = new(256);

		//public Entity()
		//{
		//	id = Manager.Instance.GetNextEntityID();
		//}

		//public Entity AddComponent<T>(T component) where T : struct
		//{
		//	if (TryAddComponent(component) == false)
		//		throw new Exception($"Entity already has component of type {typeof(T)}");

		//	//	If it was true, then the call would have succeeded, so return this for method chaining
		//	return this;
		//}

		//public bool TryAddComponent<T>(T component) where T : struct
		//{
		//	if (HasComponent<T>())
		//		return false;

		//	Manager.Instance.AddComponent(id, component);

		//	components.Length++;
		//	components[Manager.Instance.GetComponentID<T>()] = true;

		//	return true;
		//}

		//public bool HasComponent<T>() where T : struct =>
		//	components[Manager.Instance.GetComponentID<T>()];
	}
}
