using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace StudioCleaner.GMXFormat
{
	abstract public class GMXResource
	{
		public string filename;
		public abstract void ReadFrom();
		public abstract void WriteTo();
	}

	abstract public class GMXResourceIndexed : GMXResource
	{
		public int ID;
		public string Name;
	}

	public class GMXResourceCollection<TResource> : GMXResource, IList<TResource>, ICollection
	where TResource : GMXResource, new()
	{
		protected List<TResource> r_items = new List<TResource>();

		public TResource this[int i]
		{
			get { return r_items[i]; }
			set { r_items[i] = value; }
		}

		public GMXResourceCollection()
		{
			r_items = new List<TResource>();
		}

		public void CopyTo(Array array, int index)
		{
			throw new NotImplementedException();
		}

		public int Count
		{
			get { throw new NotImplementedException(); }
		}

		public bool IsSynchronized
		{
			get { throw new NotImplementedException(); }
		}

		public object SyncRoot
		{
			get { throw new NotImplementedException(); }
		}

		public IEnumerator GetEnumerator()
		{
			throw new NotImplementedException();
		}

		public int IndexOf(TResource item)
		{
			throw new NotImplementedException();
		}

		public void Insert(int index, TResource item)
		{
			throw new NotImplementedException();
		}

		public void RemoveAt(int index)
		{
			throw new NotImplementedException();
		}

		public void Add(TResource item)
		{
			throw new NotImplementedException();
		}

		public void Clear()
		{
			throw new NotImplementedException();
		}

		public bool Contains(TResource item)
		{
			throw new NotImplementedException();
		}

		public void CopyTo(TResource[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		public bool IsReadOnly
		{
			get { throw new NotImplementedException(); }
		}

		public bool Remove(TResource item)
		{
			throw new NotImplementedException();
		}

		IEnumerator<TResource> IEnumerable<TResource>.GetEnumerator()
		{
			return r_items.GetEnumerator();
		}

		public override void ReadFrom()
		{
			throw new NotImplementedException();
		}

		public override void WriteTo()
		{
			throw new NotImplementedException();
		}
	}

	public class GMXResourceIndexedCollection<TIndexedResource> : GMXResourceCollection<TIndexedResource>
	where TIndexedResource : GMXResourceIndexed, new()
	{
		public override void ReadFrom()
		{
			throw new NotImplementedException();
		}

		public override void WriteTo()
		{
			throw new NotImplementedException();
		}
	}

	public class Sprite : GMXResourceIndexed
	{
		public int OriginX = 0,
				   OriginY = 0;
		public List<Subimage> Subimages { get; protected set; }
		public Sprite()
		{
			Subimages = new List<Subimage>();
		}

		public override void ReadFrom() { }
		public override void WriteTo() { }

		public class Subimage : GMXResource
		{
			public string FileName;

			public override void ReadFrom()
			{
				throw new NotImplementedException();
			}

			public override void WriteTo()
			{
				throw new NotImplementedException();
			}
		}
	}

	public class Sound : GMXResourceIndexed
	{
		public override void ReadFrom() { }
		public override void WriteTo() { }
	}

	public class Background : GMXResourceIndexed
	{
		public override void ReadFrom() { }
		public override void WriteTo() { }
	}

	public class Path : GMXResourceIndexed
	{
		public override void ReadFrom() { }
		public override void WriteTo() { }
	}

	public class Script : GMXResourceIndexed
	{
		public override void ReadFrom() { }
		public override void WriteTo() { }
	}

	public class Font : GMXResourceIndexed
	{
		public override void ReadFrom() { }
		public override void WriteTo() { }
	}

	public class TimeLine : GMXResourceIndexed
	{
		public override void ReadFrom() { }
		public override void WriteTo() { }
	}

	public class Object : GMXResourceIndexed
	{
		public override void ReadFrom() { }
		public override void WriteTo() { }
	}

	public class Room : GMXResourceIndexed
	{
		public override void ReadFrom() { }
		public override void WriteTo() { }
	}

	public class Config : GMXResourceIndexed
	{
		public override void ReadFrom() { }
		public override void WriteTo() { }
	}

	public class IncludedFile : GMXResource
	{
		public override void ReadFrom() { }
		public override void WriteTo() { }
	}

	public class Constant : GMXResource
	{
		public override void ReadFrom() { }
		public override void WriteTo() { }
	}

	public class SpriteCollection : GMXResourceIndexedCollection<Sprite>
	{
	}

	public class SoundCollection : GMXResourceIndexedCollection<Sound>
	{
	}

	public class BackgroundCollection : GMXResourceIndexedCollection<Background>
	{
	}

	public class PathCollection : GMXResourceIndexedCollection<Path>
	{
	}

	public class ScriptCollection : GMXResourceIndexedCollection<Script>
	{
	}

	public class FontCollection : GMXResourceIndexedCollection<Font>
	{
	}

	public class TimeLineCollection : GMXResourceIndexedCollection<TimeLine>
	{
	}

	public class ObjectCollection : GMXResourceIndexedCollection<Object>
	{
	}

	public class RoomCollection : GMXResourceIndexedCollection<Room>
	{
	}

	public class ConfigCollection : GMXResourceIndexedCollection<Config>
	{
	}

	public class IncludedFileCollection : GMXResourceCollection<IncludedFile>
	{
	}

	public class ConstantCollection : GMXResourceCollection<Constant>
	{
	}

	public class ResourceTreeNode : GMXResourceCollection<ResourceTreeNode>
	{
		public int ID;
		public string Name;
		public NodeTypes Type;
		public NodeGroup Group;
	}

	public class ResourceTree : GMXResourceCollection<ResourceTreeNode>
	{
		public ResourceTree()
		{
			r_items = new List<ResourceTreeNode>(DefaultTree);
		}
		public readonly ResourceTreeNode[] DefaultTree = new ResourceTreeNode[] {
			new ResourceTreeNode() { Name = "Sprites", Group = NodeGroup.Sprites, Type = NodeTypes.Root },
			new ResourceTreeNode() { Name = "Sounds", Group = NodeGroup.Sounds, Type = NodeTypes.Root },
			new ResourceTreeNode() { Name = "Backgrounds", Group = NodeGroup.Backgrounds, Type = NodeTypes.Root },
			new ResourceTreeNode() { Name = "Paths", Group = NodeGroup.Paths, Type = NodeTypes.Root },
			new ResourceTreeNode() { Name = "Scripts", Group = NodeGroup.Scripts, Type = NodeTypes.Root },
			new ResourceTreeNode() { Name = "Fonts", Group = NodeGroup.Fonts, Type = NodeTypes.Root },
			new ResourceTreeNode() { Name = "Time Lines", Group = NodeGroup.TimeLines, Type = NodeTypes.Root },
			new ResourceTreeNode() { Name = "Objects", Group = NodeGroup.Objects, Type = NodeTypes.Root },
			new ResourceTreeNode() { Name = "Rooms", Group = NodeGroup.Rooms, Type = NodeTypes.Root },
			new ResourceTreeNode() { Name = "IncludedFiles", Group = NodeGroup.Includes, Type = NodeTypes.Root }
			//,
			//new ResourceTreeNode() { Name = "Game Information", Group = NodeGroup.GameInformation, Type = NodeTypes.Child },
			//new ResourceTreeNode() { Name = "Global Game Settings", Group = NodeGroup.GlobalGameSettings, Type = NodeTypes.Child },
			//new ResourceTreeNode() { Name = "Extension Packages", Group = NodeGroup.ExtensionPackages, Type = NodeTypes.Child }
		};
	}
}
