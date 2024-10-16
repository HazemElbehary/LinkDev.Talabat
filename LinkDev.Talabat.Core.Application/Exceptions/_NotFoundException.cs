namespace LinkDev.Talabat.Core.Application.Exceptions
{
	internal class _NotFoundException : ApplicationException
	{
		public _NotFoundException(string? name, object key) : base($"{name} With ({key}) Is Not Found")
		{
		}
	}
}
