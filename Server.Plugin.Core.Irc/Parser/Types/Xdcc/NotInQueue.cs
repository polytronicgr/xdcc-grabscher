// 
//  NotInQueue.cs
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

using System.Text.RegularExpressions;

using XG.Core;

namespace XG.Server.Plugin.Core.Irc.Parser.Types.Xdcc
{
	public class NotInQueue : AParserWithExistingBot
	{
		protected override bool ParseInternal(IrcConnection aConnection, Bot aBot, string aMessage)
		{
			string[] regexes =
			{
				"(You Don't Appear To Be In A Queue|Removed you from the queue for.*)"
			};
			var match = Helper.Match(aMessage, regexes);
			if (match.Success)
			{
				if (aBot.State == Bot.States.Waiting)
				{
					aBot.State = Bot.States.Idle;
				}
				aBot.QueuePosition = 0;
				FireQueueRequestFromBot(this, new EventArgs<XG.Core.Server, Bot, int>(aConnection.Server, aBot, Settings.Instance.CommandWaitTime));

				UpdateBot(aBot, aMessage);
				return true;
			}
			return false;
		}
	}
}