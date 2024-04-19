using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunplay.Domain.Interfaces;

public interface IBuffer : IDisposable
{
	public int Id { get; }

	public void Activate();

	public void Deactivate();

	public void Delete();

	public new void Dispose();
}
