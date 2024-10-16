namespace LinkDev.Talabat.Core.Application.Exceptions
{
	internal class BadRequestException : ApplicationException
	{
        public BadRequestException(string? message = null) : base(message)
        {
        }
    }
}
