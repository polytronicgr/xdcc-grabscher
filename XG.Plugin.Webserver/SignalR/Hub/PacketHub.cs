﻿// 
//  PacketHub.cs
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

using System;
using System.Linq;
using XG.Model.Domain;
using XG.Plugin.Webserver.SignalR.Hub;
using System.Collections.Generic;
using XG.Model;
using XG.Plugin.Webserver.SignalR.Hub.Model;
using System.Threading.Tasks;

namespace XG.Plugin.Webserver.SignalR.Hub
{
	public class PacketHub : AObjectHub
	{
		#region Client Handling

		public static readonly HashSet<Client> ConnectedClients = new HashSet<Client>();

		protected override void AddClient(Client aClient)
		{
			aClient.MaxObjects = 20;
			ConnectedClients.Add(aClient);
		}

		protected override void RemoveClient(string connectionId)
		{
			var client = GetClient(connectionId);
			if (client != null)
			{
				ConnectedClients.Remove(client);
			}
		}

		protected override Client GetClient(string connectionId)
		{
			return (from client in ConnectedClients where client.ConnectionId == connectionId select client).SingleOrDefault();
		}

		#endregion

		public Model.Domain.Result LoadByGuid(Guid aGuid, bool aOfflineBots, int aCount, int aPage, string aSortBy, string aSort)
		{
			var search = Helper.Searches.All.SingleOrDefault(s => s.Guid == aGuid);
			if (search != null)
			{
				return LoadByName(search.Name, aOfflineBots, aCount, aPage, aSortBy, aSort);
			}

			IEnumerable<Packet> packets = new List<Packet>();
			if (aGuid == Helper._searchEnabled)
			{
				packets = (from server in Helper.Servers.All from channel in server.Channels from bot in channel.Bots where (!aOfflineBots || bot.Enabled) from packet in bot.Packets where packet.Enabled select packet);
			}
			else if (aGuid == Helper._searchDownloads)
			{
				packets = (from server in Helper.Servers.All from channel in server.Channels from bot in channel.Bots where (!aOfflineBots || bot.Enabled) from packet in bot.Packets where packet.Connected select packet);
			}

			int length;
			var objects = FilterAndLoadObjects<Model.Domain.Packet>(packets, aCount, aPage, aSortBy, aSort, out length);
			UpdateLoadedClientObjects(Context.ConnectionId, new HashSet<Guid>(objects.Select(o => o.Guid)), aCount);
			return new Model.Domain.Result { Total = length, Results = objects };
		}

		public Model.Domain.Result LoadByName(string aSearch, bool aOfflineBots, int aCount, int aPage, string aSortBy, string aSort)
		{
			var packets = (from server in Helper.Servers.All from channel in server.Channels from bot in channel.Bots where (!aOfflineBots || bot.Enabled) from packet in bot.Packets where packet.Name.ContainsAll(aSearch.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)) select packet);
			int length;
			var objects = FilterAndLoadObjects<Model.Domain.Packet>(packets, aCount, aPage, aSortBy, aSort, out length);
			UpdateLoadedClientObjects(Context.ConnectionId, new HashSet<Guid>(objects.Select(o => o.Guid)), aCount);
			return new Model.Domain.Result { Total = length, Results = objects };
		}
	}
}
