using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudioCleaner.GMXFormat
{
	class GMXFile
	{
		public GMXFile() {
			Sprites = new SpriteCollection();
			Sound = new SoundCollection();
			Backgrounds = new BackgroundCollection();
			Paths = new PathCollection();
			Scripts = new ScriptCollection();
			Fonts = new FontCollection();
			TimeLines = new TimeLineCollection();
			Objects = new ObjectCollection();
			Rooms = new RoomCollection();
			Includes = new IncludedFileCollection();
			Configs = new ConfigCollection();
			ResourceTree = new ResourceTree();
		}

		public void readGMX() {
		}

		public SpriteCollection Sprites { get; private set; }
		public SoundCollection Sound { get; private set; }
		public BackgroundCollection Backgrounds { get; private set; }
		public PathCollection Paths { get; private set; }
		public ScriptCollection Scripts { get; private set; }
		public FontCollection Fonts { get; private set; }
		public TimeLineCollection TimeLines { get; private set; }
		public ObjectCollection Objects{ get; private set; }
		public RoomCollection Rooms { get; private set; }
		public IncludedFileCollection Includes { get; private set; }
		public ConfigCollection Configs { get; private set; }
		public ResourceTree ResourceTree { get; private set; }
	}
}
