using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunplay.DAL.Interfaces
{
	public interface IBaseRepository<TEntity>
	{
		TEntity Get();

		TEntity ChangeTexture(TEntity entity, string texturePath);
	}
}
