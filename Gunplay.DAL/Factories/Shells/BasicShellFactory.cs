﻿using Gunplay.Domain.Models;
using Gunplay.Domain.Models.Shells;
using Gunplay.Domain.Textures;

namespace Gunplay.DAL.Repositories;

public class BasicShellFactory(int damageCount, int reloadSpeedCount) : ShellFactory(damageCount, reloadSpeedCount)
{
	protected override string TexturePath => @"data\img\shell.png";

	public override Shell Create(Player player)
	{
		Shell shell = base.Create(player);
		player.Canoon.Shells.Add(shell);
		return shell;
	}
}
