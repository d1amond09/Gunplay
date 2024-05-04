namespace Gunplay.Domain.Interfaces;

public interface IBuffer : IDisposable
{
	public int Id { get; }
	public void Activate();
	public void Deactivate();
	public void Delete();
	public new void Dispose();
}
