﻿using Gunplay.Domain.Models;
using Gunplay.Domain.Models.Shells;

namespace Gunplay.Creation;

public class FreezeShellFactory(int damageCount, int reloadSpeedCount) : ShellFactory(damageCount, reloadSpeedCount)
{
	protected override string TexturePath => @"data\img\shell.png";

	public override FreezeShell Create(Player player)
	{
	
		Shell shell = base.Create(player);
		FreezeShell shll = new(shell);
		player.Canoon.Shells.Add(shll);
		return shll;
	}
}
