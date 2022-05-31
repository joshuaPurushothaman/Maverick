namespace Maverick.ECS
{
	class Manager
	{
		int currentEntityID = 0;
		int currentComponentID = 0;
		readonly List<IComponentList> componentLists = new();
		readonly Dictionary<Type, IComponentList> componentListsByType = new();
		public readonly List<Entity> entities = new();	//	public for queries

		private static readonly Lazy<Manager> singleton = new();
		public static Manager Instance { get { return singleton.Value; } }

		public int GetNextEntityID()
		{
			currentEntityID++;
			return currentEntityID;
		}
		public void AddEntity(Entity entity)
		{
			entities.Add(entity);
		}

		public int GetComponentID<T>() where T : struct
		{
			if (!componentListsByType.ContainsKey(typeof(T)))
			{
				var componentList = new ComponentList<T>();
				componentLists.Add(componentList);
				componentListsByType.Add(typeof(T), componentList);
				currentComponentID++;

				return currentComponentID;
			}
			
			return componentListsByType.Keys.ToList().IndexOf(typeof(T));
		}

		public Manager AddComponent<T>(int entityID, T component) where T : struct
		{
			if (componentListsByType.TryGetValue(typeof(T), out var componentList))
			{
				componentList.Add(entityID, component);
			}
			else
			{
				componentList = new ComponentList<T>();
				componentLists.Add(componentList);
				componentListsByType.Add(typeof(T), componentList);
				componentList.Add(entityID, component);
			}
			
			return this;
		}

		public ref T GetComponent<T>(int entityID) where T : struct
		{
			if (componentListsByType.TryGetValue(typeof(T), out var componentList))
			{
				return ref componentList.Get<T>(entityID);
			}
			else
			{
				throw new Exception($"Entity {entityID} does not have component {typeof(T)}");
			}
		}

		public void SetComponent<T>(int entityID, T value) where T : struct
		{
			if (TrySetComponent(entityID, value))
				return;
			else
				throw new Exception($"Entity {entityID} does not have component {typeof(T)}");
		}

		public bool TrySetComponent<T>(int entityID, T value) where T : struct
		{
			if (componentListsByType.TryGetValue(typeof(T), out var componentList))
			{
				return componentList.TrySet(entityID, value);
			}
			return false;
		}

		//	TODO: implement entity deleting and component removing
	}

}
