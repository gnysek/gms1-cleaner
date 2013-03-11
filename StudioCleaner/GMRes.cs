using System;
using System.Drawing;

namespace StudioCleaner
{
	public class GMRes
	{
		string name;
		string path;

		enum GMNode {
			group=1, sprite, sound, background, font, path, timeline, script, obj, room
		}

		public GMRes ()
		{

		}
	}

	public class GMSprite : GMRes {
		int xorig = 0;
		int yorig = 0;
		int colking = 0;
		int coltolerance = 0;
		int sepmasks = -1;
		int bboxmode = 0;
		int bbox_left = 0;
		int bbox_right = 0;
		int bbox_top = 0;
		int bbot_bottom = 0;
		int htile = 0;
		int vtile = 0;
		int texturegroup = 0;
		bool for3d = false;
		string[] frames = {};
	}

	public class GMObject : GMRes {
		string spriteName;
		bool solid;
		bool visible;
		int depth;
		bool persistent;
		string parentName;
		string maskName;
		string[] events;
		bool phyObject = false;
		bool phySensor = false;
		int phyShape = 0;
		int phyDensity = 0;
		int phyRestitution = 0;
		int phytGroup = 0;
		int phyLinearDumping = 0;
		int phyAngularDumping = 0;
		Point[] phyShapePoints;
	}

	public class GMScript : GMRes {
		string code;
	}

	public class GMRoom : GMRes {
		string caption;
		int width = 800;
		int height = 600;
		int vsnap = 32;
		int hsnap = 32;
		bool isisometric = false;
		int speed = 30;
		bool persistent = false;
		int colour;
		bool showcolour = false;
		string code = null;
		bool enableviews = false;
		bool clearViewBackground = false;
		int[] markerSetings;
		GMRoomBackgrounds[] backgrounds;
		GMRoomViews[] views;
		GMRoomIntances[] instances;
		bool phyWorld = false;
		int phyWTop, phyWLeft, phyWRight, phyWBottom, phyWGravX, phyWGravY, phyWPixToMeters = 0;
	}

	public class GMRoomBackgrounds {
		int foreground;
		string name;
		int x, y, tiled, vtiled, hspeed, vspeed = 0;
		bool visible, stretch = false;
	}

	public class GMRoomViews {
		bool visible = false;
		string objName;
		int xview,yview, wview, hview, xport, yport, wport, hport, hborder, vborder, hspeed, vspeed = 0;
	}

	public class GMRoomIntances {
		string name, objName;
		int x,y,scaleX,scaleY,colour,rotation;
		bool locked;
	}
}

