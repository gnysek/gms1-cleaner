using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudioCleaner.GMXFormat
{
	class GMXEnums
	{
	}

	enum EventTypes {
		Create,
		Destroy,
		Alarm,
		Step,
		Collision,
		Keyboard,
		Mouse,
		Other,
		Draw,
		KeyPress,
		KeyRelease,
		Async,
	}

	public enum BoundingBoxTypes
	{
		Automatic,
		Full,
		Manual
	}

	public enum CollisionMaskShapes
	{
		Precise,
		Rectangle,
		Disk,
		Diamond
	}

	public enum NodeTypes
	{
		Invalid = 0,
		Root,
		Group,
		Child
	}

	public enum NodeGroup
	{
		Invalid = 0,
		Objects,
		Sprites,
		Sounds,
		Rooms,
		Backgrounds = 6,
		Scripts,
		Paths,
		Fonts,
		TimeLines,
		Includes,
		Configs
	}
}
