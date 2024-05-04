namespace Gunplay.Domain.Interfaces;

public interface IBuffer
{
	public int Id { get; }
	public void Activate();
	public void Deactivate();
	public void Delete();
	public void Dispose();
}
