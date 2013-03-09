// 
//  Channel.cs
//  This file is part of XG - XDCC Grabscher
//  http://www.larsformella.de/lang/en/portfolio/programme-software/xg
//
//  Author:
//       Lars Formella <ich@larsformella.de>
// 
//  Copyright (c) 2012 Lars Formella
// 
//  This program is free software; you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation; either version 2 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program; if not, write to the Free Software
//  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
//  

using System.Linq;

using Newtonsoft.Json;

namespace XG.Server.Plugin.General.ElasticSearch.Object
{
	[JsonObject(MemberSerialization.OptOut)]
	public class Channel : AObject
	{
		[JsonIgnore]
		public new Core.Channel Object
		{
			get
			{
				return (Core.Channel) base.Object;
			}
			set
			{
				base.Object = value;
			}
		}

		#region VARIABLES

		public int ErrorCode
		{
			get { return Object.ErrorCode; }
		}

		public int BotCount
		{
			get { return Object.Bots.Count(); }
		}

		public int PacketCount
		{
			get { return (from bot in Object.Bots from packet in bot.Packets select packet).Count(); }
		}

		public string IrcLink
		{
			get { return Object.Parent != null ? "irc://" + Object.Parent.Name + ":" + Object.Parent.Port + "/" + Object.Name : ""; }
		}

		#endregion
	}
}
